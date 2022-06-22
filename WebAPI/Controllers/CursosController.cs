using Aplicacion.Cursos;
using Dominio;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CursosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Curso>>> Get()
        {

            return await _mediator.Send(new ListaCursos());

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Curso>> GetDetailsByCurso(int id)
        {
            return await _mediator.Send(new ConsultaById { Id = id });
        }
        [HttpPost]
        public async Task<ActionResult<Unit>> NewCurso(NewCurso data)
        {
            return await _mediator.Send(data);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> UpdateCurso(int id, UpdateCurso data)
        {
            data.CursoId = id;
            return await _mediator.Send(data);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> DeleteCurso(int id)
        {
            return await _mediator.Send(new DeleteCurso { Id = id });
        }

    }
}