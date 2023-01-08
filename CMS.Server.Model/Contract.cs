namespace CMS.Server.Model
{
    using System;
    public class Contract
    {
        //public Contract(string usertoken, string status)
        //{
        //    this.Usertoken = usertoken;
        //    this.Status = status;
        //}

        public Contract(int id, string status)
        {
            this.Id = id;
            this.Status = status;
        }

        public Contract(int id, string status, string contractNo, string companyName, string contactPerson, string internalContactPerson)
        {
            this.Id = id;
            this.Status = status;
            this.ContractNo = contractNo;
            this.CompanyName = companyName;
            this.ContactPerson = contactPerson;
            this.InternalContactPerson = internalContactPerson;
        }

        public string Usertoken { get; }

        public int Id { get; }

        public string Status { get; }

        public string ContractNo { get; }
        public string CompanyName { get; }
        
        public string ContactPerson { get; }

        public string InternalContactPerson { get; }



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
