using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prodap.ListaLeitura.Modelos;

namespace Prodap.ListaLeitura.Persistencia
{
  internal class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
  {
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
      builder.Property(l => l.Nome).HasColumnType("nvarchar(50)").IsRequired();

      builder.Property(l => l.Descicao).HasColumnType("nvarchar(100)");

      builder.Property(l => l.Quantidade).HasColumnType("numeric(15, 4)");

      builder.Property(l => l.QuantidadeRetirada).HasColumnType("numeric(15, 4)");

      builder.Property(l => l.ImagemCapa);

      builder.Property(l => l.Validade).HasColumnType("datetime2");
    }
  }
}

