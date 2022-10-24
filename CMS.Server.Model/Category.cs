namespace CMS.Server.Model
{
    public class Category
    {
        public Category(int id, int contractId, int categoryTypeId, string comment)
        {
            Id = id;
            CategoryTypeId = categoryTypeId;
            ContractId = contractId;
            Comment = comment;
        }

        public int Id { get; set; }
        public int CategoryTypeId { get; set; }
        public int ContractId { get; set; }

        public string Comment { get; }
    }
}
