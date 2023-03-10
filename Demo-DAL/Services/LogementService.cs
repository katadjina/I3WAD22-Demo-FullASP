using Demo_Common.Repositories;
using Demo_DAL.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_DAL.Services
{
    public class LogementService : BaseService,ILogementRepository<Logement, int>
    {
        
        public LogementService(IConfiguration config) : base(config, "Theatre-DB")
        {
        }

        public bool Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM [Logement] WHERE [Logement_id] = @id";
                    command.Parameters.AddWithValue("id", id);
                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public IEnumerable<Logement> Get()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [Logement_id], [Logement].[nom], [rue], [nombrePieces], [DescriptionCourte], [Prix], [Logement].[Client_id],[date_add],[email] FROM [Logement],[Client] WHERE [Logement].[Client_id]=[Client].[Client_id]"; 
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader.ToLogement();
                        }
                    }
                }

            }
        }

        public IEnumerable<Logement> GetMyLogement(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [Logement_id], [Logement].[nom], [rue], [nombrePieces], [DescriptionCourte], [Prix], [Logement].[Client_id],[date_add],[email] FROM [Logement],[Client] WHERE [Logement].[Client_id]=[Client].[Client_id] AND [Client].[Client_id] = @id ";
                    command.Parameters.AddWithValue("id", id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader.ToLogement();
                        }
                    }
                }

            }
        }

        public Logement Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [Logement_id], [Logement].[nom], [rue], [nombrePieces], [DescriptionCourte]," +
                        "[Prix], [Logement].[Client_id],[date_add],[email] FROM [Logement],[Client] WHERE [Logement].[Client_id]=[Client].[Client_id] AND [Logement].[Logement_id] = @id ";
                    command.Parameters.AddWithValue("id", id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.ToLogement();
                        }
                        return null;
                    }
                }
            }
        }

        public IEnumerable<Logement> GetByDate(DateTime month)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    //command.CommandText = "SELECT [idRepresentation], [dateRepresentation], [heureRepresentation], [idSpectacle],[date_add] FROM [Representation] WHERE [dateRepresentation] = @date";
                    command.CommandText = "[SP_LogementMonth]";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("month", int.Parse(month.ToString("MM")));
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader.ToLogement();
                        }
                    }
                }
            }
        }

        public IEnumerable<Logement> GetBySpectacle(int idSpec)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [idRepresentation], [dateRepresentation], [heureRepresentation], [idSpectacle] FROM [Representation] WHERE [idSpectacle] = @idSpec";
                    command.Parameters.AddWithValue("idSpec", idSpec);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader.ToLogement();
                        }
                    }
                }
            }
        }

        public int Insert(Logement entity)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO [Logement] ( [nom], [rue], [nombrePieces], [DescriptionCourte],  [Client_id],[date_add])" +
                        " OUTPUT [inserted].[Logement_id] " +
                        "VALUES (@nom,@rue,@nombrePiece,@DescriptionCourte,@Client_id,@date_add)";
                    command.Parameters.AddWithValue("nom", entity.nom);
                    command.Parameters.AddWithValue("rue", entity.rue);
                    command.Parameters.AddWithValue("nombrePiece", entity.nombrePieces);
                    command.Parameters.AddWithValue("DescriptionCourte", entity.DescriptionCourte);
                    command.Parameters.AddWithValue("date_add", entity.date_add);
                    command.Parameters.AddWithValue("Client_id", entity.Client_id);

                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public bool Update(int id, Logement entity)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE [Logement] SET  [nom] = @nom , [rue]= @rue, [nombrePieces] = @nombrePiece,  [DescriptionCourte] = @DescriptionCourte , [Prix]= @Prix WHERE [Logement_id] = @id";
                    command.Parameters.AddWithValue("id", id);
                    command.Parameters.AddWithValue("nom", entity.nom);
                    command.Parameters.AddWithValue("rue", entity.rue);
                    command.Parameters.AddWithValue("nombrePiece", entity.nombrePieces);
                    command.Parameters.AddWithValue("DescriptionCourte", entity.DescriptionCourte);
                    command.Parameters.AddWithValue("Prix", entity.Prix);
                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public IEnumerable<Logement> GetLogementMonth(DateTime month)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Logement> GetLogementTwoDate(DateTime date_deb, DateTime date_fin)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    //command.CommandText = "SELECT [idRepresentation], [dateRepresentation], [heureRepresentation], [idSpectacle],[date_add] FROM [Representation] WHERE [dateRepresentation] = @date";
                    command.CommandText = "[SP_LogementTwoDate]";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("date_deb", date_deb);
                    command.Parameters.AddWithValue("date_fin", date_fin);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader.ToLogement();
                        }
                    }
                }
            }
        }
    }
}
