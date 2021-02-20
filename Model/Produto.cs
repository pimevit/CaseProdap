using System;
using System.ComponentModel.DataAnnotations;

namespace Prodap.ListaLeitura.Modelos
{
  public class Produto
  {
    public string Id { get; set; }
    [Required]
    public string Nome { get; set; }
    public string Descicao { get; set; }
    public decimal Quantidade { get; set; }
    public decimal QuantidadeRetirada { get; set; }
    public DateTime Validade { get; set; }
    public byte[] ImagemCapa { get; set; }

    public void ValidarAlteracao()
    {
      Quantidade -= QuantidadeRetirada;
    }
  }
}
