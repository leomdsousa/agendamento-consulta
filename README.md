# Agendamento Consulta

## Descrição do Projeto
<p align="center">Projeto de agendamento de consulta médica</p>

## Instruções:

## Serviço de Paciente:

Funções: Vê as consultas, as pesquisam por paciente a marca consulta, que ficam esperando confirmação do serviço de médico para ser 
marcada (pendências)

Rota para marcas consultas e gerar pendência para o serciço de médico : /Consultas/AgendarConsulta

## Serviço de Médico:

Funções: Vê, edita, deleta e pesquisa (por médico) as consultas. Também confirmão as consultas marcadas pelo paciente, que aguardam confirmação do usuário

Rota para ver e marcas as consultas agendadas pelo pacintes: /Consultas/ConsultasPendentes

### 🛠 Tecnologias

As seguintes ferramentas/bibiotecas foram usadas na construção do projeto:

- Arquitetura MVC
- Patterns: Repository, Injeção de Dependência
- XUnit (Unit Tests)
- Moq
- EntityFramework (acesso a dados)
