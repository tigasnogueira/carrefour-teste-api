using AutoMapper;
using Carrefour.TransactionApi.Model;
using Carrefour.TransactionApi.ViewModels;

namespace Carrefour.TransactionApi.Configuration;

public class AutomapperConfig : Profile
{
    public AutomapperConfig()
    {
        CreateMap<TransactionModel, TransactionViewModel>().ReverseMap();
    }
}
