using ControleFinanceiro.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFinanceiro.DAL.Mapeamentos
{
    public class CartaoMap : IEntityTypeConfiguration<Cartao>
    {
        public void Configure(EntityTypeBuilder<Cartao> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasIndex(c => c.Nome).IsUnique();
            builder.HasIndex(c => c.Numero).IsUnique();

            builder.Property(c => c.Nome).IsRequired().HasMaxLength(20);
            builder.Property(c => c.Bandeira).IsRequired().HasMaxLength(15);
            builder.Property(c => c.Numero).IsRequired().HasMaxLength(20);
            builder.Property(c => c.Limite).IsRequired();

            builder.HasOne(c => c.Usuario).WithMany(c => c.Cartaos).HasForeignKey(c => c.UsuarioId).IsRequired().OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(c => c.Despesas).WithOne(c => c.Cartao);

            builder.ToTable("Cartoes");
        }
    }
}
