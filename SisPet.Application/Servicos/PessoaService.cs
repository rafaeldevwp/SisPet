using SisPet.Application.Interfaces;
using SisPet.Domain.Entidades;
using SisPet.Domain.Interfaces;

namespace SisPet.Application.Servicos
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepositorio _pessoaRepositorio;

        public PessoaService(IPessoaRepositorio pessoaRepositorio)
        {
            _pessoaRepositorio = pessoaRepositorio;
        }

        public void Add(Pessoa pessoa)
        {
           _pessoaRepositorio.Add(pessoa);
        }

        public void Delete(Pessoa pessoa)
        {
            _pessoaRepositorio.Delete(pessoa);

        }

        public async Task<IEnumerable<Pessoa>> Getall()
        {
            return await _pessoaRepositorio.Getall();

        }

        public async Task<Pessoa> GetById(int id)
        {
           return await _pessoaRepositorio.GetById(id);
        }

        public void Update(Pessoa pessoa)
        {
            _pessoaRepositorio.Update(pessoa);
        }
    }
}