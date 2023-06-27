using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IEmprestimoRepository : IBaseRepository<Emprestimo>
    {
        IList<Emprestimo> GetAllByUserId(int userId);
        bool CanUserBorrowBook(int userId, int livroId);
        bool CanUserReturnBook(int emprestimoId, int userId);
    }
}