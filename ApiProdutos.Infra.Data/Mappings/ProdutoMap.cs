using ApiProdutos.Infra.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProdutos.Infra.Data.Mappings
{
    /// <summary>
    /// Classe de mapeamento ORM para a entidade Produto
    /// </summary>
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("PRODUTO");

            builder.HasKey(p => p.IdProduto);

            builder.Property(p => p.IdProduto)
                .HasColumnName("IDPRODUTO")
                .IsRequired();

            builder.Property(p => p.Nome)
               .HasColumnName("NOME")
               .HasMaxLength(150)
               .IsRequired();

            builder.Property(p => p.Preco)
               .HasColumnName("PRECO")
               .HasColumnType("decimal(18,2)")
               .IsRequired();

            builder.Property(p => p.Quantidade)
               .HasColumnName("QUANTIDADE")
               .IsRequired();

            builder.Property(p => p.DataCriacao)
               .HasColumnName("DATACRIACAO")
               .IsRequired();

            builder.Property(p => p.DataUltimaAlteracao)
               .HasColumnName("DATAULTIMAALTERACAO")
               .IsRequired();
        }
    }
}



