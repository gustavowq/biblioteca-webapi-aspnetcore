using Bibilioteca.Biblioteca.Api.DTOs;
using Bibilioteca.Service;
using Microsoft.AspNetCore.Mvc;

namespace Bibilioteca.Biblioteca.Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class EmprestimoController : ControllerBase
    {
        private readonly EmprestimoService _service;

        public EmprestimoController(EmprestimoService service)
        {
            _service = service;
        }
        [HttpPost]
        public  async Task <IActionResult> GerarEmprestimo (EmprestimoCreateDto dto) // validar os dados recebidos, verificando o banco 
        {
            if (dto == null)
                return BadRequest("Os campos não podem ser nulos");

            await _service.GerarEmprestimo(dto);

            return Ok("Emprestimo concluido");


        }

        [HttpPatch("{id}/devolução")]
        public async Task <IActionResult> DevolverEmprestimo(int  id)
        {
            await _service.Devolver(id);
            return Ok("Devolução bem sucedida");
        }

    }

}
