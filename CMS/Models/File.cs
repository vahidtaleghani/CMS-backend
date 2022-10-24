using System;

namespace CMS.Models
{
	public class File
	{
        public File(int fileId, DateTime fileDate, string fileName, string comment, bool isFinal, int contractId)
        {
            FileId = fileId;
            FileDate = fileDate;
            FileName = fileName;
            Comment = comment;
            IsFinal = isFinal;
            ContractId = contractId;
        }

        public int FileId { get; set; }
		public DateTime FileDate { get; set; }
		public string FileName { get; set; }
        public string Comment { get; set; }
        public bool IsFinal { get; set; }
        public int ContractId { get; set; }
    }
}
