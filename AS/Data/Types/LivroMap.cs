using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Types
{
    public class LivroMap : IEntityTypeConfiguration<Livro>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Livro> builder)
        {
            builder.ToTable("Livro");

            builder.Property(l => l.Id)
                .HasColumnName("Id")
                .IsRequired();
            builder.HasKey(l => l.Id);

            builder.Property(l => l.Titulo)
                .HasColumnName("Titulo")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(l => l.Genero)
                .HasColumnName("Genero")
                .HasMaxLength(100)
                .IsRequired();

            // builder.HasMany(l => l.Autores)
            //     .WithMany()
            //     .UsingEntity<Dictionary<string, object>>(
            //         "LivroAutor",
            //         l => l.HasOne<Autor>()
            //             .WithMany().HasForeignKey("AutorId"),
            //         l => l.HasOne<Livro>()
            //             .WithMany().HasForeignKey("LivroId"),
            //         l =>
            //         {
            //             l.HasKey("LivroId", "AutorId");
            //             l.ToTable("LivroAutor");
            //         }
            //     );

            
        }
    }
}