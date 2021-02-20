using System.Linq;
using Prodap.ListaLeitura.Persistencia;
using Prodap.ListaLeitura.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Alura.ListaLeitura.WebApp.Controllers
{
  [Authorize]
  public class ProdutoController : Controller
  {
    private readonly IRepository<Produto> _repo;

    public ProdutoController(IRepository<Produto> repository)
    {
      _repo = repository;
    }

    [HttpGet]
    public IActionResult Novo()
    {
      return View(new Produto());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Novo(Produto model)
    {
      if (ModelState.IsValid)
      {
       _repo.Incluir(model);
        return RedirectToAction("Index", "Home");
      }
      return View(model);
    }

    [HttpGet]
    public IActionResult ImagemCapa(int id)
    {
      byte[] img = _repo.All
          .Where(l => l.Id == id.ToString())
          .Select(l => l.ImagemCapa)
          .FirstOrDefault();
      if (img != null)
      {
        return File(img, "image/png");
      }
      return File("~/images/picole.png", "image/png");
    }

    [HttpGet]
    public IActionResult Detalhes(string id)
    {
      var model = _repo.Find(id);
      if (model == null)
      {
        return NotFound();
      }
      return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Detalhes(Produto model)
    {
      if (ModelState.IsValid)
      {
        
        if (model.ImagemCapa == null)
        {
          model.ImagemCapa = _repo.All
              .Where(l => l.Id == model.Id.ToString())
              .Select(l => l.ImagemCapa)
              .FirstOrDefault();
        }
        model.ValidarAlteracao();
        _repo.Alterar(model);
        return RedirectToAction("Index", "Home");
      }
      return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Remover(int id)
    {
      var model = _repo.Find(id);
      if (model == null)
      {
        return NotFound();
      }
      _repo.Excluir(model);
      return RedirectToAction("Index", "Home");
    }
  }
}