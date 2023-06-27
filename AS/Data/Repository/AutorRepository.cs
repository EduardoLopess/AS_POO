using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class AutorRepository : IAutorRepository
    {
        private readonly DataContext _context;
        public AutorRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(Autor entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public IList<Autor> GetAll()
        {
            return _context.Set<Autor>()
                .Include(l => l.Livros).ToList();
        }

        public Autor GetById(int entityId)
        {
            return _context.Set<Autor>()
                .Include(l => l.Livros)
                .SingleOrDefault(i => i.Id == entityId);
        }

        public void Delete(int entityId)
        {
             var autor = GetById(entityId);
            if (autor != null)
            {
                _context.Set<Autor>().Remove(autor);
                _context.SaveChanges();
            }
        }

        public void Update(Autor entity)
        {
            _context.Set<Autor>().Update(entity);
            _context.SaveChanges();
        }

    }  
}