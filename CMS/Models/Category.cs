namespace CMS.Models
{
	public class Category
	{
        public Category(int categoryId ,int categoryTypeId, int contractId)
        {
            CategoryId = categoryId;
            CategoryTypeId = categoryTypeId;
            ContractId = contractId;
        }

        public int CategoryId { get; set; }
		public int CategoryTypeId { get; set; }
        public int ContractId { get; set; }
    }
}
