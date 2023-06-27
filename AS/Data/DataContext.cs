using Data.Types;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Data
{
    public class DataContext : DbContext
    {
        public DataContext() { }
        public string DbPath { get; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            string path = Directory.GetCurrentDirectory();
            DbPath = System.IO.Path.Join(path, "bancoLocal.db");
        }
    
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite($"Data Source = {DbPath}");

        public DbSet<Livro> Livros { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Emprestimo> Emprestimos { get; set; }
        public DbSet<Autor> Autors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LivroMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new EmprestimoMap());
            modelBuilder.ApplyConfiguration(new AutorMap());
        }
    }
}