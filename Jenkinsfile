pipeline {
	agent any

	stages {
		stage('Checkout') {
		    steps {
                // Certifique-se de que a workspace está limpa antes de clonar o repositório
                cleanWs()

                // Checkout do repositório especificando o branch
                git branch: 'master', url: 'https://github.com/leomdsousa/agendamento-consulta.git'
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