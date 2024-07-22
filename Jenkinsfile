pipeline {
	agent any

	stages {
		stage('Checkout') {
		    steps {
                // Certifique-se de que a workspace est� limpa antes de clonar o reposit�rio
                cleanWs()

                // Checkout do reposit�rio especificando o branch
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