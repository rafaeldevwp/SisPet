using Dapper;
using SisPet.Domain.Entidades;
using SisPet.Domain.Interfaces;
using System.Data;

namespace SisPet.Infra.PessoaRepositorio
{
    public class PessoaRepositorio : IPessoaRepositorio
    {
        private readonly IDbConnection _dbConnection;

        public PessoaRepositorio(IDbConnection dbConnection)
        {
           _dbConnection = dbConnection;
        }

        public void Add(Pessoa pessoa)
        {
            string query = "INSERT INTO Pessoa (Nome,Idade,Email) Values (@Nome, @Idade, @Email)";
            var parametros = new DynamicParameters();

            parametros.Add("Nome", pessoa.Nome);
            parametros.Add("Idade", pessoa.Idade);
            parametros.Add("Email", pessoa.Email);

            _dbConnection.Execute(query, parametros);
        }

        public void Delete(Pessoa pessoa)
        {
            string query = "DELETE FROM Pessoas Where Id = @Id";
           
            var parametros = new DynamicParameters();
            parametros.Add("Id", pessoa.Id);

            _dbConnection.Execute(query, parametros);

        }

        public async Task<IEnumerable<Pessoa>> Getall()
        {
            string query = "SELECT * FROM Pessoa";
            return await _dbConnection.QueryAsync<Pessoa>(query);
        }

        public async Task<Pessoa> GetById(int id)
        {
            string query = "SELECT * FROM Pessoas WHERE Id = @Id";

            var parametros = new DynamicParameters();
            parametros.Add("Id", id);

            return await _dbConnection.QueryFirstAsync<Pessoa>(query, parametros);

        }

        public void Update(Pessoa pessoa)
        {
            string query = "UPDATE Pessoa SET Nome = @Nome, Idade = @Idade, Email = @Email";

            var parametros = new DynamicParameters();
            parametros.Add("Nome", pessoa.Nome);
            parametros.Add("Idade", pessoa.Idade);
            parametros.Add("Email", pessoa.Email);

            _dbConnection.Execute(query, parametros);
        }
    }
}
