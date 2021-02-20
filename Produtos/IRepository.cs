using System.Linq;

namespace Prodap.ListaLeitura.Persistencia
{
  public interface IRepository<TEntity> where TEntity : class
  {
    IQueryable<TEntity> All { get; }
    TEntity Find(int key);
    
    TEntity Find(string key);

    void Incluir(params TEntity[] obj);
    void Alterar(params TEntity[] obj);
    void Excluir(params TEntity[] obj);
  }
}
