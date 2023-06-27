using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Types
{
    public class EmprestimoMap : IEntityTypeConfiguration<Emprestimo>
    {
        public void Configure(EntityTypeBuilder<Emprestimo> builder)
        {
            builder.ToTable("Emprestimo");

            builder.Property(e => e.Id)
                .HasColumnName("Id")
                .IsRequired();
            builder.HasKey(e => e.Id);

            builder.Property(e => e.DataEmprestimo)
                .HasColumnName("DataEmprestimo")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(e => e.DataDevolucao)
                .HasColumnName("DataDevolucao")
                .HasMaxLength(10)
                .IsRequired();

            //Relações
            builder.HasOne(e => e.Livro)
                .WithMany()
                .HasForeignKey(e => e.LivroId);
            
            builder.HasOne(e => e.Usuario)
                .WithMany()
                .HasForeignKey(e => e.UsuarioId)
                .IsRequired();  
        }
    }
}