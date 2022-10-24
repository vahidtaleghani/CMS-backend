namespace CMS.Server.Model
{
	public class StatusType
	{
        public StatusType(int statusTypeId, string type)
        {
            StatusTypeId = statusTypeId;
            Type = type;
        }

        public int StatusTypeId { get; set; }
		public string Type { get; set; }
	}
}