using LojaVirtual.Cadastro.Application.Categorias.Obter.Servicos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.WebApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ICategoriaAplicacaoObterServico _categoriaAplicacaoServicoObter;

        public WeatherForecastController(ICategoriaAplicacaoObterServico categoriaAplicacaoServicoObter)
        {
            _categoriaAplicacaoServicoObter = categoriaAplicacaoServicoObter;
        }

        [HttpGet]
        [Route("obter-categorias")]
        public async Task<IActionResult> Index()
        {
            return Ok(await _categoriaAplicacaoServicoObter.ObterTodos());
        }

        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}
    }
}
