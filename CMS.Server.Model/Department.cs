namespace CMS.Server.Model
{
	public class Department
	{
		public Department(int id, int contractId, int departmentTypeId,  string personName)
		{
            ContractId = contractId;
			Id = id;
            DepartmentTypeId = departmentTypeId;
            PersonName = personName;
        }

		public int Id { get; set; }
		public int DepartmentTypeId { get; set; }
		public int ContractId { get; set; }
        public string PersonName { get; set; }
    }
}
