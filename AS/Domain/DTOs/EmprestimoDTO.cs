using Domain.Entities;

namespace Domain.DTOs
{
    public class EmprestimoDTO
    {
        public int Id { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime? DataDevolucao { get; set; }
            
        // Relacionamento com Livro
        public int LivroId { get; set; }
        public LivroDTO Livro { get; set; }
            
        // Relacionamento com Usuário
        public int UsuarioId { get; set; }
        public UsuarioDTO Usuario { get; set; }
    }
}