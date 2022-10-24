namespace CMS.Server.Model
{
    public class ContractStatus
    {
        public ContractStatus(int id, string status)
        {
            this.Id = id;
            this.Status = status;
        }
        public int Id { get; }
        public string Status { get; }
    }
}
