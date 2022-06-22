using Dominio;
using Microsoft.AspNetCore.Mvc;
using Persistencia;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly CursosOnlineContext context;
    public WeatherForecastController(CursosOnlineContext _context)
    {
        this.context = _context;
    }


    [HttpGet]
    public IEnumerable<Curso> Get()
    {
        if (context.Curso is not null)
        {
            return context.Curso.ToList();
        }
        return new List<Curso>();
    }
}
