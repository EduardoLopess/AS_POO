namespace Domain.ViewModels
{
    public class LivroViewModel
    {
        public string Titulo { get; set; }
        public string Genero { get; set; } 

        public List<AutorViewModel> Autores { get; set; }
    }
}