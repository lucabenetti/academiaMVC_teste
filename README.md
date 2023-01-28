### cs-2022-1_g2
Repositório definido para a manutenção do controle de versão dos artefatos gerados na construção de uma API REST, durante o curso da disciplina **Construção de Software**, do curso de **Engenharia de Software**, do **INF/UFG**, no semestre 2022/1.

### Descrição do Produto: API para o gerenciamento de academias, na qual seria possível ter perfis de aluno (visualizar treinos), professor (cadastrar treinos, vincular treinos aos alunos) e administrador (visualizar treinos, professores, alunos, fazer edições gerais).

#### Requisitos:
1. Requisito/funcionalidade: autenticação e cadastro de professor (como administrador)
2. Requisito/funcionalidade: cadastrar aluno (como administrador)
3. Requisito/funcionalidade: cadastrar exercícios (como professor) 
4. Requisito/funcionalidade: associação de treino (exercícios, dia de realização e aluno) (como professor)
5. Requisito/funcionalidade: acesso ao treino (como aluno)

### Tecnologia empregada no desenvolvimento:

### Linguagem: .NET 6

### Banco de Dados: PostgreSQL

### Local de deploy: AWS

### Execucação aplicação:
- Modo desenvolvimento: `docker-compose up -d` **(será iniciado apenas o container do PostgreSQL)**
- Modo staging: `docker-compose -f docker-compose.yml -f docker-compose.staging.yml up -d` **(será iniciado o container da aplicação e do PostgreSQL)**

### Login aplicação como admin:

- Utilizar endpoint `/Autenticacao/autenticar` com o body:

```json
{
  "email": "admin@ufg.br",
  "senha": "admin@UFG123"
}
```

### Arquitetura
![](https://raw.githubusercontent.com/gilmarioArantes/cs-2022-1_g2/develop/docs/arquitetura.png)

### Casos de uso
