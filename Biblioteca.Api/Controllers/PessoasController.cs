using Bibilioteca.Biblioteca.Api.DTOs;
using Bibilioteca.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bibilioteca.Biblioteca.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasController : ControllerBase
    {
        private readonly PessoaService _service;

        public PessoasController(PessoaService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarPessoa(PessoaCreateDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Nome))
                return BadRequest("O nome não pode ser nulo");

            try
            {

                await _service.Cadastrar(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("EmailPessoa")]
        public async Task <IActionResult> BuscarPessoa([FromQuery]PessoaCreateDto dto) 
        {
            if (string.IsNullOrWhiteSpace(dto.Email))
                return BadRequest("O nome não pode ser nulo");

            var pessoa = await _service.BuscarPessoa(dto);
            return Ok(pessoa);
        }


    }
}
