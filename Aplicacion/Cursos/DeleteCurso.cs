using MediatR;
using Persistencia;

namespace Aplicacion.Cursos
{
    public class DeleteCurso : IRequest
    {
        public int Id { get; set; }
    }
    public class HandleDeleteCurso : IRequestHandler<DeleteCurso>
    {
          private readonly CursosOnlineContext _context;
        public HandleDeleteCurso(CursosOnlineContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteCurso request, CancellationToken cancellationToken)
        {
            if (_context.Curso is not null)
            {
                var curso = await _context.Curso.FindAsync(request.Id);
                if (curso == null)
                {
                    throw new Exception("El curso para este Id no existe");
                }
                _context.Remove(curso);
                
                var result = await _context.SaveChangesAsync();
                if (result > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se eliminó el curso");
            }
            throw new Exception("El curso es null en este contexto");
        }
    }
}