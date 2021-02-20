using Prodap.ListaLeitura.Modelos;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Model
{
  public class Carrinho
  {
    int IdVendedor;
    public int idDoProduto { get; set; }
    public List<Produto> Picole { get; set; } = new List<Produto>();
    public int Quantidade { get; set; }

    public void AdItem(Produto item)
    {
      Picole.Add(item);
    }
    public decimal QuantidadeTotal()
    {
      return Picole.Sum(x=>x.Quantidade);
    }
  }
}
