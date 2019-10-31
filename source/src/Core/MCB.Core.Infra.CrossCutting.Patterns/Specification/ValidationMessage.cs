using MCB.Core.Infra.CrossCutting.Patterns.Specification.Enums;

namespace MCB.Core.Infra.CrossCutting.Patterns.Specification
{
    public class ValidationMessage
    {
        public string Code { get; set; }
        public string DefaultDescription { get; set; }
        public ValidationMessageTypeEnum ValidationMessageType { get; set; }

        public ValidationMessage(string code, string defaultDescription, ValidationMessageTypeEnum validationMessageType = ValidationMessageTypeEnum.Error)
        {
            Code = code;
            DefaultDescription = defaultDescription;
            ValidationMessageType = validationMessageType;
        }
    }
}


