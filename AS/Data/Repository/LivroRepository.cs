using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class LivroRepository : ILivroRepository
    {
        private readonly DataContext _context;
        public LivroRepository(DataContext context)
        {
            _context = context;
        }
        public void Create(Livro entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public IList<Livro> GetAll()
        {
            return _context.Set<Livro>()
                .Include(a => a.Autores).ToList();
        }

        public Livro GetById(int entityId)
        {
            return _context.Set<Livro>()
                .Include(a => a.Autores)
                .SingleOrDefault(i => i.Id == entityId);
        }

        public void Delete(int entityId)
        {
            _context.Set<Livro>().Remove(GetById(entityId));
            _context.SaveChanges();
        }


        public void Update(Livro entity)
        {
            _context.Set<Livro>().Update(entity);
            _context.SaveChanges();
        }
    }
}


//  private readonly DbContext _context;
//         public AutorRepository(DbContext context)
//         {
//             _context = context;
//         }