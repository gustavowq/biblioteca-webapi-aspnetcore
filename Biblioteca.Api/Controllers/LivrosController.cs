using Bibilioteca.Biblioteca.Api.DTOs;
using Bibilioteca.Service;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Api.Controller
{
    [ApiController]
    [Route("[Controller]")]
    public class LivrosController : ControllerBase
    {
        private readonly LivroService _service;

        public LivrosController(LivroService service) //guarda o service recebido para uso de metodos
        {
            _service = service;
        }

        [HttpPost]
        public async Task <IActionResult> CadastrarLivro(LivroCreateDto dto) // guarda dentro do objeto DTO o unico campo que deve vir do usuario
        {
          
            await _service.Cadastrar(dto); // chama o metodo de cadastro do service para evitar multiplas funções no controller
            return Ok();

        }

        [HttpGet("ObterTodos")]
        public async Task <IActionResult> ObterTodos()
        {
            var Livrosdto = await _service.ListarLivros();
            return Ok(Livrosdto);

        }

        [HttpGet("NomeLivro")]
        public async Task <IActionResult> BuscarLivro([FromQuery]LivroCreateDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Nome))
                return BadRequest("O nome do livro não pode ser nullo");

            var livroBuscado = await _service.BuscarLivro(dto);
            return Ok(livroBuscado);
        }

    }



}
