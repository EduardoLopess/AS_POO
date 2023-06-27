using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class EmprestimoRepository : IEmprestimoRepository
    {
        private readonly DataContext _context;
        public EmprestimoRepository(DataContext context)
        {
            _context = context;
        }
        public void Create(Emprestimo entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public IList<Emprestimo> GetAll()
        {
            return _context.Set<Emprestimo>()
                .Include(a => a.Usuario)
                .Include(l => l.Livro)
                    .ToList();
        }

        public Emprestimo GetById(int entityId)
        {
            return _context.Set<Emprestimo>()
                .Include(a => a.Usuario)
                .Include(l => l.Livro)
                    .SingleOrDefault(i => i.Id == entityId);
        }

        public void Delete(int entityId)
        {
            _context.Set<Emprestimo>().Remove(GetById(entityId));
            _context.SaveChanges();
        }

        public void Update(Emprestimo entity)
        {
            _context.Set<Emprestimo>().Update(entity);
            _context.SaveChanges();
        }

        public IList<Emprestimo> GetAllByUserId(int userId)
        {
            return _context.Set<Emprestimo>()
                .Include(a => a.Usuario)
                .Include(l => l.Livro)
                    .Where(e => e.UsuarioId == userId)
                        .ToList();
        }

        public bool CanUserBorrowBook(int userId, int livroId)
        {
            Usuario usuario = _context.Set<Usuario>()
                .Include(u => u.Emprestimos)
                .SingleOrDefault(u => u.Id == userId);

            if (usuario == null)
            {
                return false; // Usuário não encontrado
            }

            // Verificar se o livro já está emprestado pelo usuário
            bool livroJaEmprestado = usuario.Emprestimos
                .Any(e => e.LivroId == livroId && e.DataDevolucao == null);

            if (livroJaEmprestado)
            {
                return false; // O livro já está emprestado pelo usuário
            }

            return true; // O usuário pode pegar emprestado o livro
        }

        public bool CanUserReturnBook(int emprestimoId, int userId)
        {
            // Verificar se o empréstimo existe e pertence ao usuário
            bool emprestimoExists = _context.Set<Emprestimo>()
                .Any(e => e.Id == emprestimoId && e.UsuarioId == userId);

            if (!emprestimoExists)
            {
                return false; // O empréstimo não existe ou não pertence ao usuário
            }

            return true; // O usuário pode devolver o livro
        }


        
    }
}