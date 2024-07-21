pipeline {
	agent any

	stages {
		stage('Checkout') {
		    steps {
                git 'https://github.com/leomdsousa/agendamento-consulta.git'
            }
		}

		stage('Restore') {
            steps {
                bat 'dotnet restore'
            }
        }

		stage('Build and Publish') {
            steps {
                bat 'dotnet publish --configuration Release --output "%WORKSPACE%\\output"'
            }
        }

        stage('Deploy') {
            steps {
                script {
                    def websiteName = 'AgendamentoConsulta'
                    def deployPath = '%WORKSPACE%\\output'

                    // Parar o site no IIS
                    bat "iisreset /stop"

                    // Remover arquivos antigos
                    bat "powershell Remove-Item -Recurse -Force 'C:\\inetpub\\${websiteName}\\*'"

                    // Copiar novos arquivos
                    bat "powershell Copy-Item -Recurse -Force '${deployPath}\\*' 'C:\\inetpub\\${websiteName}'"

                    // Iniciar o site no IIS
                    bat "iisreset /start"
                }
            }
        }
	}
}