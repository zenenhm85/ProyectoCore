using MediatR;
using Persistencia;

namespace Aplicacion.Cursos
{
    public class UpdateCurso : IRequest
    {
        public int CursoId { get; set; }
        public string? Titulo { get; set; }
        public string? Descripcion { get; set; }
        public DateTime? FechaPublicacion { get; set; }
        public byte[]? FotoPortada { get; set; }

    }
    public class UpdateCursoHandle : IRequestHandler<UpdateCurso>
    {
        private readonly CursosOnlineContext _context;
        public UpdateCursoHandle(CursosOnlineContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(UpdateCurso request, CancellationToken cancellationToken)
        {
            if (_context.Curso is not null)
            {
                var curso = await _context.Curso.FindAsync(request.CursoId);
                if (curso == null)
                {
                    throw new Exception("El curso para este Id no existe");
                }
                curso.Titulo = request.Titulo ?? curso.Titulo;
                curso.Descripcion = request.Descripcion ?? curso.Descripcion;
                curso.FechaPublicacion = request.FechaPublicacion ?? curso.FechaPublicacion;
                curso.FotoPortada = request.FotoPortada ?? curso.FotoPortada;
                
                var result = await _context.SaveChangesAsync();
                if (result > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se guardaron los campos");
            }
            throw new Exception("El curso es null en este contexto");

        }
    }
}