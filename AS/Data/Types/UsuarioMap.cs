using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Types
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.Property(u => u.Id)
                .HasColumnName("Id")
                .IsRequired();
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(u => u.Endereco)
                .HasColumnName("Endereco")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(u => u.Telefone)
                .HasColumnName("Telefone")
                .HasMaxLength(9)
                .IsRequired();        

            builder.HasMany(u => u.Emprestimos)
                .WithOne(e => e.Usuario)
                .HasForeignKey(e => e.UsuarioId);

        }
    }
}