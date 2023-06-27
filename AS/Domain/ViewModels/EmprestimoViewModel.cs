using Domain.Entities;

namespace Domain.ViewModels
{
    public class EmprestimoViewModel
    {
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }

        public UsuarioViewModel Usuario { get; set; }
        public LivroViewModel Livro { get; set; }

    }
}