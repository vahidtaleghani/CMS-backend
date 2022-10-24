namespace CMS.Models
{
	public class CategoryType
	{
        public CategoryType(int categoryTypeId, string type)
        {
            CategoryTypeId = categoryTypeId;
            Type = type;
        }

        public int CategoryTypeId { get; set; }
		public string Type { get; set; }
	}
}
