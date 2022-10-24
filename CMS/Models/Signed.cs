using System;

namespace CMS.Models
{
	public class Signed
	{
        public Signed(int signedId, DateTime signatureDate, string firstName, string lastName, bool isSigned, bool isFullySigned, int contractId)
        {
            SignedId = signedId;
            SignatureDate = signatureDate;
            FirstName = firstName;
            LastName = lastName;
            IsSigned = isSigned;
            IsFullySigned = isFullySigned;
            ContractId = contractId;
        }

        public int SignedId { get; set; }
        public DateTime SignatureDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsFullySigned { get; set; }
        public bool IsSigned { get; set; }
        public int ContractId { get; set; }
    }
}
