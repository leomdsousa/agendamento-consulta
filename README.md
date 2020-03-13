# Albert Einstein Teste

Instruções:

Necessário antes de rodar a aplicação, abrir o projeto e executar os commandos da migration no console para criar o banco de dados e as tabelas. Segue os comandos abaixo: 
Comando para criar migration: add-migration nomeDaMigration. Exemplo: add-migration primeiraMigration
Comando para criar bancos e tabelas: update-database

Serviço de Paciente:

Funções: Vê as consultas, as pesquisam por paciente a marca consulta, que ficam esperando confirmação do serviço de médico para ser marcada (pendências)

Serviço de Médico:

Funções: Vê, edita, deleta e pesquisa (por médico) as consultas. Também confirmão as consultas marcadas pelo paciente, que aguardam confirmação do usuário
