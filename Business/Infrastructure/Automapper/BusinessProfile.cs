using AutoMapper;
using Client.Responses;
using Domain;

namespace Business.Infrastructure.Automapper;

public class BusinessProfile : Profile
{
    public BusinessProfile()
    {
        CreateMap<Currency, CurrencyInfo>().ReverseMap();
    }
}