namespace CMS.Models
{
    public class FineType
    {
        public FineType(int fineTypeId, string type)
        {
            FineTypeId = fineTypeId;
            Type = type;
        }

        public int FineTypeId { get; set; }
        public string Type { get; set; }
    }
}
