namespace CMS.Models
{
	public class DutyType
	{
        public DutyType(int dutyTypeId, string type)
        {
            DutyTypeId = dutyTypeId;
            Type = type;
        }

        public int DutyTypeId { get; set; }
		public string Type { get; set; }
	}

}
