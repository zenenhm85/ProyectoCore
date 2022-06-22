using Dominio;
using MediatR;
using Persistencia;

namespace Aplicacion.Cursos
{
    public class NewCurso : IRequest
    {
        public string? Titulo { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaPublicacion { get; set; }
    }
    public class NewCursoHandle : IRequestHandler<NewCurso>
    {
        private readonly CursosOnlineContext _context;
        public NewCursoHandle(CursosOnlineContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(NewCurso request, CancellationToken cancellationToken)
        {
            var curso = new Curso
            {
                Titulo = request.Titulo,
                Descripcion = request.Descripcion,
                FechaPublicacion = request.FechaPublicacion
            };
            if (_context.Curso is not null)
            {
                _context.Curso.Add(curso);
                var result = await _context.SaveChangesAsync();
                if (result > 0)
                {
                    return Unit.Value;
                }
            }
            throw new Exception("No se pudo realizar la transacción");

        }
    }

}