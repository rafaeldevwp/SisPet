using SisPet.Domain.Entidades;

namespace SisPet.Domain.Interfaces
{
    public interface IPessoaRepositorio
    {
        Task<IEnumerable<Pessoa>> Getall();
        Task<Pessoa> GetById(int id);
        void Add(Pessoa pessoa);
        void Update(Pessoa pessoa);
        void Delete(Pessoa pessoa); 
    }
}