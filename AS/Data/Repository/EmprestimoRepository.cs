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
                .Include(e => e.Livro.Autores)
                    .ToList();
        }

        public Emprestimo GetById(int entityId)
        {
            return _context.Set<Emprestimo>()
                .Include(a => a.Usuario)
                .Include(l => l.Livro)
                .Include(e => e.Livro.Autores)
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
                .Include(u => u.Usuario)
                .Include(l => l.Livro)
                .Include(a => a.Livro.Autores)
                    .Where(e => e.UsuarioId == userId)
                        .ToList();
        }

        public bool CanUserBorrowBook(int userId, int livroId)
        {
            // Verificar se o livro já está emprestado para qualquer usuário
            bool livroJaEmprestado = _context.Set<Emprestimo>()
                .Any(e => e.LivroId == livroId && e.DataDevolucao == null);

            if (livroJaEmprestado)
            {
                return false;
            }

            // Verificar se o livro já está presente em algum empréstimo existente
            bool livroJaEmprestadoEmEmprestimoExistente = _context.Set<Emprestimo>()
                .Any(e => e.LivroId == livroId);

            if (livroJaEmprestadoEmEmprestimoExistente)
            {
                return false; 
            }

            // Verificar se o livro já está emprestado pelo usuário
            bool livroJaEmprestadoPeloUsuario = _context.Set<Emprestimo>()
                .Any(e => e.LivroId == livroId && e.UsuarioId == userId && e.DataDevolucao == null);

            if (livroJaEmprestadoPeloUsuario)
            {
                return false; 
            }

            return true;
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

        public IList<Emprestimo> GetEmprestimosByUsuario(int usuarioId)
        {
            return _context.Emprestimos.Where(e => e.UsuarioId == usuarioId).ToList();
        }

        
    }
}
