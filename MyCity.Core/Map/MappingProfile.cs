using MyCity.Core.Models;

namespace MyCity.Api.Map;

using AutoMapper;

/// <summary>
///     Настройки маппинга
/// </summary>
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<DataAccess.Entities.Location, LocationDto>().ReverseMap();
    }
}