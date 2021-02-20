using Prodap.ListaLeitura.Modelos;
using System.Collections.Generic;

namespace Prodap.ListaLeitura.WebApp.Models
{
  public class HomeViewModel
  {
    public IEnumerable<Produto> Produtos { get; set; }
    public IEnumerable<Produto> ComVendedores { get; set; }
    public IEnumerable<Produto> Estoque { get; set; }
  }
}
