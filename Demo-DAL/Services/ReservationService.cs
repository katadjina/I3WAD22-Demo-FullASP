using Demo_Common.Repositories;
using Demo_DAL.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Demo_DAL.Services
{
    public class ReservationService : BaseService, IReservationRepository<Reservation, int>
    {
        public ReservationService(IConfiguration config) : base(config, "Theatre-DB")
        {
        }

        public bool Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM [Reservation] WHERE [Reservation_id] = @id";
                    command.Parameters.AddWithValue("id", id);
                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public IEnumerable<Reservation> Get()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [Reservation_id], [checkIn], [checkOut], [description], [nombreAdultes], [nombreEnfants], [Reservation].[Logement_id], [Reservation].[Client_id],[nom],[DescriptionCourte] FROM [Reservation],[logement] WHERE [Reservation].[Logement_id]=[Logement].[Logement_id]";
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader.ToReservation();
                        }
                    }
                }
            }
        }

        public Reservation Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [Reservation_id], [checkIn], [checkOut], [PrixTotal], [nomAdultes], [nomEnfants], [Reservation].[Logement_id], [Reservation].[Client_id] ,[nom],[DescriptionCourte] FROM [Reservation],[logement] WHERE [Reservation].[Logement_id]=[Logement].[Logement_id] AND [Reservation_id] = @id";
                    command.Parameters.AddWithValue("id", id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read()) return reader.ToReservation();
                        return null;
                    }
                }
            }
        }

        public IEnumerable<Reservation> GetReservationLogement(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [Reservation_id], [checkIn], [checkOut], [PrixTotal], [nomAdultes], [nomEnfants], [Reservation].[Logement_id], [Reservation].[Client_id] ,[nom],[DescriptionCourte] FROM [Reservation],[logement] WHERE [Reservation].[Logement_id]=[Logement].[Logement_id] AND [Logement].[logement_id] = @id";
                    command.Parameters.AddWithValue("id", id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader.ToReservation();
                        }
                    }
                }
            }
        }

        public IEnumerable<Reservation> GetMyReservation(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    //command.CommandText = "SELECT [Reservation_id], [checkIn], [checkOut], [PrixTotal], [nomAdultes], [nomEnfants], [Logement_id], [Client_id] FROM [Reservation] WHERE [Client_id] = @id ";
                    command.CommandText = "SP_CientReservation";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("id", id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader.ToReservation();
                        }
                    }
                }

            }
        }

        public int Insert(Reservation entity)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"INSERT INTO [Reservation] ([checkIn], [checkOut], [PrixTotal], [nomAdultes], [nomEnfants], [Client_id], [Logement_id])
                                            OUTPUT [inserted].[Reservation_id]
                                            VALUES (@checkIn, @checkOut, @PrixTotal, @nombreAdultes, @nombreEnfants, @Client_id, @Logement_id)";
                    //command.CommandText = "SP_ClientAdd";
                    //command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("checkIn", entity.checkIn);
                    command.Parameters.AddWithValue("checkOut", entity.checkOut);
                    command.Parameters.AddWithValue("PrixTotal",  100);  //desoléé, j ai pas du temps pour regler partie calculation du prix :<
                    command.Parameters.AddWithValue("nombreAdultes", entity.nomAdultes);
                    command.Parameters.AddWithValue("nombreEnfants", entity.nomEnfants);
                    command.Parameters.AddWithValue("Client_id", entity.Client_id);
                    command.Parameters.AddWithValue("Logement_id", entity.Logement_id);
                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public bool Update(int id, Reservation entity)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE [Reservation] SET [checkIn] = @checkIn, [checkOut] = @checkOut , [PrixTotal] = @PrixTotal," +
                        " [nomAdultes] = @nombreAdultes,[nomEnfants] = @nombreEnfants  WHERE [Reservation_id] = @id";
                    command.Parameters.AddWithValue("checkIn", entity.checkIn);
                    command.Parameters.AddWithValue("checkOut", entity.checkOut);
                    command.Parameters.AddWithValue("PrixTotal", entity.PrixTotal);
                    command.Parameters.AddWithValue("nombreAdultes", entity.nomAdultes);
                    command.Parameters.AddWithValue("nombreEnfants", entity.nomEnfants);
                    command.Parameters.AddWithValue("id", id);
                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

    }
}
