using System;

namespace CMS.Models
{
    public class Info
    {
        public Info(int contractId, int contractStatusTypeId, int contractTypeId, 
                        bool isTemporary, DateTime startDate, DateTime endDate,
                        string terminationPeriod, string expDate,
                        bool isReferenceToAnotherProject, string projectId, string projectName, string comment)
        {
            ContractId = contractId;
            ContractStatusTypeId = contractStatusTypeId;
            ContractTypeId = contractTypeId;
            IsTemporary = isTemporary;
            StartDate = startDate;
            EndDate = endDate;
            TerminationPeriod = terminationPeriod;
            ExpDate = expDate;
            IsReferenceToAnotherProject = isReferenceToAnotherProject;
            ProjectId = projectId;
            ProjectName = projectName;
            Comment = comment;
        }

        public int ContractId { get; set; }
        public int ContractStatusTypeId { get; set; }
        public int ContractTypeId { get; set; }
        public bool IsTemporary { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string TerminationPeriod { get; set; }
        public string ExpDate { get; set; }
        public bool IsReferenceToAnotherProject { get; set; }
        public string ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string Comment { get; set; }
    }
}
