using MCB.Core.Domain.ValueObjects.Base;
using MCB.Core.Domain.ValueObjects.Enums;

namespace MCB.Core.Domain.ValueObjects
{
    public class PhoneNumberValueObject
        : ValueObjectBase
    {
        public PhoneNumberTypeEnum PhoneNumberType { get; set; }
        public string CountryCode { get; set; }
        public string AreaCode { get; set; }
        public string Number { get; set; }

        public PhoneNumberValueObject()
        {

        }
        public PhoneNumberValueObject(PhoneNumberTypeEnum phoneNumberType, string countryCode, string areaCode, string number)
        {
            PhoneNumberType = phoneNumberType;
            CountryCode = countryCode;
            AreaCode = areaCode;
            Number = number;
        }

        public override void Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}

