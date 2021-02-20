using Microsoft.EntityFrameworkCore;
using Prodap.ListaLeitura.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prodap.ListaLeitura.Persistencia
{
  public class LeituraContext : DbContext
  {
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Vendas> Vendas { get; set; }

    public LeituraContext(DbContextOptions<LeituraContext> options)
        : base(options)
    {
      //irá criar o banco e a estrutura de tabelas necessárias
      this.Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      modelBuilder.ApplyConfiguration<Produto>(new ProdutoConfiguration());
      modelBuilder.ApplyConfiguration<Vendas>(new VendaConfiguration());
    }
  }
}
