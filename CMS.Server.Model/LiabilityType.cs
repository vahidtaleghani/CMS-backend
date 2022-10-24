namespace CMS.Server.Model
{
	public class LiabilityType
	{
        public LiabilityType(int liabilityTypeId, string type)
        {
            LiabilityTypeId = liabilityTypeId;
            Type = type;
        }

        public int LiabilityTypeId { get; set; }
		public string Type { get; set; }
	}
}
