using System.Reflection.Metadata.Ecma335;
using Localiza.Frotas.Infra.Singleton;
using Microsoft.AspNetCore.Mvc;

namespace Localiza.Frotas.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SingletonController : ControllerBase
    {
        private readonly SingletonContainer _singletonContainer;

        public SingletonController(SingletonContainer singletonContainer)
        {
            _singletonContainer = singletonContainer;
        }

        //public SingletonContainer SingletonContainer { get; }

        // GET api/v1/<VeiculosController>/5
        [HttpGet()]
        public IActionResult Get()
        {
            return Ok(_singletonContainer);
        }
    }
}