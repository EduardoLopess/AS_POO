using Domain.Entities;

namespace Domain.DTOs
{
    public class EmprestimoDTO
    {
        public int Id { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime? DataDevolucao { get; set; }
            
       
        public LivroDTO Livro { get; set; }
        public UsuarioDTO Usuario { get; set; }

      
    }
}