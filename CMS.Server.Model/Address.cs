namespace CMS.Server.Model
{

    public class Address
    {
        public Address(int addressId, string street, string houseNumber, int postalCode, string city, int contractorId)
        {
            AddressId = addressId;
            Street = street;
            HouseNumber = houseNumber;
            PostalCode = postalCode;
            City = city;
            ContractorId = contractorId;
        }

        public int AddressId { get; set; }

        public int ContractorId { get; set; }
        public string Street { get; set; }

        public string HouseNumber { get; set; }

        public int PostalCode { get; set; }

        public string City { get; set; }
 
    }
 
}
