using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Server.Model
{
    public class Claim
    {
        public Claim(int id, DateTime dueDate, int paymentPeriodId, double cost, int contractId)
        {
            Id = id;
            DueDate = dueDate;
            PaymentPeriodId = paymentPeriodId;
            Cost = cost;
            ContractId = contractId;
        }

        public int Id { get; set; }
        public DateTime DueDate { get; set; }
        public int PaymentPeriodId { get; set; }
        public double Cost { get; set; }
        public int ContractId { get; set; }
    }
}
