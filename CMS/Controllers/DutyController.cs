using CMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace CMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DutyController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public DutyController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // -------- Get Methode
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select * from duty";

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
        public JsonResult Post(Duty duty)
        {
            string query = @"insert into 
                            duty(contract_id, duty_date, duty_type_id)
                            values (@ContractId, @DutyDate, @DutyTypeId)";

            DataTable dataTable = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("CMSAppCon");
            NpgsqlDataReader dataReader;
            using (NpgsqlConnection connection = new NpgsqlConnection(sqlDataSource))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ContractId", duty.ContractId);
                    command.Parameters[0].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
                    command.Parameters.AddWithValue("@DutyDate", duty.DutyDate);
                    command.Parameters[1].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Date;
                    command.Parameters.AddWithValue("@DutyTypeId", duty.DutyTypeId);
                    command.Parameters[2].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
                    dataReader = command.ExecuteReader();
                    dataTable.Load(dataReader);

                    dataReader.Close();
                    connection.Close();
                }
            }

            return new JsonResult("Add to duty Table successfully");
        }


        // -------- Put Methode
        [HttpPut]
        public JsonResult Put(Duty duty)
        {
            string query = @"Update duty set 
                            contract_id =@ContractId , 
                            duty_date = @DutyDate,
                            duty_type_id = @DutyTypeId,   
                            where duty_id = @DutyId";

            DataTable dataTable = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("CMSAppCon");
            NpgsqlDataReader dataReader;
            using (NpgsqlConnection connection = new NpgsqlConnection(sqlDataSource))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ContractId", duty.ContractId);
                    command.Parameters[0].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
                    command.Parameters.AddWithValue("@DutyDate", duty.DutyDate);
                    command.Parameters[1].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Date;
                    command.Parameters.AddWithValue("@DutyTypeId", duty.DutyTypeId);
                    command.Parameters[2].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
                    command.Parameters.AddWithValue("@DutyId", duty.DutyId);
                    command.Parameters[3].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
                    dataReader = command.ExecuteReader();
                    dataTable.Load(dataReader);

                    dataReader.Close();
                    connection.Close();
                }
            }

            return new JsonResult("duty table updated successfully");
        }


        // -------- Delete Methode
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"Delete from duty
                            where duty_id = @DutyId";

            DataTable dataTable = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("CMSAppCon");
            NpgsqlDataReader dataReader;
            using (NpgsqlConnection connection = new NpgsqlConnection(sqlDataSource))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DutyId", id);
                    command.Parameters[0].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
                    dataReader = command.ExecuteReader();
                    dataTable.Load(dataReader);

                    dataReader.Close();
                    connection.Close();
                }
            }

            return new JsonResult("Delete from duty Table successfully");
        }
    }
}
