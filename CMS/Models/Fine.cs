namespace CMS.Models
{
    public class Fine
    {
        public Fine(int fineId, int fineType, double price, string comment, int contractId)
        {
            FineId = fineId;
            FineType = fineType;
            Price = price;
            Comment = comment;
            ContractId = contractId;
        }

        public int FineId { get; set; }
        public int FineType { get; set; }
        public double Price { get; set; }
        public string Comment { get; set; }
        public int ContractId { get; set; }
    }
}
