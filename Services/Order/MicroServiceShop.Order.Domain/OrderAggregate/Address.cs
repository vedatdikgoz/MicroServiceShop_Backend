
namespace MicroServiceShop.Order.Domain.OrderAggregate
{
    public class Address : ValueObject
    {
        public string? Country { get; private set; }
        public string? Province { get; private set; }
        public string? District { get; private set; }
        public string? AddressLine { get; private set; }
        public string? ZipCode { get; private set; }



        public Address(string country, string province, string district, string addressLine, string zipCode)
        {
            Country = country;
            Province = province;
            District = district;
            AddressLine = addressLine;
            ZipCode = zipCode;
        }

        //yield return ifadesiyle her bir özellik sırasıyla döndürülür.
        //Bu metod, değerin karşılaştırılması sırasında hangi özelliklerin kontrol edilmesi gerektiğini belirtir.
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Country;
            yield return Province;
            yield return District;
            yield return AddressLine;
            yield return ZipCode;

        }

    }
}
