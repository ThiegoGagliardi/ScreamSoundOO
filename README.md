# Scream Sound - Console Application

## Descrição
O Scream Sound é um projeto de aplicativo de console que permite aos usuários avaliar bandas de música. O aplicativo utiliza um banco de dados MySQL para armazenar informações sobre as bandas, usuários e suas avaliações. O projeto é desenvolvido em C# .NET.

## Funcionalidades
- Cadastro de banda
- Avaliação de banda
- Listagem de todas as bandas
- Cálculo da média de nota de uma banda
- Listagem de todas as notas de uma banda
- Listagem de todas as bandas avaliadas para o usuário

## Fluxo da Aplicação
1. O usuário é apresentado com um menu de login ou cadastro de usuário.
2. Após efetuar o login, o usuário tem acesso ao menu principal com as opções listadas acima.
3. O usuário pode selecionar uma opção e interagir com o sistema conforme desejado.

## Pré-requisitos
- Banco de dados MySQL instalado
- String de conexão configurada na classe `ConnectionFactory`
- Script de criação da base de dados disponível em `src/bd/createtable.sql`

## Como Executar
1. Clone o repositório para o seu ambiente local.
2. Execute o script `createtable.sql` para criar a base de dados necessária.
3. Configure a string de conexão no arquivo `ConnectionFactory.cs`.
4. Utilize o CLI e execute o comando `dotnet run` para iniciar o aplicativo.

## Estrutura do Banco de Dados
O banco de dados possui as seguintes tabelas:

### Tabela `banda`
- Campos:
  - Nome da banda
  - Gênero
  - Data de fundação

### Tabela `usuário`
- Campos:
  - Nome
  - Senha

### Tabela `nota`
- Campos:
  - ID do usuário
  - Nome da banda
  - Nota atribuída pelo usuário à banda

## Contribuição
Contribuições são bem-vindas! Se você deseja contribuir com este projeto, sinta-se à vontade para criar uma issue ou enviar um pull request.

## Licença
Este projeto está licenciado sob a [MIT License](LICENSE).