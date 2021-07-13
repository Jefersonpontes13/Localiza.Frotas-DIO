using System;
using System.Reflection.Metadata.Ecma335;
using Localiza.Frotas.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Localiza.Frotas.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class VeiculosController : ControllerBase
    {
        private readonly IVeiculoRepository _veiculoRepository;

        public VeiculosController(IVeiculoRepository veiculoRepository)
        {
            this._veiculoRepository = veiculoRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_veiculoRepository.GetAll());
        }

        [HttpGet("id")]
        public IActionResult Get(Guid id)
        {
            var veiculo = _veiculoRepository.GetById(id);
            if (veiculo == null)
            {
                return NotFound();
            }

            return Ok(veiculo);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Veiculo veiculo)
        {
            _veiculoRepository.Add(veiculo);
            return CreatedAtAction(nameof(Get), new {id = veiculo.Id}, veiculo);
        }

        [HttpPut]
        public IActionResult Put(Guid id, [FromBody] Veiculo veiculo)
        {
            _veiculoRepository.Update(veiculo);
            return NoContent();
        }

        [HttpDelete]

        public IActionResult Delete(Guid id)
        {
            var veiculo = _veiculoRepository.GetById(id);

            if (veiculo == null)
            {
                return NotFound();
            }
            
            _veiculoRepository.Delete(veiculo);

            return NoContent();
        }
    }
}