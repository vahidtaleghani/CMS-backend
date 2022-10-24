namespace CMS.Server.Model
{
    public class Fine
    {
        public Fine(int id, int fineTypeId, double price, string comment,int contractId)
        {
            Id = id;
            FineTypeId = fineTypeId;
            Price = price;
            Comment = comment;
            ContractId = contractId;
        }

        public int Id { get; set; }
        public int FineTypeId { get; set; }
        public double Price { get; set; }
        public string Comment { get; set; }
        public int ContractId { get; set; }
    }
}
