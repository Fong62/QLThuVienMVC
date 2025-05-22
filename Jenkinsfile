pipeline {
    agent any

    environment {
        IMAGE_TAG = sh(script: 'git rev-parse --short HEAD', returnStdout: true).trim()
    }

    stages {
        stage('Checkout') {
            steps {
                git url: 'https://github.com/Fong62/QLThuVienMVC.git', branch: 'main'
            }
        }

        stage('Build & Test') {
            steps {
                dir('QLThuVienMVC') {
                    sh 'dotnet restore'
                    sh 'dotnet build'
                    sh 'dotnet test'
                }
            }
        }

        stage('Build Docker Image') {
            steps {
                script {
                    docker.build("fong62/qlthuvien:${env.IMAGE_TAG}")
                }
            }
        }

        stage('Push Docker Image') {
            steps {
                script {
                    docker.withRegistry('https://registry.hub.docker.com', 'dockerhub-credentials') {
                        docker.image("fong62/qlthuvien:${env.IMAGE_TAG}").push() // Push đúng tag
                    }
                }
            }
        }

        stage('Deploy to Kubernetes') {
            steps {
                sshagent(['ubuntu-vm-ssh-key']) {
                    sh """
                        scp -o StrictHostKeyChecking=no k8s/* fong@192.168.1.21:/tmp/
                        ssh fong@192.168.1.21 'kubectl apply -f /tmp/deployment.yaml -f /tmp/service.yaml'
                    """
                }
            }
        }
    }
}