using AutoMapper;
using PruebaGeeksHubs.Application.DTOs.Responses;
using PruebaGeeksHubs.Domain.Entities;

namespace PruebaGeeksHubs.Application.Mapping
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Categorium, Categorium>();
            CreateMap<Categorium, CategoriaResponseDTO>();

            CreateMap<Cliente, Cliente>();
            CreateMap<Cliente, ClienteResponseDTO>();
        }
    }
}
