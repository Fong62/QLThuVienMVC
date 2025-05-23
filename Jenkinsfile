pipeline {
    agent any

    environment {
        DOCKER_REGISTRY = 'registry.hub.docker.com'
    }

    stages {
      stage('Checkout') {
          steps {
              git(
                  url: 'https://github.com/Fong62/QLThuVienMVC.git',
                  branch: 'main'
              )
              script {
                  // Lấy Git commit hash sau khi clone
                  env.IMAGE_TAG = sh(
                      script: 'git rev-parse --short HEAD',
                      returnStdout: true
                  ).trim()
              }
          }
      }

        stage('Build & Test') {
            steps {
                dir('QLThuVienMVC') {
                    sh 'dotnet restore'
                    sh 'dotnet build --no-restore'
                    sh 'dotnet test --no-build --verbosity normal'
                }
            }
        }

        stage('Build Docker Image') {
            steps {
                script {
                    dockerImage = docker.build("fong62/qlthuvien:${env.IMAGE_TAG}")
                }
            }
        }

        stage('Push Docker Image') {
            steps {
                script {
                    docker.withRegistry("https://${env.DOCKER_REGISTRY}", 'dockerhub-credentials') {
                        dockerImage.push()
                    }
                }
            }
        }

        stage('Deploy to Kubernetes') {
            steps {
                sshagent(['ubuntu-vm-ssh-key']) {
                    sh """
                        # Tạo thư mục tạm và thay thế biến
                        mkdir -p ./tmp
                        envsubst < k8s/deployment.yaml > ./tmp/deployment.yaml
                        
                        # Copy và áp dụng manifest
                        scp -o StrictHostKeyChecking=no ./tmp/deployment.yaml k8s/service.yaml fong@192.168.1.21:/tmp/
                        ssh fong@192.168.1.21 'kubectl apply -f /tmp/deployment.yaml -f /tmp/service.yaml'
                    """
                }
            }
        }
    }

    post {
        always {
            // Cleanup workspace
            deleteDir()
        }
        failure {
            // Thông báo lỗi qua Slack/Email
            slackSend channel: '#devops', message: "Build failed: ${env.JOB_NAME} #${env.BUILD_NUMBER}"
        }
    }
}