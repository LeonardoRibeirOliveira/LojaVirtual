using LojaVirtual.ProductAPI.DTOs;
using LojaVirtual.ProductAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaVirtual.ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoaService)
        {
            _produtoService = produtoaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoDTO>>> Get()
        {
            var produtoDto = await _produtoService.GetAll();
            if (produtoDto == null)
            {
                return NotFound("Sem produtos cadastrados.");
            }
            return Ok(produtoDto);
        }

        [HttpGet("{id:int}", Name = "GetProduto")]
        public async Task<ActionResult<ProdutoDTO>> GetProduto(int id)
        {
            var produtoDto = await _produtoService.GetProdutobyId(id);
            if (produtoDto == null)
            {
                return NotFound("Produto não cadastrada.");
            }
            return Ok(produtoDto);
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoDTO>> Post([FromBody] ProdutoDTO produtoDto)
        {
            if (produtoDto == null)
            {
                return NotFound("Produto inválida");
            }
            await _produtoService.AddProduto(produtoDto);
            return new CreatedAtRouteResult("GetCategoria", new { id = produtoDto.Id }, produtoDto); //Retorna a categoria incluida para o usuário
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ProdutoDTO>> Put(int id, [FromBody] ProdutoDTO produtoDto)
        {
            if (id != produtoDto.CategoriaId)
            {
                return BadRequest();
            }
            else if (produtoDto == null)
            {
                return NotFound("Produto não cadastrado.");
            }
            await _produtoService.UpdateProduto(produtoDto);
            return Ok(produtoDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ProdutoDTO>> Delete(int id)
        {
            var categoriaDto = await _produtoService.GetProdutobyId(id);
            if (categoriaDto == null)
            {
                return NotFound("Produto não cadastrado.");
            }
            await _produtoService.RemoveProduto(id);
            return Ok(categoriaDto);
        }
    }
}
