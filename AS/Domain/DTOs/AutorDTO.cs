using Domain.Entities;

namespace Domain.DTOs
{
    public class AutorDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }

        //contém os detalhes completos dos livros escritos pelo autor
        public IList<LivroDTO> Livros { get; set; }
    }
}