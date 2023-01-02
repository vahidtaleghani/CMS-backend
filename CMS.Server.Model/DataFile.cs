namespace CMS.Server.Model
{
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Collections.Generic;

    public class DataFile
    {
        public DataFile(int fileId, string fileName, DateTime date, string comment, bool isFinal, int contractId, IFormFile data)
        {
            FileId = fileId;
            FileName = fileName;
            Date = date;
            Comment = comment;
            IsFinal = isFinal;
            ContractId = contractId;
            Data = data;
        }

        public int FileId { get; set; }
        public DateTime Date { get; set; }
        public string FileName { get; set; }
        public string Comment { get; set; }
        public bool IsFinal { get; set; }
        public int ContractId { get; set; }
        public IFormFile Data { get; set; }
    }
}
