using MediatR;
using Dominio;
using Persistencia;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Cursos
{
    public class ListaCursos: IRequest<List<Curso>>
    {
        
    }
    public class CursoHandler : IRequestHandler<ListaCursos, List<Curso>>
    {
        private readonly CursosOnlineContext _context;
        
        public CursoHandler(CursosOnlineContext context){
            _context = context;            
        }
        public async Task<List<Curso>> Handle(ListaCursos request, CancellationToken cancellationToken)
        {
            if (_context.Curso is not null)
            {
                var cursos = await _context.Curso.ToListAsync();
                return cursos;
            }
            return new List<Curso>();
        }
    }
}