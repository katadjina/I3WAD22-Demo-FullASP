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
    public class ProprietaireService : BaseService
    {
        public ProprietaireService(IConfiguration config) : base(config, "Theatre-DB")
        {
        }

       

        public int Insert(Proprietaire entity)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"INSERT INTO [Proprietaire] ([idClient])
                                            VALUES (@id)";
                    //command.CommandText = "SP_ClientAdd";
                    //command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("id", entity.Client_id);

                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }

    }
}
