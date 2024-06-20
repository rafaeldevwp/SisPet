using Microsoft.AspNetCore.Mvc;
using SisPet.Application.Servicos;
using SisPet.Domain.Entidades;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SisPet.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {

        private readonly PessoaService _pessoaService;

        public PessoaController(PessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        // GET: api/<PessoaController>
        [HttpGet]
        public async Task<IEnumerable<Pessoa>> Get()
        {
           return await  _pessoaService.Getall();
        }

        // GET api/<PessoaController>/5
        [HttpGet("{id}")]
        public async Task<Pessoa> Get(int id)
        {
            return await _pessoaService.GetById(id);
        }

        // POST api/<PessoaController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PessoaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/<PessoaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var pessoa = this.Get(id);

            if (pessoa is not null)
                  _pessoaService.Delete(pessoa.Id);

           
        }
    }
}
