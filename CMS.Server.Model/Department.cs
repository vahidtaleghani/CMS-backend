namespace CMS.Server.Model
{
	public class Department
	{
		public Department(int id, int departmentTypeId, int contactId)
		{
			Id = id;
			DepartmentTypeId = departmentTypeId;
			ContactId = contactId;
		}

		public int Id { get; set; }
		public int DepartmentTypeId { get; set; }
		public int ContactId { get; set; }
	}
}
