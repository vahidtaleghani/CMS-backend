using CMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace CMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractorController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ContractorController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // -------- Get Methode
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select * from contractorcontractor";

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
        public JsonResult Post(Contractor contractor)
        {
            string query = @"insert into 
                            contractor(signed_id, contract_id, address_id, company_name , person, corporate_register_number, department, tel, email)
                            values (@SignedId, @ContractId, @AddressId, @CompanyName, @Person, @CorporateRegisterNumber, @Department, @Tel, @Email)";

            DataTable dataTable = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("CMSAppCon");
            NpgsqlDataReader dataReader;
            using (NpgsqlConnection connection = new NpgsqlConnection(sqlDataSource))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SignedId", contractor.SignedId);
                    command.Parameters[0].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
                    command.Parameters.AddWithValue("@ContractId", contractor.ContractId);
                    command.Parameters[1].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
                    command.Parameters.AddWithValue("@AddressId", contractor.AddressId);
                    command.Parameters[2].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
                    command.Parameters.AddWithValue("@CompanyName", contractor.CompanyName);
                    command.Parameters[3].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
                    command.Parameters.AddWithValue("@Person", contractor.Person);
                    command.Parameters[4].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
                    command.Parameters.AddWithValue("@CorporateRegisterNumber", contractor.CorporateRegisterNumber);
                    command.Parameters[5].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
                    command.Parameters.AddWithValue("@Department", contractor.Department);
                    command.Parameters[6].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
                    command.Parameters.AddWithValue("@Tel", contractor.Tel);
                    command.Parameters[7].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
                    command.Parameters.AddWithValue("@Email", contractor.Email);
                    command.Parameters[8].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
                    dataReader = command.ExecuteReader();
                    dataTable.Load(dataReader);

                    dataReader.Close();
                    connection.Close();
                }
            }

            return new JsonResult("Add to contractor Table successfully");
        }


        // -------- Put Methode
        [HttpPut]
        public JsonResult Put(Contractor contractor)
        {
            string query = @"Update contractor set 
                            signed_id = @SignedId,
                            contract_id = @ContractId,
                            address_id = @AddressId,
                            company_name= @CompanyName ,
                            person = @Person,
                            corporate_register_number = @CorporateRegisterNumber,
                            department = @Department,
                            tel = @Tel,
                            email = @Email
                            where contractor_id = @ContractorId";

            DataTable dataTable = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("CMSAppCon");
            NpgsqlDataReader dataReader;
            using (NpgsqlConnection connection = new NpgsqlConnection(sqlDataSource))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SignedId", contractor.SignedId);
                    command.Parameters[0].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
                    command.Parameters.AddWithValue("@ContractId", contractor.ContractId);
                    command.Parameters[1].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
                    command.Parameters.AddWithValue("@AddressId", contractor.AddressId);
                    command.Parameters[2].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
                    command.Parameters.AddWithValue("@CompanyName", contractor.CompanyName);
                    command.Parameters[3].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
                    command.Parameters.AddWithValue("@Person", contractor.Person);
                    command.Parameters[4].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
                    command.Parameters.AddWithValue("@CorporateRegisterNumber", contractor.CorporateRegisterNumber);
                    command.Parameters[5].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
                    command.Parameters.AddWithValue("@Department", contractor.Department);
                    command.Parameters[6].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
                    command.Parameters.AddWithValue("@Tel", contractor.Tel);
                    command.Parameters[7].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
                    command.Parameters.AddWithValue("@Email", contractor.Email);
                    command.Parameters[8].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
                    command.Parameters.AddWithValue("@ContractorId", contractor.ContractorId);
                    command.Parameters[8].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
                    dataReader = command.ExecuteReader();
                    dataTable.Load(dataReader);

                    dataReader.Close();
                    connection.Close();
                }
            }

            return new JsonResult("contractor table updated successfully");
        }


        // -------- Delete Methode
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"Delete from contractor
                            where contractor_id = @ContractorId";

            DataTable dataTable = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("CMSAppCon");
            NpgsqlDataReader dataReader;
            using (NpgsqlConnection connection = new NpgsqlConnection(sqlDataSource))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ContractorId", id);
                    command.Parameters[0].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
                    dataReader = command.ExecuteReader();
                    dataTable.Load(dataReader);

                    dataReader.Close();
                    connection.Close();
                }
            }

            return new JsonResult("Delete from contractor Table successfully");
        }
    }
}
