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
        
        
        
        stage('Docker Build & Push') {
            steps {
                script {
                    // Đăng nhập Docker Hub
		    def gitCommit = sh(script: 'git rev-parse --short HEAD', returnStdout: true).trim()
            	    def customTag = "${env.BUILD_ID}-${gitCommit}"
                    docker.withRegistry('https://index.docker.io/v1/', dockerhub-creds) {
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