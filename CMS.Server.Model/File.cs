﻿namespace CMS.Server.Model
{
    using System;
    public class File
    {
        public File(int fileId, string fileName, DateTime date, string comment, bool isFinal, int contractId)
        {
            FileId = fileId;
            FileName = fileName;
            Date = date;
            Comment = comment;
            IsFinal = isFinal;
            ContractId = contractId;
        }

        public int FileId { get; set; }
        public DateTime Date { get; set; }
        public string FileName { get; set; }
        public string Comment { get; set; }
        public bool IsFinal { get; set; }
        public int ContractId { get; set; }
    }
}
