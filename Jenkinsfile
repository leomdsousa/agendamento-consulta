pipeline {
	agent any

	environment {
	    DOTNET_ROOT = tool name: 'dotnet', type: 'com.microsoft.jenkins.plugins.dotnet.DotNetSDK'
        PATH = "${env.PATH}:${env.DOTNET_ROOT}"
	}

	stages {
		stage('Checkout') {
		    steps {
                git 'https://github.com/leomdsousa/agendamento-consulta.git'
            }
		}

		stage('Restore') {
            steps {
                sh 'dotnet restore'
            }
        }

		stage('Build') {
            steps {
                sh 'dotnet build --configuration Release'
            }
        }
	}

}