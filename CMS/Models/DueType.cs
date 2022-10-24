namespace CMS.Models
{
	public class DueType
	{
        public DueType(int dueTypeId, string type)
        {
            DueTypeId = dueTypeId;
            Type = type;
        }

        public int DueTypeId { get; set; }
		public string Type { get; set; }
	}
}
