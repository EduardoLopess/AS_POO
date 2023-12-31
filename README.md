
  # API Gerenciamento de Biblioteca.  
  # Programação Orientada a Objetos.

Esta API foi desenvolvida para gerenciar um sistema básico de biblioteca, fornecendo uma solução abrangente para operações CRUD (Criar, Ler, Atualizar e Excluir) relacionadas a livros, usuários, autores e empréstimos.

# Visão geral

![API endpoint](https://github.com/EduardoLopess/AS_POO/assets/80491564/71fd1a5b-652c-4c38-88dc-e911656430df)


![api end user](https://github.com/EduardoLopess/AS_POO/assets/80491564/3eb2ebe6-893e-4bf6-897c-0fbca6a42271)

## LivroController
  POST, GET, PUT e DELETE

  POST /api/Livro
 
 - Cria um novo livro.
   
    -> Autor deve ser informado junto!
   
   Exemplo de corpo da requisição:  
``` 
  {
  "titulo": "string",
  "genero": "string",
  "autores": [
    {
      "nome": "string",
      "telefone": "string",
      "livros": [
        "string"
      ]
    }
  ]
```
  
  GET /api/Livro  
  - Retorna todos os livros cadastrados.

  GET /api/Livro/{id}
  
   - Retorna um livro específico com base no ID.
  
  PUT /api/Livro/{id}
  - Atualiza as informações de um livro existente.
    
     -> Autor deve ser informado junto!
    
  Exemplo de corpo da requisição:
 ```
    {
    "titulo": "string",
    "genero": "string",
    "autores": [
      {
        "nome": "string",
        "telefone": "string",
        "livros": [
          "string"
        ]
      }
    ]
  }
```
 DELETE /api/Livro/{id}
  - Exclui um livro com base no ID.
    
      -> Autor não será deletado junto, deve ser atualizado com novo autor ou deletado!
    
## UsuarioController
  POST, GET, PUT e DELETE
  POST /api/Usuario

  - Cria um novo usuário.

Exemplo de corpo da requisição:

  ```
  {
    "nome": "Nome do Usuário",
    "endereco": "Endereço do Usuário",
    "telefone": "Telefone do Usuário"
  }
  ```
  GET /api/Usuario

  - Retorna todos os usuários cadastrados.

  GET /api/Usuario/{id}

Retorna um usuário específico com base no ID.

  PUT /api/Usuario/{id}

  - Atualiza as informações de um usuário existente.
    
  Exemplo de corpo da requisição:
  ```
  {
    "nome": "string",
    "endereco": "string",
    "telefone": "string"
  }
  ```
  DELETE /api/Usuario/{id}
- Exclui um usuário com base no ID.
   
## AutorController
  POST, GET, PUT e DELETE

   POST /api/Autor
  - Cria um novo autor.
    
    -> Livro deve ser informado junto!
    
  Exemplo de corpo da requisição:  
 ```
    {
      "nome": "string",
      "telefone": "string",
      "livros": [
        {
          "titulo": "string",
          "genero": "string",
          "autores": [
            "string"
          ]
        }
      ]
    } 
 ```
GET /api/Autor
  - Retorna todos os autores cadastrados junto de seus livros.

GET /api/Autor/{id}
  - Retorna um autor específico com base no ID junto de seus livros.
    
PUT /api/Autor/{id}
  - Atualiza as informações de um autor existente.
    
  -> Livro deve ser informado junto!
  
Exemplo de corpo da requisição:
  ```
      {
        "nome": "string",
        "telefone": "string",
        "livros": [
          {
            "titulo": "string",
            "genero": "string",
            "autores": [
              "string"
            ]
          }
        ]
      }
  ```  
 DELETE /api/Autor/{id}
   - Exclui um autor com base no ID.
     
     -> Livro não será deletado junto, deve ser atualizado com novo autor ou deletado!
         
## EmprestimoController

-> O controller de empréstimo conta com o acréscimo de mais três rotas responsáveis por controlar o empréstimo de um livre específico e sua devolução vinculada ao usuário.


  POST, GET, PUT, DELETE, GET, POST e DELETE
  
  POST /api/Emprestimo

  - Cria um novo empréstimo.
  Exemplo de corpo da requisição:
  ```
     {
      "dataEmprestimo": "2023-06-27T05:19:00.486Z",
      "dataDevolucao": "2023-06-27T05:19:00.486Z",
      "usuario": {
      "nome": "string",
      "endereco": "string",
       "telefone": "string",
       "emprestimos": [
              "string"
            ]
          },
          "livro": {
            "titulo": "string",
            "genero": "string",
            "autores": [
              {
                "nome": "string",
                "telefone": "string",
                "livros": [
                  "string"
                ]
              }
            ]
          }
        }
  ```
  GET /api/Emprestimo
  
  - Retorna todos os empréstimos cadastrados.
  
  GET /api/Emprestimo/{id}
  
  - Retorna um empréstimo específico com base no ID.
  
  PUT /api/Emprestimo/{id}
  
  - Atualiza as informações de um empréstimo existente.
  
  Exemplo de corpo da requisição:
  ```
    {
      "dataEmprestimo": "2023-06-27T05:23:22.320Z",
      "dataDevolucao": "2023-06-27T05:23:22.320Z",
      "usuario": {
        "nome": "string",
        "endereco": "string",
        "telefone": "string",
        "emprestimos": [
          "string"
        ]
      },
      "livro": {
        "titulo": "string",
        "genero": "string",
        "autores": [
          {
            "nome": "string",
            "telefone": "string",
            "livros": [
              "string"
            ]
          }
        ]
      }
    }
  ```
  DELETE /api/Emprestimo/{id}
  - Exclui um empréstimo com base no ID.
  
  POST /api/Emprestimo/user/{userId}/livro/{livroId}/emprestar

  - Cria um novo empréstimo associado a um usuário e um livro específicos.
    
  - userId (parâmetro de rota): ID do usuário associado ao empréstimo.
  - livroId (parâmetro de rota): ID do livro associado ao empréstimo.
    
  Exemplo de corpo da requisição:
    
    
      {
        "dataEmprestimo": "2023-06-27T02:37:37.565",
        "dataDevolucao": "2023-06-30T02:37:37.565"
      }
    
  DELETE /api/Emprestimo/emprestimo/{emprestimoId}/user/{userId}/devolver

   - Registra a devolução de um livro em um empréstimo associado a um usuário específico.

  - emprestimoId (parâmetro de rota): ID do empréstimo.
  - userId (parâmetro de rota): ID do usuário associado ao empréstimo.

  Exemplo de corpo da requisição:
  
    
      {
        "dataDevolucao": "2023-07-05T02:37:37.565"
      }
    




