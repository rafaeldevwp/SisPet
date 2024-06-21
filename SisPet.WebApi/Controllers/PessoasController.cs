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
    public async Task<IEnumerable<Pessoa>> Get()
    {
        return await _pessoaService.Getall();
    }

    // GET api/<PessoaController>/5
    [HttpGet("{id}")]
    public async Task<Pessoa> Get(int id)
    {
        return await _pessoaService.GetById(id);
    }

    // POST api/<PessoaController>
    [HttpPost]
    public void Post([FromBody] PessoaDTO pessoaDTO)
    {
        if (pessoaDTO != null)
        {
            var pessoa = _mapper.Map<Pessoa>(pessoaDTO);
            _pessoaService.Add(pessoa);
        }
        return;
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
        //var pessoa? = this.Get(id);

        //if (pessoa != null)
        //    _pessoaService.Delete(pessoa.Id);
    }

}
