using Carrefour.ProductApi.Models;

namespace Carrefour.ProductApi.Interfaces;

public interface IProductService : IDisposable
{
    Task Add(ProductModel product);
    Task Update(ProductModel product);
    Task Delete(Guid id);
}
