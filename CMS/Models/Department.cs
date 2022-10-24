namespace CMS.Models
{
	public class Department
	{
        public Department(int departmentId, int departmentTypeId, int contactId)
        {
            DepartmentId = departmentId;
            DepartmentTypeId = departmentTypeId;
			ContactId = contactId;
		}

        public int DepartmentId { get; set; }
		public int DepartmentTypeId { get; set; }
		public int ContactId { get; set; }
	}
}
