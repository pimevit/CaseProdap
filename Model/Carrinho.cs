using Prodap.ListaLeitura.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
  public abstract class Carrinho
  {
    int IdVendedor;
    public int idDoProduto { get; set; }
    public Produto Produto { get; set; } = new Produto();
    public int Quantidade { get; set; }

    /// <summary>
    /// Metodo para obter lista de itens medidos/consumidos
    /// </summary>
    protected abstract void ObterItens();

    public void Sincronismo(List<Produto>  Items)
    {

    }
  }
}
