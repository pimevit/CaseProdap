﻿using Microsoft.AspNetCore.Mvc;
using Prodap.ListaLeitura.Modelos;
using Prodap.ListaLeitura.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prodap.WebApp.Api
{
  [ApiController]
  [Route("[controller]")]
  public class SincronismoController : ControllerBase
  {
    private readonly IRepository<Vendas> _repo;

    public SincronismoController(IRepository<Vendas> repository)
    {
      _repo = repository;
    }

    [HttpGet]
    public IActionResult ListaDePicole()
    {
      var lista = _repo.All;
      return Ok(lista);
    }

    [HttpGet("{id}")]
    public IActionResult Recuperar(int id)
    {
      var model = _repo.Find(id);
      if (model == null)
      {
        return NotFound();
      }
      return Ok(model);
    }

    [HttpPost]
    public async Task<IActionResult> Incluir([FromBody] Vendas model)
    {
      if (ModelState.IsValid)
      {
        _repo.Incluir(model);
        var uri = Url.Action("Recuperar", new { id = model.Id });
        return Created(uri, model); //201
        
      }
      return BadRequest();
    }
    [HttpPost("Lista")]
    public IActionResult IncluirLista([FromBody] List<Vendas> models)
    {
      if (ModelState.IsValid)
      {
        //models.ForEach(model => _repo.Incluir(model));
        models.FindAll(qtde=> qtde.Quantidade > 0)
          .AsParallel()
          .ForAll(model=> _repo.Incluir(model));

        var uri = Url.Action("Recuperar", new { id = models.Count });
        return Created(uri, models); //201
      }
      return BadRequest();
    }
  }
}
