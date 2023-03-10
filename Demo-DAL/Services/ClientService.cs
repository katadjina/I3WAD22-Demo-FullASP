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
    public class ClientService : BaseService, IClientRepository<Client, int>
    {
        public ClientService(IConfiguration config) : base(config, "Theatre-DB")
        {
        }

        public IEnumerable<Client> Get()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using(SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [Client_Id], [nom], [prenom], [email], [telephone], [pays] FROM [Client]";
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader.ToClient();
                        }
                    }
                }
            }
        }

        public Client Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [Client_id], [nom], [prenom], [email], [telephone],[pays] FROM [Client] WHERE [Client_id] = @id";
                    command.Parameters.AddWithValue("id", id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read()) return reader.ToClient();
                        return null;

                        //Format ternaire : return (reader.Read()) ? reader.ToClient() : null;
                    }
                }
            }
        }

        public int Insert(Client entity)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    //command.CommandText = @"INSERT INTO [Client] ([nom], [prenom], [email], [pass], [telephone], [pays])
                    //                        OUTPUT [inserted].[Client_id]
                    //                        VALUES (@nom, @prenom, @email, HASHBYTES('SHA2_512',@pass), @telephone, @pays)";
                    command.CommandText = "SP_ClientAdd";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("nom", entity.nom);
                    command.Parameters.AddWithValue("prenom", entity.prenom);
                    command.Parameters.AddWithValue("email", entity.email);
                    command.Parameters.AddWithValue("pass", entity.pass);
                    command.Parameters.AddWithValue("telephone", entity.telephone);
                    command.Parameters.AddWithValue("pays", entity.pays);
                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public bool Update(int id, Client entity)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    //command.CommandText = @"UPDATE [Client]
                    //                        SET [nom] = @nom,
                    //                            [prenom] = @prenom,
                    //                            [email] = @email,
                    //                            [pays] = @pays,
                    //                            [pass] = HASHBYTES('SHA2_512',@pass),
                    //                            [telephone] = @telephone
                    //                        WHERE [Client_id] = @id";
                    command.CommandText = "SP_ClientUpdate";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("nom", entity.nom);
                    command.Parameters.AddWithValue("prenom", entity.prenom);
                    command.Parameters.AddWithValue("email", entity.email);
                    command.Parameters.AddWithValue("pass", entity.pass);
                    command.Parameters.AddWithValue("telephone", entity.telephone);
                    command.Parameters.AddWithValue("pays", entity.pays);
                    command.Parameters.AddWithValue("id", id);
                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM [Client] WHERE [Client_id] = @id";
                    command.Parameters.AddWithValue("id", id);
                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public int? CheckPassword(string email, string password)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_ClientCheck";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("email", email);
                    command.Parameters.AddWithValue("pass", password);
                    connection.Open();
                    object result = command.ExecuteScalar();
                    return (result is DBNull)? null : (int?) result;
                }
            }
        }
    }
}
