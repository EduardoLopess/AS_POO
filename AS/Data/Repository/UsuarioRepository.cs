using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DataContext _context;
        public UsuarioRepository(DataContext context)
        {
            _context = context;
        }
        public void Create(Usuario entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public IList<Usuario> GetAll()
        {
            return _context.Set<Usuario>()
                .Include(e => e.Emprestimos)
                .ToList();
        }

        public Usuario GetById(int entityId)
        {
            return _context.Set<Usuario>()
                .Include(e => e.Emprestimos)
                .SingleOrDefault(i => i.Id == entityId);
        }

        public void Delete(int entityId)
        {
            _context.Set<Usuario>().Remove(GetById(entityId));
            _context.SaveChanges();
        }

        public void Update(Usuario entity)
        {
            _context.Set<Usuario>().Update(entity);
            _context.SaveChanges();
        }
    }
}