namespace Domain.ViewModels
{
    public class AutorViewModel
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }

        public List<LivroViewModel> Livros { get; set; }
        
    }
}