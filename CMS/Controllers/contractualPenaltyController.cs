using CMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace CMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractualPenaltyController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ContractualPenaltyController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // -------- Get Methode
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select * from contractual_penalty";

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
        public JsonResult Post(Fine contractualPenalty)
        {
            string query = @"insert into 
                            contractual_penalty(contract_id, deadline_id, contractual_penalty_amount)
                            values (@ContractId, @DeadlineId, @ContractualPenaltyAmount)";

            DataTable dataTable = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("CMSAppCon");
            NpgsqlDataReader dataReader;
            using (NpgsqlConnection connection = new NpgsqlConnection(sqlDataSource))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ContractId", contractualPenalty.ContractId);
                    command.Parameters[0].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
                    command.Parameters.AddWithValue("@DeadlineId", contractualPenalty.DeadlineId);
                    command.Parameters[1].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
                    command.Parameters.AddWithValue("@ContractualPenaltyAmount", contractualPenalty.ContractualPenaltyAmount);
                    command.Parameters[2].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Double;
                    dataReader = command.ExecuteReader();
                    dataTable.Load(dataReader);

                    dataReader.Close();
                    connection.Close();
                }
            }

            return new JsonResult("Add to contractual_penalty Table successfully");
        }


        // -------- Put Methode
        [HttpPut]
        public JsonResult Put(Fine contractualPenalty)
        {
            string query = @"Update contractual_penalty set 
                            contract_id =@ContractId , 
                            deadline_id = @DeadlineId,
                            contractual_penalty_amount = @ContractualPenaltyAmount,   
                            where contractual_penalty_id = @ContractualPenaltyId";

            DataTable dataTable = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("CMSAppCon");
            NpgsqlDataReader dataReader;
            using (NpgsqlConnection connection = new NpgsqlConnection(sqlDataSource))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ContractId", contractualPenalty.ContractId);
                    command.Parameters[0].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
                    command.Parameters.AddWithValue("@DeadlineId", contractualPenalty.DeadlineId);
                    command.Parameters[1].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
                    command.Parameters.AddWithValue("@ContractualPenaltyAmount", contractualPenalty.ContractualPenaltyAmount);
                    command.Parameters[2].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Double;
                    command.Parameters.AddWithValue("@ContractualPenaltyId", contractualPenalty.ContractualPenaltyId);
                    command.Parameters[3].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Double;
                    dataReader = command.ExecuteReader();
                    dataTable.Load(dataReader);

                    dataReader.Close();
                    connection.Close();
                }
            }

            return new JsonResult("contractual_penalty table updated successfully");
        }


        // -------- Delete Methode
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"Delete from contractual_penalty
                            where contractual_penalty_id = @ContractualPenaltyId";

            DataTable dataTable = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("CMSAppCon");
            NpgsqlDataReader dataReader;
            using (NpgsqlConnection connection = new NpgsqlConnection(sqlDataSource))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ContractualPenaltyId", id);
                    command.Parameters[0].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
                    dataReader = command.ExecuteReader();
                    dataTable.Load(dataReader);

                    dataReader.Close();
                    connection.Close();
                }
            }

            return new JsonResult("Delete from contractual_penalty Table successfully");
        }
    }
}
