namespace Domain.ViewModels
{
    public class UsuarioViewModel
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }

        public List<EmprestimoViewModel> Emprestimos { get; set; }
    }
}