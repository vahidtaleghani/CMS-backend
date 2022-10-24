namespace CMS.Models
{
	public class Contractor
	{
        public Contractor(int contractorId, string companyName, string person, string companyRegistrationNumber, string department,
                        int addressId,
                        string email, string telNumber,
                        int contractId)
        {
            ContractorId = contractorId;
            CompanyName = companyName;
            Person = person;
            CompanyRegistrationNumber = companyRegistrationNumber;
            Department = department;
            AddressId = addressId;
            Email = email;
            TelNumber = telNumber;
            ContractId = contractId;
        }

        public int ContractorId { get; set; }
        public string CompanyName { get; set; }
        public string Person { get; set; }
        public string CompanyRegistrationNumber { get; set; }
        public string Department { get; set; }
        public int AddressId { get; set; }
        public string Email { get; set; }
        public string TelNumber { get; set; }
        public int ContractId { get; set; }
    }
}
