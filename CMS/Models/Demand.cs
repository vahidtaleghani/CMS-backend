using System;

namespace CMS.Models
{
	public class Demand
	{
        public Demand(int demandId, DateTime dueDate, double price, int dueTypeId, int contractId)
        {
            DemandId = demandId;
            DueDate = dueDate;
            Price = price;
            DueTypeId = dueTypeId;
            ContractId = contractId;
        }

        public int DemandId { get; set; }
		public DateTime DueDate { get; set; }
		public double Price { get; set; }
		public int DueTypeId { get; set; }
        public int ContractId { get; set; }
    }
}
