
AS - Programação Orientada a Objetos.

API criada para atender ao gerenciamento de um sistema de biblioteca, dividido em quatro controladores diferentes, com suas respectivas operações REST.

## LivroController
  POST, GET, PUT e DELETE 
## UsuarioController
  POST, GET, PUT e DELETE

  
## AutorController
  POST, GET, PUT e DELETE

   POST /api/Autor
   '''
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
'''

    
## EmprestimoController
  POST, GET, PUT, DELETE, GET, POST e DELETE

  -> O controller de empréstimo conta com o acréscimo de mais três rotas responsáveis por controlar o empréstimo e devolução do usuário.

------------------
Visão geral

![API endpoint](https://github.com/EduardoLopess/AS_POO/assets/80491564/71fd1a5b-652c-4c38-88dc-e911656430df)


![api end user](https://github.com/EduardoLopess/AS_POO/assets/80491564/3eb2ebe6-893e-4bf6-897c-0fbca6a42271)
