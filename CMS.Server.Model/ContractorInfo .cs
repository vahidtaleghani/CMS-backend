namespace CMS.Server.Model
{
    public class ContractorInfo
    {
        public ContractorInfo(int contractorId, string companyName, string person, string companyRegistrationNumber, string department,
                           Address address,
                           string email, string telNumber,
                           int contractId, int infoId,int contractTypeId, int contractStatusId)
        {
            Id = contractorId;
            CompanyName = companyName;
            Person = person;
            CompanyRegistrationNumber = companyRegistrationNumber;
            Department = department;
            Address = address;
            Email = email;
            TelNumber = telNumber;
            ContractId = contractId;
            InfoId = infoId;
            ContractTypeId = contractTypeId;
            ContractStatusId = contractStatusId;
        }

        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Person { get; set; }
        public string CompanyRegistrationNumber { get; set; }
        public string Department { get; set; }
        public Address Address { get; set; }
        public string Email { get; set; }
        public string TelNumber { get; set; }
        public int ContractId { get; set; }
        public int InfoId { get; set; }
        public int ContractTypeId { get; set; }
        public int ContractStatusId { get; set; }
    }
}
