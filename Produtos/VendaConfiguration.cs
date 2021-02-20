using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prodap.ListaLeitura.Modelos;

namespace Prodap.ListaLeitura.Persistencia
{
  internal class VendaConfiguration : IEntityTypeConfiguration<Vendas>
  {
    public void Configure(EntityTypeBuilder<Vendas> builder)
    {
      builder.Property(l => l.Quantidade).HasColumnType("numeric(15,4)").IsRequired();

      builder.Property(l => l.DataVenda).HasColumnType("datetime2");

      builder.Property(l => l.IdProduto).HasColumnType("int");
      
      builder.Property(l => l.IdProduto).HasColumnType("nvarchar(5)").IsRequired();
    }
  }
}
