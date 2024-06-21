using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SisPet.Application.Dto;
using SisPet.Application.Interfaces;
using SisPet.Application.Servicos;
using SisPet.Domain.Entidades;

namespace SisPet.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PessoasController : ControllerBase
{
    private readonly IPessoaService _pessoaService;
    private readonly IMapper _mapper;

    public PessoasController(IPessoaService pessoaService, IMapper mapper)
    {
        _pessoaService = pessoaService;
        _mapper = mapper;
    }

    // GET: api/<PessoaController>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Pessoa>>> GetAll()
    {
        var pessoas = await _pessoaService.Getall();

        return Ok(pessoas);
    }

    // GET api/<PessoaController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Pessoa>> Get(int id)
    {
        var pessoa = await _pessoaService.GetById(id);
        if (pessoa is null)
        {
            return NotFound();
        }

        return Ok(pessoa);
    }

    // POST api/<PessoaController>
    [HttpPost]
    public ActionResult<Pessoa> Post([FromBody] PessoaDTO pessoaDTO)
    {
        if (pessoaDTO != null)
        {
            var pessoa = _mapper.Map<Pessoa>(pessoaDTO);

            _pessoaService.Add(pessoa);
            return CreatedAtAction(nameof(Get), new { id = pessoa.Id }, pessoa);
        }

        return BadRequest();
       
    }

    // PUT api/<PessoaController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {

    }

    // DELETE api/<PessoaController>/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var pessoa = await _pessoaService.GetById(id);

        if (pessoa != null)
        {
            _pessoaService.Delete(pessoa);
            return NoContent();
        }

        return NotFound();  
           

    }

}
