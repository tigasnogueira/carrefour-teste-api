using AutoMapper;
using Carrefour.ProductApi.Models;
using Carrefour.ProductApi.ViewModels;

namespace Carrefour.ProductApi.Configuration;

public class AutomapperConfig : Profile
{
    public AutomapperConfig()
    {
        CreateMap<ProductModel, ProductViewModel>().ReverseMap();
    }
}
