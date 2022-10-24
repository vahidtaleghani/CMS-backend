namespace CMS.Server.Model
{
	public class DepartmentType
	{
        public DepartmentType(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
		public string Name { get; set; }
	}

}
