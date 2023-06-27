
AS - Programação Orientada a Objetos.

API criada para atender ao gerenciamento de um sistema de biblioteca, dividido em quatro controladores diferentes, com suas respectivas operações REST.

## LivroController
  POST, GET, PUT e DELETE

  LivroController

  POST /api/Livro
 
 - Cria um novo livro.
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

  
## UsuarioController
  POST, GET, PUT e DELETE

  
## AutorController
  POST, GET, PUT e DELETE

   POST /api/Autor
  - Cria um novo autor.
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
         
## EmprestimoController

> O controller de empréstimo conta com o acréscimo de mais três rotas responsáveis por controlar o empréstimo e devolução do usuário.


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
  
------------------
Visão geral

![API endpoint](https://github.com/EduardoLopess/AS_POO/assets/80491564/71fd1a5b-652c-4c38-88dc-e911656430df)


![api end user](https://github.com/EduardoLopess/AS_POO/assets/80491564/3eb2ebe6-893e-4bf6-897c-0fbca6a42271)
