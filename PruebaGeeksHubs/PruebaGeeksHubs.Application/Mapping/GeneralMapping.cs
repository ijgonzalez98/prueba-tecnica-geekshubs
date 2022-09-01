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

            CreateMap<Producto, Producto>();
            CreateMap<Producto, ProductoResponseDTO>();

            CreateMap<Compra, Compra>();
            CreateMap<Compra, CompraResponseDTO>();

            CreateMap<CompraProducto, CompraProducto>();
            CreateMap<CompraProducto, CompraProductoResponseDTO>();
        }
    }
}
