using Carrefour.Domain.Interfaces;
using Carrefour.Domain.Service;
using Carrefour.ProductApi.Interfaces;
using Carrefour.ProductApi.Models;

namespace Carrefour.ProductApi.Services;

public class ProductService : BaseService, IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository, INotifier notifier) : base(notifier)
    {
        _productRepository = productRepository;
    }

    public async Task Add(ProductModel product)
    {
        //if (!ExecutarValidacao(new ProdutoValidation(), produto)) return;
        await _productRepository.Add(product);
    }

    public async Task Update(ProductModel product)
    {
        //if (!ExecutarValidacao(new ProdutoValidation(), produto)) return;

        await _productRepository.Update(product);
    }

    public async Task Delete(Guid id)
    {
        await _productRepository.Delete(id);
    }

    public void Dispose()
    {
        _productRepository?.Dispose();
    }
}
