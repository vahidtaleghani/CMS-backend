namespace CMS.Server.Model
{
    using System;
    public class Duty
    {
        public Duty(int id, DateTime date, int dutyTypId, string comment,int contractId )
        {
            Id = id;
            Date = date;
            DutyTypeId = dutyTypId;
            Comment = comment;
            ContractId = contractId;
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int DutyTypeId { get; set; }
        public string Comment { get; set; }
        public int ContractId { get; set; }
    }
}
