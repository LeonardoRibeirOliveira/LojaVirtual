using LojaVirtual.ProductAPI.DTOs;
using LojaVirtual.ProductAPI.Repositories.Interfaces;
using LojaVirtual.ProductAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaVirtual.ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> Get()
        {
            var categoriaDto = await _categoriaService.GetAll();
            if (categoriaDto == null)
            {
                return NotFound("Sem categorias cadastradas.");
            }
            return Ok(categoriaDto);
        }

        [HttpGet("Produtos")]
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> GetCategoriasProdutos()
        {
            var categoriaDto = await _categoriaService.GetCategoriasProdutos();
            if (categoriaDto == null)
            {
                return NotFound("Sem produtos cadastrados.");
            }
            return Ok(categoriaDto);
        }

        [HttpGet("{id:int}", Name = "GetCategoria")]
        public async Task<ActionResult<CategoriaDTO>> GetCategoria(int id)
        {
            var categoriaDto = await _categoriaService.GetCategoriasbyId(id);
            if (categoriaDto == null)
            {
                return NotFound("Categoria não cadastrada.");
            }
            return Ok(categoriaDto);
        }

        [HttpPost]
        public async Task<ActionResult<CategoriaDTO>> Post([FromBody] CategoriaDTO categoriaDto)
        {
            if (categoriaDto == null)
            {
                return NotFound("Categoria inválida");
            }
            await _categoriaService.AddCategoria(categoriaDto);
            return new CreatedAtRouteResult("GetCategoria", new { id = categoriaDto.CategoriaId }, categoriaDto); //Retorna a categoria incluida para o usuário
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<CategoriaDTO>> Put(int id, [FromBody] CategoriaDTO categoriaDto)
        {
            if (id != categoriaDto.CategoriaId)
            {
                return BadRequest();
            }
            else if (categoriaDto == null)
            {
                return NotFound("Categoria não cadastrada.");
            }
            await _categoriaService.Updatecategoria(categoriaDto);
            return Ok(categoriaDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CategoriaDTO>> Delete(int id)
        {
            var categoriaDto = await _categoriaService.GetCategoriasbyId(id);
            if (categoriaDto == null)
            {
                return NotFound("Categoria não cadastrada.");
            }
            await _categoriaService.RemoveCategoria(id);
            return Ok(categoriaDto);
        }
    }
}
