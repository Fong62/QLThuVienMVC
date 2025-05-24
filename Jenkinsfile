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
                        /n:"QLThuVienMVC" \
  			/v:"${BUILD_NUMBER}" \
			/d:sonar.language="cs" \
  			/d:sonar.exclusions="**/bin/**,**/obj/**,**/wwwroot/**,**/Migrations/**"
                    
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
                    docker.withRegistry('', DOCKERHUB_CREDENTIALS) {
                        def customTag = "${env.BUILD_ID}-${env.GIT_COMMIT.take(7)}" // Thêm commit hash
                        def image = docker.build("${DOCKER_IMAGE}:${customTag}")
                        image.push()
                        image.push('latest') // Push cả tag latest
                    }
                }
            }
        }
        
        stage('Deploy to Kubernetes') {
            steps {
                sh """
                kubectl apply -f k8s/deployment.yaml --kubeconfig=${KUBECONFIG}
                kubectl apply -f k8s/service.yaml --kubeconfig=${KUBECONFIG}
                kubectl rollout status deployment/qlthuvien --timeout=2m --kubeconfig=${KUBECONFIG}
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