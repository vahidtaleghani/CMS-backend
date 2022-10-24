namespace CMS.Server.Model
{
    using System;
    public class Contract
    {
        public Contract(string usertoken, string status)
        {
            this.Usertoken = usertoken;
            this.Status = status;
        }

        public string Usertoken { get; }
        public string Status { get; }



    //    public Contract(int contractId, int contractTypId, int statusTypeId,
    //                    bool contractTemporary, DateTime startDate, DateTime endDate,
    //                    string noticePeriod, DateTime deadlineDate,
    //                     int deadlineMonths, bool projectReference, string projectId, string projectName, string comment)
    //    {
    //        ContractId = contractId;
    //        ContractTypId = contractTypId;
    //        StatusTypeId = statusTypeId;
    //        ContractTemporary = contractTemporary;
    //        StartDate = startDate;
    //        EndDate = endDate;
    //        NoticePeriod = noticePeriod;
    //        DeadlineDate = deadlineDate;
    //        DeadlineMonths = deadlineMonths;
    //        ProjectReference = projectReference;
    //        ProjectId = projectId;
    //        ProjectName = projectName;
    //        Comment = comment;
    //    }

    //    public int ContractId { get; set; }
    //    public int ContractTypId { get; set; }
    //    public int StatusTypeId { get; set; }
    //    public bool ContractTemporary { get; set; }
    //    public DateTime StartDate { get; set; }
    //    public DateTime EndDate { get; set; }
    //    public string NoticePeriod { get; set; }
    //    public DateTime DeadlineDate { get; set; }
    //    public int DeadlineMonths { get; set; }
    //    public bool ProjectReference { get; set; }
    //    public string ProjectId { get; set; }
    //    public string ProjectName { get; set; }
    //    public string Comment { get; set; }
    //}
}
}
