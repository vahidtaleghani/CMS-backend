using CMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace CMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LiabilityController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public LiabilityController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // -------- Get Methode
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select * from liability";

            DataTable dataTable = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("CMSAppCon");
            NpgsqlDataReader dataReader;
            using (NpgsqlConnection connection = new NpgsqlConnection(sqlDataSource))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    dataReader = command.ExecuteReader();
                    dataTable.Load(dataReader);

                    dataReader.Close();
                    connection.Close();
                }
            }

            return new JsonResult(dataTable);
        }


        // -------- Post Methode
        [HttpPost]
        public JsonResult Post(Liability liability)
        {
            string query = @"insert into 
                            liability(contract_id, due_date, liability_type_id, price)
                            values (@ContractId, @DueDate, @LiabilityTypeId, @Price)";

            DataTable dataTable = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("CMSAppCon");
            NpgsqlDataReader dataReader;
            using (NpgsqlConnection connection = new NpgsqlConnection(sqlDataSource))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ContractId", liability.ContractId);
                    command.Parameters[0].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
                    command.Parameters.AddWithValue("@DueDate", liability.DueDate);
                    command.Parameters[1].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Date;
                    command.Parameters.AddWithValue("@LiabilityTypeId", liability.LiabilityTypeId);
                    command.Parameters[2].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
                    command.Parameters.AddWithValue("@Price", liability.Price);
                    command.Parameters[3].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Double;
                    dataReader = command.ExecuteReader();
                    dataTable.Load(dataReader);

                    dataReader.Close();
                    connection.Close();
                }
            }

            return new JsonResult("Add to liability Table successfully");
        }


        // -------- Put Methode
        [HttpPut]
        public JsonResult Put(Liability liability)
        {
            string query = @"Update liability set 
                            contract_id =@ContractId , 
                            due_date = @DueDate,
                            liability_type_id = @LiabilityTypeId,   
                            price = @Price
                            where liability_id = @LiabilityId";

            DataTable dataTable = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("CMSAppCon");
            NpgsqlDataReader dataReader;
            using (NpgsqlConnection connection = new NpgsqlConnection(sqlDataSource))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ContractId", liability.ContractId);
                    command.Parameters[0].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
                    command.Parameters.AddWithValue("@DueDate", liability.DueDate);
                    command.Parameters[1].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Date;
                    command.Parameters.AddWithValue("@LiabilityTypeId", liability.LiabilityTypeId);
                    command.Parameters[2].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
                    command.Parameters.AddWithValue("@Price", liability.Price);
                    command.Parameters[3].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Double;
                    command.Parameters.AddWithValue("@LiabilityId", liability.LiabilityId);
                    command.Parameters[4].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
                    dataReader = command.ExecuteReader();
                    dataTable.Load(dataReader);

                    dataReader.Close();
                    connection.Close();
                }
            }

            return new JsonResult("liability table updated successfully");
        }


        // -------- Delete Methode
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"Delete from liability
                            where liability_id = @LiabilityId";

            DataTable dataTable = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("CMSAppCon");
            NpgsqlDataReader dataReader;
            using (NpgsqlConnection connection = new NpgsqlConnection(sqlDataSource))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LiabilityId", id);
                    command.Parameters[0].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
                    dataReader = command.ExecuteReader();
                    dataTable.Load(dataReader);

                    dataReader.Close();
                    connection.Close();
                }
            }

            return new JsonResult("Delete from liability Table successfully");
        }
    }
}
