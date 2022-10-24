using System;

namespace CMS.Models
{
	public class Liability
	{
        public Liability(int liabilityId, DateTime dueDate, int liability_type_id, double cost, int contractId)
        {
            LiabilityId = liabilityId;
            DueDate = dueDate;
            LiabilityTypeId = liability_type_id;
            Cost = cost;
            ContractId = contractId;
        }

        public int LiabilityId { get; set; }
        public DateTime DueDate { get; set; }
        public int LiabilityTypeId { get; set; }
        public double Cost { get; set; }
        public int ContractId { get; set; }
    }

}
