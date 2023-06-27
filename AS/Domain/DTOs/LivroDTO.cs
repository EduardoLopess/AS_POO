using Domain.Entities;

namespace Domain.DTOs
{
    public class LivroDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }

        //contém os nomes dos autores relacionados a esse livro.
        public IList<string> Autores { get; set; }
    }
}