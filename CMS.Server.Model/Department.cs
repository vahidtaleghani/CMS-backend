namespace CMS.Server.Model
{
	public class Department
	{
		public Department(int id, int contactId, int departmentTypeId,  string personName)
		{
			Id = id;
            ContactId = contactId;
            DepartmentTypeId = departmentTypeId;
            PersonName = personName;
        }

		public int Id { get; set; }
		public int DepartmentTypeId { get; set; }
		public int ContactId { get; set; }
        public string PersonName { get; set; }
    }
}
