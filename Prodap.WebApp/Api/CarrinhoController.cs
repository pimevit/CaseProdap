using Microsoft.AspNetCore.Mvc;
using Model;
using Prodap.ListaLeitura.Modelos;
using System.Collections.Generic;
using System.Linq;

namespace Api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CarrinhoController : ControllerBase
  {

    private static readonly Carrinho _repo = new Carrinho();

    [HttpPut("{idDoProduto}/{quantidade}")]
    public void VenderPicole(string idDoProduto, int quantidade)
    {
      var picole = _repo.Picole.Find(x => x.Id == idDoProduto);
      if (picole != null)
        picole.Quantidade -= quantidade;
    }

    [HttpPost("Item")]
    public void AdicionarItem(Produto item)
    {
      _repo.AdItem(item);
    }

    [HttpPost("LimparCarrinho")]
    public void LimparCarrinho()
    {
      _repo?.Picole.Clear();
    }

    [HttpGet("Total")]
    public decimal ObterQuantidaDoCarrinho()
    {
      return
        _repo.QuantidadeTotal();

    }
    [HttpGet()]
    public IActionResult ProdutosDoCarrinho()
    {
      _repo.Picole = new List<Produto>() { new Produto{ Id = "S12", Nome ="Picole", Quantidade = 13} };
      return Ok(_repo);
    }
    /*public string ver(string str)
    {
      string remover = str;

      foreach (char letras in remover)
      {
        if (!char.IsLetterOrDigit(letras))
          str = str.Replace(letras, '');
      }

      char[] letters = str.ToCharArray();
      System.Array.Reverse(letters);
      string reverseWord = new string(letters);

      if (str.ToLower() == reverseWord.ToLower())
        return bool.TrueString;
      else
        return bool.FalseString;
    }*/
  }
}
