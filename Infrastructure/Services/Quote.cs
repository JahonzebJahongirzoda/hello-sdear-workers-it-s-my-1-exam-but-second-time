using Dapper;
using Domain.Entities;
using Npgsql;


namespace Infrastructure.Services;
public class QuoteServices
{
    private string _connectionString;
    public QuoteServices()
    {
        _connectionString = "Server=127.0.0.1;Port=5432;Database=15.09.2022;User Id=postgres;Password=11111111;";
    }



    public async Task<List<Quote>> GetQuote()
    {
        using (var connection = new NpgsqlConnection(_connectionString))

        {
            var sql = "Select * from Quote";
            var res = await connection.QueryAsync<Quote>(sql);
            return res.ToList();
        }
    }







    public async Task<List<Quote>> Getbyrand()
    {
        using (var connection = new NpgsqlConnection(_connectionString))

        {
            var sql = "select * from Quote order by random() limit 1";
            var res = await connection.QueryAsync<Quote>(sql);
            return res.ToList();
        }
    }









    public async Task<int> UpdateQuote(Quote quote)
    {

        using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
        {

            string sql = $"UPDATE Quote SET author = '{quote.Author}', quotetext = '{quote.QuoteText}', categoryid = '{quote.Categoryid}' WHERE id = '{quote.id}'; ";
            var response = await connection.ExecuteAsync(sql);
            return response;
        }

    }








    public async Task<int> DeleteQuote(int id)
    {

        using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
        {

            string sql = $"delete from quote where id ={id}";
            var response = await connection.ExecuteAsync(sql);
            return response;
        }

    }







    public async Task<List<Quote>> Getbyid(int id)
    {

        using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
        {

            string sql = $"select * from quote where quote.CategoryId ={id}";
            var response = await connection.QueryAsync<Quote>(sql);
            return response.ToList();
        }

    }






}

