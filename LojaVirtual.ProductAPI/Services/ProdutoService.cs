using AutoMapper;
using LojaVirtual.ProductAPI.DTOs;
using LojaVirtual.ProductAPI.Models;
using LojaVirtual.ProductAPI.Repositories;
using LojaVirtual.ProductAPI.Repositories.Interfaces;
using LojaVirtual.ProductAPI.Services.Interfaces;

namespace LojaVirtual.ProductAPI.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;
        public ProdutoService(IProdutoRepository produtoRepository, IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        public async Task AddProduto(ProdutoDTO produtoDto)
        {
            var produtosEntity = _mapper.Map<Produto>(produtoDto); //Para passar para o reposeitório, precisa converter em uma entidade
            await _produtoRepository.Create(produtosEntity); //Acessa o repositório e faz o create
            produtoDto.Id = produtosEntity.Id; //Atualiza o Id do DTO com o Id da entidade
        }

        public async Task<IEnumerable<ProdutoDTO>> GetAll()
        {
            var produtosEntity = await _produtoRepository.GetAll(); //Transformando uma lista de categorias em uma lista de DTOs categorias
            return _mapper.Map<IEnumerable<ProdutoDTO>>(produtosEntity);
        }

        public async Task<ProdutoDTO> GetProdutobyId(int id)
        {
            var produtosEntity = await _produtoRepository.GetProdutobyId(id);
            return _mapper.Map<ProdutoDTO>(produtosEntity);
        }

        //public async Task<ProdutoDTO> GetProdutobyLessPrice(decimal preco)
        //{
        //    var produtosEntity = await _produtoRepository.GetProdutobyLessPrice(preco);
        //    return _mapper.Map<ProdutoDTO>(produtosEntity);
        //}

        //public async Task<ProdutoDTO> GetProdutobyPrice(decimal preco)
        //{
        //    var produtosEntity = await _produtoRepository.GetProdutobyPrice(preco);
        //    return _mapper.Map<ProdutoDTO>(produtosEntity);
        //}

        //public async Task<ProdutoDTO> GetProdutobyUpperPrice(decimal preco)
        //{
        //    var produtosEntity = await _produtoRepository.GetProdutobyUpperPrice(preco);
        //    return _mapper.Map<ProdutoDTO>(produtosEntity);
        //}

        public async Task RemoveProduto(int id)
        {
            var produtosEntity = _produtoRepository.GetProdutobyId(id).Result;
            await _produtoRepository.Delete(produtosEntity.Id);
        }

        public Task Update(ProdutoDTO produtoDto)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProduto(ProdutoDTO produtoDto)
        {
            throw new NotImplementedException();
        }
    }
}
