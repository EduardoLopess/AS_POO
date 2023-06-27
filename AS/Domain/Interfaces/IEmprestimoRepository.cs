using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IEmprestimoRepository : IBaseRepository<Emprestimo>
    {
        IList<Emprestimo> GetAllByUserId(int userId);
        bool PegarLivro(int userId, int livroId);
        bool UsuarioPodePegarLivro(int emprestimoId, int userId);
        IList<Emprestimo> GetEmprestimosByUsuario(int usuarioId);
    }
}