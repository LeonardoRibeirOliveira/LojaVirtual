using AutoMapper;
using LojaVirtual.ProductAPI.DTOs;
using LojaVirtual.ProductAPI.Models;
using LojaVirtual.ProductAPI.Repositories;
using LojaVirtual.ProductAPI.Repositories.Interfaces;
using LojaVirtual.ProductAPI.Services.Interfaces;

namespace LojaVirtual.ProductAPI.Services
{
    public class CategoriaService : ICategoriaService //Classe usada para acessar os dados e fazer o mapeamento
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;

        public CategoriaService(ICategoriaRepository categoriaRepository, IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        public async Task AddCategoria(CategoriaDTO categoriaDto)
        {
            var categoriasEntity = _mapper.Map<Categoria>(categoriaDto); //Para passar para o reposeitório, precisa converter em uma entidade
            await _categoriaRepository.Create(categoriasEntity); //Acessa o repositório e faz o create
            categoriaDto.CategoriaId = categoriasEntity.CategoriaId; //Atualiza o Id do DTO com o Id da entidade
        }

        public async Task<IEnumerable<CategoriaDTO>> GetAll()
        {
            var categoriasEntity = await _categoriaRepository.GetAll(); //Transformando uma lista de categorias em uma lista de DTOs categorias
            return _mapper.Map<IEnumerable<CategoriaDTO>>(categoriasEntity);
        }

        public async Task<CategoriaDTO> GetCategoriasbyId(int id)
        {
            var categoriasEntity = await _categoriaRepository.GetCategoriasbyId(id);
            return _mapper.Map<CategoriaDTO>(categoriasEntity);
        }

        public async Task<IEnumerable<CategoriaDTO>> GetCategoriasProdutos()
        {
            var categoriasEntity = await _categoriaRepository.GetCategoriasProdutos(); //Transformando uma lista de categorias em uma lista de DTOs categorias
            return _mapper.Map<IEnumerable<CategoriaDTO>>(categoriasEntity);
        }

        public async Task RemoveCategoria(int id)
        {
            var categoriasEntity = _categoriaRepository.GetCategoriasbyId(id).Result;
            await _categoriaRepository.Delete(categoriasEntity.CategoriaId);
        }

        public async Task Updatecategoria(CategoriaDTO categoriaDto)
        {
            var categoriasEntity = _mapper.Map<Categoria>(categoriaDto); //Para passar para o reposeitório, precisa converter em uma entidade
            await _categoriaRepository.Update(categoriasEntity); //Acessa o repositório e faz o create
        }
    }
}
