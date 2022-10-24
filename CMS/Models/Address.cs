namespace CMS.Models
{

    public class Address
    {
        public Address(int addressId, string street, string houseNumber, int postalCode, string city)
        {
            AddressId = addressId;
            Street = street;
            HouseNumber = houseNumber;
            PostalCode = postalCode;
            City = city;
        }

        public int AddressId { get; set; }

        public string Street { get; set; }

        public string HouseNumber { get; set; }

        public int PostalCode { get; set; }

        public string City { get; set; }

    }

}
