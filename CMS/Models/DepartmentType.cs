namespace CMS.Models
{
	public class DepartmentType
	{
        public DepartmentType(int departmentTypeId, string type)
        {
            DepartmentTypeId = departmentTypeId;
            Type = type;
        }

        public int DepartmentTypeId { get; set; }
		public string Type { get; set; }
	}

}
