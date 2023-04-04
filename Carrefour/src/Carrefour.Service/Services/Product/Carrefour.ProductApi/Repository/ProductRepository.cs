using Carrefour.ProductApi.Context;
using Carrefour.ProductApi.Interfaces;
using Carrefour.ProductApi.Models;

namespace Carrefour.ProductApi.Repository;

public class ProductRepository : Repository<ProductModel>, IProductRepository
{
    public ProductRepository(MyDbContext context) : base(context)
    {
    }
}
