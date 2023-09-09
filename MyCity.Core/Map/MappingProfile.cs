using MyCity.Core.Models;
using MyCity.DataAccess.Entities;

namespace MyCity.Api.Map;

using AutoMapper;

/// <summary>
///     Настройки маппинга
/// </summary>
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<DataAccess.Entities.Location, LocationDto>()
            .ForMember(dest => dest.LocationType, 
                opt => opt.MapFrom(src => src.LocationType));

        CreateMap<LocationDto, Location>()
            .ForMember(dest => dest.LocationType,
                opt => opt.MapFrom(src => src.LocationType));
    }
}