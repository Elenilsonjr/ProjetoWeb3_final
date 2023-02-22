using Dapper;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using ProjetoWeb3_Service.Entity;
using ProjetoWeb3_Service.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoWeb3_Infra.Data.Repository
{
    public class EventReservationRepository : IEventReservationRepository
    {

        private string _stringConnection { get; set; }

        public EventReservationRepository()
        {
            _stringConnection = Environment.GetEnvironmentVariable("DATABASE_CONFIG");
        }

        //private readonly IConfiguration _configuration;

        //public EventReservationRepository(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}


        public List<EventReservation> SelectReservation()
        {
            var query = "SELECT*FROM EventReservation";

            try
            {
                using MySqlConnection conn = new(_stringConnection);
                return conn.Query<EventReservation>(query).ToList();
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Erro ao comunicar com banco, mensagem {ex.Message}, stack trace {ex.StackTrace}");
                throw;
            }
        }

        public List<EventReservation> SelectReservationByPersonNameAndTitle(string personName, string title)
        {
            var query = @$"SELECT * FROM EventReservation e INNER JOIN CityEvent c ON
                        e.PersonName = @PersonName AND c.Title LIKE ('%' + @Title + '%')
                        WHERE e.IdEvent = c.IdEvent";

            var parameters = new DynamicParameters(new
            {
                title,
                personName
            });
            try
            {
                using MySqlConnection conn = new(_stringConnection);
                return conn.Query<EventReservation>(query, parameters).ToList();
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Erro ao comunicar com banco, mensagem {ex.Message}, stack trace {ex.StackTrace}");
                throw;
            }
        }

        public bool InsertEventReservation(EventReservation eventReservation)
        {
            var query = "INSERT INTO EventReservation VALUES(@IdEvent, @PersonName, @Quantity)";

            var parameters = new DynamicParameters(new
            {
                eventReservation.IdEvent,
                eventReservation.PersonName,
                eventReservation.Quantity
            });

            try
            {
                using MySqlConnection conn = new(_stringConnection);
                return conn.Execute(query, parameters) == 1;
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Erro ao comunicar com banco, mensagem {ex.Message}, stack trace {ex.StackTrace}");
                throw;
            }
        }
        public bool UpdateEventReservation(long idReservation, long quantity)
        {
            var query = "UPDATE EventReservation SET Quantity = @Quantity WHERE IdReservation = @IdReservation";

            var parameters = new DynamicParameters(new
            {
                idReservation,
                quantity
            });

            try
            {
                using MySqlConnection conn = new(_stringConnection);
                return conn.Execute(query, parameters) == 1;
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Erro ao comunicar com banco, mensagem {ex.Message}, stack trace {ex.StackTrace}");
                throw;
            }
        }
        public bool DeleteEventReservation(long idReservation)
        {
            var query = "DELETE FROM EventReservation WHERE IdReservation = @IdReservation";

            var parameters = new DynamicParameters(new
            {
                idReservation
            });

            try
            {
                using MySqlConnection conn = new(_stringConnection);
                return conn.Execute(query, parameters) == 1;
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Erro ao comunicar com banco, mensagem {ex.Message}, stack trace {ex.StackTrace}");
                throw;
            }
        }

        //Inclusão de uma nova reserva; *Autenticação
        //Edição da quantidade de uma reserva; *Autenticação e Autorização admin
        //Remoção de uma reserva; *Autenticação e Autorização admin
        //Consulta de reserva pelo PersonName e Title do evento, utilizando similaridade para o title; *Autenticação


    }
}
