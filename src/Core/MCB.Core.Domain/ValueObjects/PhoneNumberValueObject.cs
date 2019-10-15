using MCB.Core.Domain.ValueObjects.Base;

namespace MCB.Core.Domain.ValueObjects
{
    public class PhoneNumberValueObject
        : ValueObjectBase
    {
        public string CountryCode { get; set; }
        public string AreaCode { get; set; }
        public string Number { get; set; }

        public PhoneNumberValueObject()
        {

        }
        public PhoneNumberValueObject(string countryCode, string areaCode, string number)
        {
            CountryCode = countryCode;
            AreaCode = areaCode;
            Number = number;
        }
    }
}

