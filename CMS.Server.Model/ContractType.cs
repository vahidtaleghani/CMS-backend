namespace CMS.Server.Model
{
	public class ContractType
	{
        public ContractType(int contractTypeId, string type)
        {
            ContractTypeId = contractTypeId;
            Type = type;
        }

        public int ContractTypeId { get; set; }
		public string Type { get; set; }
	}
}
