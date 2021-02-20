using System.IO;
using Microsoft.AspNetCore.Http;

namespace Prodap.ListaLeitura.Modelos
{
  public static class ProdutosExtensions
  {
    public static byte[] ConvertToBytes(this IFormFile image)
    {
      if (image == null)
      {
        return null;
      }
      using (var inputStream = image.OpenReadStream())
      using (var stream = new MemoryStream())
      {
        inputStream.CopyTo(stream);
        return stream.ToArray();
      }
    }
   
  }
}
