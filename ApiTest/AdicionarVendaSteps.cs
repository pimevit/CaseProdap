using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;


namespace ApiTest
{
  [Binding]
  public class AdicionarVendaSteps
  {
    public HttpClient HttpClient { get; set; }

    [BeforeScenario]
    public void Setup()
    {
      HttpClient = new HttpClient();
    }


    [Given(@"carrinho está vazio")]
    public async Task GivenCarrinhoEstaVazio()
    {
      await HttpClient.PostAsync($"http://localhost:59206/api/Carrinho/LimparCarrinho", null);
    }

    [When(@"adicionar (.*) do produto (.*) no carrinho")]
    public async Task WhenAdicionarDoProdutoNoCarrinho(int quantidade, string Id)
    {
      string nome = "Frutare";
      object data = new { Id, quantidade, nome};

      StringContent stringContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

      await HttpClient.PostAsync($"http://localhost:59206/api/Carrinho/Item", stringContent);
    }

    [When(@"vender (.*) do produto (.*) do carrinho")]
    public async Task WhenVenderDoProdutoDoCarrinho(int quantidade, string idDoProduto)
    {
      await HttpClient.PutAsync($"http://localhost:59206/api/Carrinho/{idDoProduto}/{quantidade}", null);
    }

    [When(@"sincronizar venda")]
    public async Task WhenSincronizarVenda()
    {
      string IdProduto = "S1523";
      int IdVendedor = 1;
      decimal Quantidade = 5;
      DateTime DataVenda = DateTime.Now;
      object data = new { IdProduto, IdVendedor, Quantidade, DataVenda };

      StringContent stringContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
      await HttpClient.PostAsync($"http://localhost:59206/Sincronismo/", stringContent);
     }

    [Then(@"a quantidade do carrinho deve ser (.*)")]
    public async Task ThenAQuantidadeDoCarrinhoDeveSer(int qtde)
    {
      var response = await HttpClient.GetAsync($"http://localhost:59206/api/Carrinho/Total");

      var content = await response.Content.ReadAsStringAsync();

      decimal total = Convert.ToDecimal(content);

      Assert.AreEqual(qtde, total);
    }
  }
}
