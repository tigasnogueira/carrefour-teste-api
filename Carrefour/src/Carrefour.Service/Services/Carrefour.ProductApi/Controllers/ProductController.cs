using AutoMapper;
using Carrefour.Domain.Interfaces;
using Carrefour.ProductApi.Interfaces;
using Carrefour.ProductApi.Models;
using Carrefour.ProductApi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Carrefour.ProductApi.Controllers;

[Route("api/Products")]
public class ProductController : MainController
{
    public readonly IProductRepository _repository;
    public readonly IProductService _service;
    public IMapper _mapper;

    public ProductController(IProductRepository productRepository, IProductService productService,
        IMapper mapper, INotifier notifier) : base(notifier)
    {
        _repository = productRepository;
        _service = productService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<ProductViewModel>> GetAll()
    {
        var product = _mapper.Map<IEnumerable<ProductViewModel>>(await _repository.GetAll());
        return product;
    }


    [HttpGet("{id:guid}")]
    // [Authorize]
    public async Task<ActionResult<ProductViewModel>> GetById(Guid id)
    {
        var product = _mapper.Map<ProductViewModel>(await _repository.GetById(id));
        if (product == null) return NotFound();
        return product;
    }


    [HttpPost]
    public async Task<ActionResult<ProductViewModel>> Add(ProductViewModel product)
    {
        if (!ModelState.IsValid) return CostumResponse(ModelState);
        await _repository.Add(_mapper.Map<ProductModel>(product));
        return CostumResponse(product);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<ProductViewModel>> Update(Guid id, ProductViewModel product)
    {
        if (id != product.Id)
        {
            NotifyError("O id informado não é o mesmo que foi passado na query");
            return CostumResponse(product);
        }

        if (!ModelState.IsValid) return CostumResponse(ModelState);

        await _service.Update(_mapper.Map<ProductModel>(product));

        return CostumResponse(product);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<ProductViewModel>> Delete(Guid id)
    {
        var productViewModel = await _repository.GetById(id);


        if (productViewModel == null) return NotFound();

        await _repository.Delete(id);

        return CostumResponse(productViewModel);
    }
}
