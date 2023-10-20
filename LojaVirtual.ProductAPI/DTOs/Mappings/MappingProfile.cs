using AutoMapper;
using LojaVirtual.ProductAPI.Models;

namespace LojaVirtual.ProductAPI.DTOs.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
            CreateMap<Produto, ProdutoDTO>().ReverseMap();
        }
    } 
}
