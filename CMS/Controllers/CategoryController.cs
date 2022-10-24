using CMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;


namespace CMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public CategoryController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // -------- Get Methode
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select * from category";

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
        public JsonResult Post(Category category)
        {
            string query = @"insert into 
                            category(contract_id, category_type_id)
                            values (@ContractId, @CategoryTypeId)";

            DataTable dataTable = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("CMSAppCon");
            NpgsqlDataReader dataReader;
            using (NpgsqlConnection connection = new NpgsqlConnection(sqlDataSource))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ContractId", category.ContractId);
                    command.Parameters[0].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
                    command.Parameters.AddWithValue("@CategoryTypeId", category.CategoryTypeId);
                    command.Parameters[1].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
                    dataReader = command.ExecuteReader();
                    dataTable.Load(dataReader);

                    dataReader.Close();
                    connection.Close();
                }
            }

            return new JsonResult("Add to category Table successfully");
        }


        // -------- Put Methode
        [HttpPut]
        public JsonResult Put(Category category)
        {
            string query = @"Update category set 
                            contract_id =@ContractId , 
                            category_type_id = @CategoryTypeId,
                            where category_id = @CategoryId";

            DataTable dataTable = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("CMSAppCon");
            NpgsqlDataReader dataReader;
            using (NpgsqlConnection connection = new NpgsqlConnection(sqlDataSource))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ContractId", category.ContractId);
                    command.Parameters[0].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
                    command.Parameters.AddWithValue("@CategoryTypeId", category.CategoryTypeId);
                    command.Parameters[1].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
                    command.Parameters.AddWithValue("@CategoryId", category.CategoryId);
                    command.Parameters[2].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
                    dataReader = command.ExecuteReader();
                    dataTable.Load(dataReader);

                    dataReader.Close();
                    connection.Close();
                }
            }

            return new JsonResult("category table updated successfully");
        }


        // -------- Delete Methode
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"Delete from category
                            where category_id = @CategoryId";

            DataTable dataTable = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("CMSAppCon");
            NpgsqlDataReader dataReader;
            using (NpgsqlConnection connection = new NpgsqlConnection(sqlDataSource))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CategoryId", id);
                    command.Parameters[0].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
                    dataReader = command.ExecuteReader();
                    dataTable.Load(dataReader);

                    dataReader.Close();
                    connection.Close();
                }
            }

            return new JsonResult("Delete from category Table successfully");
        }
    }
}
