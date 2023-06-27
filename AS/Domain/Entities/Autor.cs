namespace Domain.Entities
{
    public class Autor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }

        // Relacionamento MUITO pra MUITOS, onde um autor tem muitos livros
        public IList<Livro> Livros { get; set; } = new List<Livro>();
    }
}