using System;
using System.Collections.Generic;
using System.Linq;

namespace Prodap.ListaLeitura.Modelos
{
  public class Vendas
  {
    public int Id { get; set; }
    public string IdProduto { get; set; }
    public int IdVendedor { get; set; }
    public decimal Quantidade { get; set; }
    public DateTime DataVenda { get; set; }

    public void ValidarVenda()
    {
      if (Quantidade <= 0)
        throw new Exception("Vendendor não realizou nenhuma venda");
    }
  }
  public abstract class LogSincronismoApi
  {
    public int QuantidadeSincronizada { get; set; }
    public DateTime DataSincronismo { get; set; }
    public List<string> ProdutosVendidos { get; set; }
    public List<string> ProdutosNaoVendidos { get; set; }
    public abstract void RetornoSincronismo(List<Vendas> vendas);

    protected virtual void GetDataSincronismo()
    {
      DataSincronismo = DateTime.Now;
    }
    
  }

  public class VendasPicole : LogSincronismoApi
  {
    
    public int Id { get; set; }

    protected override void GetDataSincronismo()
    {
      DataSincronismo = DateTime.Now.Date;
    }

    public override void RetornoSincronismo(List<Vendas> picoles)
    {
      QuantidadeSincronizada = picoles.Count;
      ProdutosVendidos = picoles.FindAll(x=>x.Quantidade > 0).Select(s => s.IdProduto).ToList();
      ProdutosNaoVendidos = picoles.FindAll(x => x.Quantidade == 0).Select(s => s.IdProduto).ToList();
    }
  }
}

