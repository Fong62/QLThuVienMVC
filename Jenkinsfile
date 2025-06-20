pipeline {
    agent any
    environment {
	PATH = "/var/lib/jenkins/sonar-scanner/bin:/usr/local/bin:$PATH"
        //DOCKERHUB_CREDENTIALS = credentials('dockerhub-creds')  // Sử dụng Docker Hub credentials
        SONAR_TOKEN = credentials('sonar-token')                // SonarQube token
        //KUBECONFIG = credentials('kubeconfig')                  // Kubernetes config
        DOCKER_IMAGE = "fong62/qlthuvien"                       // Tên image Docker
    }
    stages {
        stage('Checkout Code') {
            steps {
                git url: 'https://github.com/Fong62/QLThuVienMVC.git', 
                     branch: 'main',
                     credentialsId: 'github-credentials'
            }
        }

        stage('Restore') {
            steps {
                script {
                    // Đường dẫn cache trên Jenkins agent
                    def cachePath = "${env.WORKSPACE}/.nuget_packages_cache"

                    // Nếu có cache thì copy lại vào thư mục .nuget/packages
                    if (fileExists(cachePath)) {
                        echo "Restore cache to .nuget/packages"
                        sh "rm -rf ~/.nuget/packages"
                        sh "mkdir -p ~/.nuget"
                        sh "cp -r ${cachePath} ~/.nuget/packages"
                    }

                    // Thực hiện restore nuget packages
                    sh 'dotnet restore'
                    
                    // Sau khi restore, cập nhật lại cache
                    echo "Save .nuget/packages to cache"
                    sh "rm -rf ${cachePath}"
                    sh "mkdir -p ${cachePath}"
                    sh "cp -r ~/.nuget/packages/* ${cachePath}/"
                }
            }
        }
        
        stage('Build & Test') {
            steps {
                sh '''
                dotnet build --configuration Release --no-restore
                dotnet test --no-build --verbosity normal
                '''
            }
        }
        
        stage('SonarQube Analysis') {
            steps {
                withSonarQubeEnv('sonarqube') {
                    sh """
                    dotnet sonarscanner begin \
                        /k:"QLThuVienMVC" \
                        /d:sonar.host.url="http://192.168.1.21:9000" \
                        /d:sonar.login="$SONAR_TOKEN" \
			/d:sonar.scanner.scanAll=false \
			/d:sonar.plugins.downloadOnlyRequired=true \
			/d:sonar.language="cs" \
  			/d:sonar.exclusions="**/*.js,**/*.ts,**/bin/**,**/obj/**,**/wwwroot/**,**/Migrations/**,**/*.cshtml.css,**/Migrations/**/*.cs" \
			/d:sonar.css.file.suffixes=".css,.less,.scss" \
                        /n:"QLThuVienMVC" \
  			/v:"${BUILD_NUMBER}"
                    
                    dotnet build --configuration Release --no-restore
                    dotnet sonarscanner end /d:sonar.login="$SONAR_TOKEN" || true
                    """
                }
            }
        }
        
        stage('Docker Build & Push') {
            steps {
                script {
                    // Đăng nhập Docker Hub
		    def gitCommit = sh(script: 'git rev-parse --short HEAD', returnStdout: true).trim()
            	    def customTag = "${env.BUILD_ID}-${gitCommit}"
                    docker.withRegistry('https://index.docker.io/v1/', 'dockerhub-creds') {
                        def image = docker.build("${DOCKER_IMAGE}:${customTag}")
                        retry(3) {
        		   image.push()
    			}

    			retry(3) {
        		   image.push('latest')
    			}
                    }
                }
            }
        }
        
        stage('Deploy to Kubernetes') {
            steps {
                withCredentials([file(credentialsId: 'kubeconfig', variable: 'KUBECONFIG_PATH')]) {
                    script {
                	def gitCommit = sh(script: 'git rev-parse --short HEAD', returnStdout: true).trim()
                	def customTag = "${env.BUILD_ID}-${gitCommit}"
                	sh """
                	export KUBECONFIG=${KUBECONFIG_PATH}
                	export BUILD_ID=${customTag}	
                	envsubst < k8s/deployment.yaml | kubectl apply -f -
                	kubectl apply -f k8s/service.yaml
                	kubectl rollout status deployment/qlthuvien-deployment --timeout=10m
                	"""
            	     }
		}
            }
        }
    }
    post {
        always {
            deleteDir()
        }
    }
}