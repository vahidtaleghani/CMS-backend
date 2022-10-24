using System;

namespace CMS.Server.Model
{
    public class Info
    {
        public Info(int contractId, int contractStatusId, int contractTypeId,
                        bool isTemporary, DateTime startDate, DateTime endDate,
                        string terminationPeriod, DateTime expDate,
                        bool isReferencedToAnotherProject, int projectId, string projectName, string comment)
        {
            ContractId = contractId;
            ContractStatusId = contractStatusId;
            ContractTypeId = contractTypeId;
            IsTemporary = isTemporary;
            StartDate = startDate;
            EndDate = endDate;
            TerminationPeriod = terminationPeriod;
            ExpDate = expDate;
            IsReferencedToAnotherProject = isReferencedToAnotherProject;
            ProjectId = projectId;
            ProjectName = projectName;
            Comment = comment;
        }

        public int ContractId { get; set; }
        public int ContractStatusId { get; set; }
        public int ContractTypeId { get; set; }
        public bool IsTemporary { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string TerminationPeriod { get; set; }
        public DateTime ExpDate { get; set; }
        public bool IsReferencedToAnotherProject { get; set; }
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string Comment { get; set; }
    }
}
