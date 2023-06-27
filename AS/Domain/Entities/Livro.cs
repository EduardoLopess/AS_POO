namespace Domain.Entities
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }

        // Relacionamento MUITO pra MUITOS, onde um livro tem muitos autores
        public IList<Autor> Autores { get; set; }
        
    }
}