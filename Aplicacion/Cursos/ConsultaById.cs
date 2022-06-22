using Dominio;
using MediatR;
using Persistencia;

namespace Aplicacion.Cursos
{
    public class ConsultaById:IRequest<Curso>
    {
        public int Id {get; set;}
                
    }
    public class HandleConsultaById : IRequestHandler<ConsultaById, Curso>
    {
        private readonly CursosOnlineContext _context;
        public HandleConsultaById(CursosOnlineContext context){
            _context = context;
        }
        public async Task<Curso> Handle(ConsultaById request, CancellationToken cancellationToken)
        {
             if (_context.Curso is not null)
            {
                var curso = await _context.Curso.FindAsync(request.Id);
                return curso is not null ? curso : new Curso();
            }
            return new Curso();
        }
    }
}