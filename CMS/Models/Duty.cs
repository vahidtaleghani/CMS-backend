using System;

namespace CMS.Models
{
	public class Duty
	{
        public Duty(int dutyId, DateTime dutyDate, int dutyTypId, string comment, int contractId)
        {
            DutyId = dutyId;
            DutyDate = dutyDate;
            DutyTypId = dutyTypId;
            Comment = comment;
            ContractId = contractId;
        }

        public int DutyId { get; set; }
        public DateTime DutyDate { get; set; }
        public int DutyTypId { get; set; }
        public string Comment { get; set; }
        public int ContractId { get; set; }
    }
}
