using System;

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
}
