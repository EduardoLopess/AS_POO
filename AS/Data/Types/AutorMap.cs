using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Types
{
    public class AutorMap : IEntityTypeConfiguration<Autor>
    {
        public void Configure(EntityTypeBuilder<Autor> builder)
        {
            builder.ToTable("Autor");

            builder.Property(a => a.Id)
                .HasColumnName("Id")
                .IsRequired();
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Nome)
                .HasColumnName("Titulo")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(a => a.Telefone)
                .HasColumnName("Telefone")
                .HasMaxLength(9)
                .IsRequired(); 
            
        }
    }
}