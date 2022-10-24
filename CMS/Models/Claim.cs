using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Models
{
    public class Claim
    {
        public Claim(int claimId, DateTime dueDate, int claimTypeId, double cost, int contractId)
        {
            ClaimId = claimId;
            DueDate = dueDate;
            ClaimTypeId = claimTypeId;
            Cost = cost;
            ContractId = contractId;
        }

        public int ClaimId { get; set; }
        public DateTime DueDate { get; set; }
        public int ClaimTypeId { get; set; }
        public double Cost { get; set; }
        public int ContractId { get; set; }
    }
}
