pipeline {
    agent any
    environment {
	PATH = "/var/lib/jenkins/sonar-scanner/bin:/usr/local/bin:$PATH"  //PATH = "/usr/local/bin:$PATH"
        DOCKERHUB_CREDENTIALS = credentials('dockerhub-creds')  // Sử dụng Docker Hub credentials
        SONAR_TOKEN = credentials('sonar-token')                // SonarQube token
        KUBECONFIG = credentials('kubeconfig')                  // Kubernetes config
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
        
        stage('Build & Test') {
            steps {
                sh '''
                dotnet restore
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
			/d:sonar.language="cs" \
  			/d:sonar.exclusions="**/*.js,**/*.ts,**/bin/**,**/obj/**,**/wwwroot/**,**/Migrations/**,**/*.cshtml.css" \
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
                    def gitCommit = env.GIT_COMMIT ?: sh(script: 'git rev-parse --short HEAD', returnStdout: true).trim()
            	    def customTag = "${env.BUILD_ID}-${gitCommit}"
		    docker.withRegistry('https://index.docker.io/v1/', DOCKERHUB_CREDENTIALS) {
                	def image = docker.build("${DOCKER_IMAGE}:${customTag}")
                	image.push()
                	image.push('latest')
                    }
                }
            }
        }
        
        stage('Deploy to Kubernetes') {
            steps {
                sh """
		export BUILD_ID=${BUILD_ID}
		envsubst < k8s/deployment.yaml | kubectl apply --kubeconfig=${KUBECONFIG} -f -
        	kubectl apply --kubeconfig=${KUBECONFIG} -f k8s/service.yaml --kubeconfig=${KUBECONFIG}
        	kubectl rollout status deployment/qlthuvien-deployment --timeout=2m --kubeconfig=${KUBECONFIG}
                """
            }
        }
    }
    post {
        always {
            cleanWs() // Dọn dẹp workspace
            script {
                dockerLogout() // Đăng xuất Docker
            }
        }
        failure {
            slackSend channel: '#ci-cd', 
                     message: "Build ${env.BUILD_URL} failed!" // Thông báo lỗi
        }
    }
}