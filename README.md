# Albert Einstein Teste

## Instruções:

Antes de rodar a aplicação é necessário dar efetuar a migration para criar o banco de dados. Segue os comandos

Comandos foram efetuados no Package Manager Console (no visual studio 2017)

add-migration nomeMigration
Exemplo: add-migration PrimeiraMigration

update-database

A connection atring está configurada para o banco de dados local. Segue a connection string: 
"Server=.;Database=AlbertEinsteinTesteContext;Trusted_Connection=True;MultipleActiveResultSets=true"

## Serviço de Paciente:

Funções: Vê as consultas, as pesquisam por paciente a marca consulta, que ficam esperando confirmação do serviço de médico para ser 
marcada (pendências)

Rota para marcas consultas e gerar pendência para o serciço de médico : /Consultas/AgendarConsulta

## Serviço de Médico:

Funções: Vê, edita, deleta e pesquisa (por médico) as consultas. Também confirmão as consultas marcadas pelo paciente, que aguardam confirmação do usuário

Rota para ver e marcas as consultas agendadas pelo pacintes: /Consultas/ConsultasPendentes
