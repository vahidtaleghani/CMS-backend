using CMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace CMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public DepartmentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // -------- Get Methode
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select * from department";

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
        public JsonResult Post(Department department)
        {
            string query = @"insert into 
                            department(contact_id, department_type_id, contact_person_name, email)
                            values (@ContactId, @DepartmentTypeId, @ContactPersonName, @Email)";

            DataTable dataTable = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("CMSAppCon");
            NpgsqlDataReader dataReader;
            using (NpgsqlConnection connection = new NpgsqlConnection(sqlDataSource))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ContactId", department.ContactId);
                    command.Parameters[0].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
                    command.Parameters.AddWithValue("@DepartmentTypeId", department.DepartmentTypeId);
                    command.Parameters[1].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
                    command.Parameters.AddWithValue("@ContactPersonName", department.ContactPersonName);
                    command.Parameters[2].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
                    command.Parameters.AddWithValue("@Email", department.Email);
                    command.Parameters[3].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
                    dataReader = command.ExecuteReader();
                    dataTable.Load(dataReader);

                    dataReader.Close();
                    connection.Close();
                }
            }

            return new JsonResult("Add to department Table successfully");
        }


        // -------- Put Methode
        [HttpPut]
        public JsonResult Put(Department department)
        {
            string query = @"Update department set 
                            contact_id =@ContactId , 
                            department_type_id = @DepartmentTypeId,
                            contact_person_name = @ContactPersonName,   
                            email = @Email
                            where department_id = @DepartmentId";

            DataTable dataTable = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("CMSAppCon");
            NpgsqlDataReader dataReader;
            using (NpgsqlConnection connection = new NpgsqlConnection(sqlDataSource))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ContactId", department.ContactId);
                    command.Parameters[0].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
                    command.Parameters.AddWithValue("@DepartmentTypeId", department.DepartmentTypeId);
                    command.Parameters[1].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
                    command.Parameters.AddWithValue("@ContactPersonName", department.ContactPersonName);
                    command.Parameters[2].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
                    command.Parameters.AddWithValue("@Email", department.Email);
                    command.Parameters[3].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
                    command.Parameters.AddWithValue("@DepartmentId", department.DepartmentId);
                    command.Parameters[3].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
                    dataReader = command.ExecuteReader();
                    dataTable.Load(dataReader);

                    dataReader.Close();
                    connection.Close();
                }
            }

            return new JsonResult("department table updated successfully");
        }


        // -------- Delete Methode
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"Delete from department
                            where department_id = @DepartmentId";

            DataTable dataTable = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("CMSAppCon");
            NpgsqlDataReader dataReader;
            using (NpgsqlConnection connection = new NpgsqlConnection(sqlDataSource))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DepartmentId", id);
                    command.Parameters[0].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
                    dataReader = command.ExecuteReader();
                    dataTable.Load(dataReader);

                    dataReader.Close();
                    connection.Close();
                }
            }

            return new JsonResult("Delete from department Table successfully");
        }
    }
}
