using Dapper;
using MySqlConnector;
using ProjetoWeb3_Service.Entity;
using ProjetoWeb3_Service.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoWeb3_Infra.Data.Repository
{
    public class CityEventRepository : ICityEventRepository
    {

        private string _stringConnection { get; set; }

        public CityEventRepository()
        {
            _stringConnection = Environment.GetEnvironmentVariable("DATABASE_CONFIG");
        }


        //Inclusão de um novo evento; *Autenticação e Autorização admin
        //Edição de um evento existente, filtrando por id; *Autenticação e Autorização admin
        //Remoção de um evento, caso o mesmo não possua reservas em andamento, caso possua inative-o; *Autenticação e Autorização admin
        //Consulta por título, utilizando similaridades, por exemplo, caso pesquise Show, traga todos os eventos que possuem a palavra Show no título;
        //Consulta por local e data;
        //Consulta por range de preço e a data;

        public bool InsertCityEvent(CityEvent cityEvent)
        {
            string query = "INSERT INTO CityEvent (title, description, dateHourEvent, local, address, price, status)" +
                "VALUES (@title, @description, @dateHourEvent, @local, @address, @price, @status)";

            DynamicParameters parameters = new(cityEvent);

            using MySqlConnection conn = new(_stringConnection);

            int afectedLines = conn.Execute(query, parameters);

            return afectedLines > 0;
        }



        public bool UpdateCityEvent(CityEvent cityEvent)
        {
            string query = "UPDATE CityEvent SET title = @title, description = @description, dateHourEvent = @dateHourEvent, local = @local, address = @address, price =  @price, status = @status where idEvent = @idEvent";

            DynamicParameters parameters =  new(cityEvent);

            using MySqlConnection conn = new(_stringConnection);

            int afectedLines = conn.Execute(query, parameters);

            return afectedLines > 0;

        }


        public bool DeleteCityEvent(long idEvent)
        {
            string query = "DELETE FROM CityEvent WHERE idEvent = @idEvent";

            var parameters = new DynamicParameters(new
            {
                idEvent
            });
            try
            {
                using MySqlConnection conn = new(_stringConnection);

                int afectedLines = conn.Execute(query, parameters);

                return afectedLines > 0;
            }
            catch
            {
                Console.WriteLine($"Erro ao comunicar com o banco");
                throw;
            }


        }


        public List<CityEvent> SelectEvents()
        {
            var query = "SELECT * FROM CityEvent";
            using MySqlConnection conn = new(_stringConnection);

            try
            {

                return conn.Query<CityEvent>(query).ToList();
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Erro ao comunicar com o banco, mensagem {ex.Message}, stack trace {ex.StackTrace}");
                throw;
            }

        }


        public List<CityEvent> SelectEventsByTitle(string title)
        {

            var query = $"SELECT * FROM CityEvent WHERE Title LIKE ('%' +  @Title + '%') ";
            var parameters = new DynamicParameters(new
            {
                title
            });

            try
            {
                using MySqlConnection conn = new(_stringConnection);
                return conn.Query<CityEvent>(query, parameters).ToList();
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Erro ao comunicar com o banco, mensagem {ex.Message}, stack trace {ex.StackTrace}");
                throw;
            }
        }


        public List<CityEvent> SelectEventsByDateAndLocal(DateTime dateHourEvent, string local)
        {

            var query = $"SELECT * FROM CityEvent WHERE CONVERT(DATE, DateHourEvent)= @DateHourEvent AND Local Like('%' +  @Local + '%') ";
            var parameters = new DynamicParameters(new
            {
                dateHourEvent,
                local
            });

            try
            {
                using MySqlConnection conn = new(_stringConnection);
                return conn.Query<CityEvent>(query, parameters).ToList();
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Erro ao comunicar com o banco, mensagem {ex.Message}, stack trace {ex.StackTrace}");
                throw;
            }
        }




        public List<CityEvent> SelectEventsByPriceAndDate(decimal low, decimal high, DateTime dateHourEvent)
        {

            var query = $"SELECT * FROM CityEvent WHERE Price >= @low AND Price <= @high AND CONVERT(DATE, DateHourEvent)= @DateHourEvent";
            var parameters = new DynamicParameters(new
            {
                low,
                high,
                dateHourEvent
            });

            try
            {
                using MySqlConnection conn = new(_stringConnection);
                return conn.Query<CityEvent>(query, parameters).ToList();
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Erro ao comunicar com o banco, mensagem {ex.Message}, stack trace {ex.StackTrace}");
                throw;
            }
        }



    }
}
