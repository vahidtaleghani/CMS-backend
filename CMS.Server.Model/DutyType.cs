namespace CMS.Server.Model
{
	public class DutyType
	{
        public DutyType(int id, string type)
        {
            Id = id;
            Type = type;
        }

        public int Id { get; set; }
		public string Type { get; set; }
	}

}
