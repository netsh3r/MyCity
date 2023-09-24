using AutoMapper;
using Business.Model.Location;
using Business.Model.Route;
using My.City.Core.Models;

namespace Business.Map;

/// <summary>
///     Настройки маппинга
/// </summary>
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Location, LocationDto>()
            .ForMember(dest => dest.LocationType, 
                opt => opt.MapFrom(src => src.LocationType));

        CreateMap<LocationDto, Location>()
            .ForMember(dest => dest.LocationType,
                opt => opt.MapFrom(src => src.LocationType));

        CreateMap<RouteDto, Route>();
        CreateMap<Route, RouteDto>();
    }
}