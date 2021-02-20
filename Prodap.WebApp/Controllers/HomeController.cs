using Prodap.ListaLeitura.Persistencia;
using Prodap.ListaLeitura.Modelos;
using Prodap.ListaLeitura.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Alura.ListaLeitura.WebApp.Controllers
{
  [Authorize]
  public class HomeController : Controller
  {
    private readonly IRepository<Produto> _repo;

    public HomeController(IRepository<Produto> repository)
    {
      _repo = repository;
    }

    private IEnumerable<Produto> ListaProduto()
    {
      return _repo.All;
    
    }
    public IActionResult Index()
    {
      var model = new HomeViewModel
      {
        ComVendedores = ListaProdutoSairamParaVenda(),
        Produtos = ListaProduto(),
        Estoque = ListaProdutoQuantidadeEstoque()
      };
      return View(model);
    }

    private IEnumerable<Produto> ListaProdutoQuantidadeEstoque()
    {
      return _repo.All.Where(x => x.QuantidadeRetirada < x.Quantidade);
    }

    private IEnumerable<Produto> ListaProdutoSairamParaVenda()
    {
      return _repo.All.Where(x => x.QuantidadeRetirada > 0);
    }
  }
}