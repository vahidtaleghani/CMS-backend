using CMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public CommentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // -------- Get Methode
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select * from comment";

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
        public JsonResult Post(Comment comment)
        {
            string query = @"insert into 
                            comment(contract_id, comment_text, comment_date, user_name)
                            values (@ContractId, @CommentText, @CommentDate, @UserName)";

            DataTable dataTable = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("CMSAppCon");
            NpgsqlDataReader dataReader;
            using (NpgsqlConnection connection = new NpgsqlConnection(sqlDataSource))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ContractId", comment.ContractId);
                    command.Parameters[0].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
                    command.Parameters.AddWithValue("@CommentText", comment.CommentText);
                    command.Parameters[1].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
                    command.Parameters.AddWithValue("@CommentDate", comment.CommentDate);
                    command.Parameters[2].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Date;
                    command.Parameters.AddWithValue("@UserName", comment.UserName);
                    command.Parameters[3].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
                    dataReader = command.ExecuteReader();
                    dataTable.Load(dataReader);

                    dataReader.Close();
                    connection.Close();
                }
            }

            return new JsonResult("Add to comment Table successfully");
        }


        // -------- Put Methode
        [HttpPut]
        public JsonResult Put(Comment comment)
        {
            string query = @"Update comment set 
                            contract_id =@ContractId , 
                            comment_text = @CommentText,
                            comment_date = @CommentDate,   
                            user_name = @UserName,
                            comment_type_id = @CommentTypeId
                            where comment_id = @CommentId";

            DataTable dataTable = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("CMSAppCon");
            NpgsqlDataReader dataReader;
            using (NpgsqlConnection connection = new NpgsqlConnection(sqlDataSource))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ContractId", comment.ContractId);
                    command.Parameters[0].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
                    command.Parameters.AddWithValue("@CommentText", comment.CommentText);
                    command.Parameters[1].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
                    command.Parameters.AddWithValue("@CommentDate", comment.CommentDate);
                    command.Parameters[2].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Date;
                    command.Parameters.AddWithValue("@UserName", comment.UserName);
                    command.Parameters[3].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
                    command.Parameters.AddWithValue("@CommentId", comment.CommentId);
                    command.Parameters[5].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
                    dataReader = command.ExecuteReader();
                    dataTable.Load(dataReader);

                    dataReader.Close();
                    connection.Close();
                }
            }

            return new JsonResult("comment table updated successfully");
        }


        // -------- Delete Methode
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"Delete from comment
                            where comment_id = @CommentId";

            DataTable dataTable = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("CMSAppCon");
            NpgsqlDataReader dataReader;
            using (NpgsqlConnection connection = new NpgsqlConnection(sqlDataSource))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CommentId", id);
                    command.Parameters[0].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
                    dataReader = command.ExecuteReader();
                    dataTable.Load(dataReader);

                    dataReader.Close();
                    connection.Close();
                }
            }

            return new JsonResult("Delete from comment Table successfully");
        }
    }
}
