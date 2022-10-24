namespace CMS.Server.Model
{
    using System;
    public class Sign
    {
        public Sign(int id, DateTime date, string firstName, string lastName,bool isSigned, bool isCompletlySigned, int contractId)
        {
            Id = id;
            Date = date;
            FirstName = firstName;
            LastName = lastName;
            IsSigned = isSigned;
            IsCompletlySigned = isCompletlySigned;
            ContractId = contractId;
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsCompletlySigned { get; set; }
        public bool IsSigned { get; set; }
        public int ContractId { get; set; }
    }
}
