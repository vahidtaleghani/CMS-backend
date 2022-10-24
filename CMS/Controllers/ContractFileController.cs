using CMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace CMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractFileController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ContractFileController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // -------- Get Methode
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select * from contract_file";

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
        public JsonResult Post(File contractFile)
        {
            string query = @"insert into 
                            contract_file(contract_id, contract_file_date, file_name, final)
                            values (@ContractId, @ContractFileDate, @FileName, @Final)";

            DataTable dataTable = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("CMSAppCon");
            NpgsqlDataReader dataReader;
            using (NpgsqlConnection connection = new NpgsqlConnection(sqlDataSource))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ContractId", contractFile.ContractId);
                    command.Parameters[0].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
                    command.Parameters.AddWithValue("@ContractFileDate", contractFile.ContractFileDate);
                    command.Parameters[1].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Date;
                    command.Parameters.AddWithValue("@FileName", contractFile.FileName);
                    command.Parameters[2].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
                    command.Parameters.AddWithValue("@Final", contractFile.Final);
                    command.Parameters[3].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Boolean;
                    dataReader = command.ExecuteReader();
                    dataTable.Load(dataReader);

                    dataReader.Close();
                    connection.Close();
                }
            }

            return new JsonResult("Add to contract_file Table successfully");
        }


        // -------- Put Methode
        [HttpPut]
        public JsonResult Put(File contractFile)
        {
            string query = @"Update contract_file set 
                            contract_id =@ContractId , 
                            contract_file_date = @ContractFileDate,
                            file_name = @FileName,   
                            final = @Final
                            where contract_file_id = @ContractFileId";

            DataTable dataTable = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("CMSAppCon");
            NpgsqlDataReader dataReader;
            using (NpgsqlConnection connection = new NpgsqlConnection(sqlDataSource))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ContractId", contractFile.ContractId);
                    command.Parameters[0].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
                    command.Parameters.AddWithValue("@ContractFileDate", contractFile.ContractFileDate);
                    command.Parameters[1].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Date;
                    command.Parameters.AddWithValue("@FileName", contractFile.FileName);
                    command.Parameters[2].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
                    command.Parameters.AddWithValue("@Final", contractFile.Final);
                    command.Parameters[3].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Boolean;
                    command.Parameters.AddWithValue("@ContractFileId", contractFile.ContractFileId);
                    command.Parameters[4].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
                    dataReader = command.ExecuteReader();
                    dataTable.Load(dataReader);

                    dataReader.Close();
                    connection.Close();
                }
            }

            return new JsonResult("contract_file table updated successfully");
        }


        // -------- Delete Methode
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"Delete from contract_file
                            where contract_file_id = @ContractFileId";

            DataTable dataTable = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("CMSAppCon");
            NpgsqlDataReader dataReader;
            using (NpgsqlConnection connection = new NpgsqlConnection(sqlDataSource))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ContractFileId", id);
                    command.Parameters[0].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
                    dataReader = command.ExecuteReader();
                    dataTable.Load(dataReader);

                    dataReader.Close();
                    connection.Close();
                }
            }

            return new JsonResult("Delete from contract_file Table successfully");
        }
    }
}
