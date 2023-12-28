using Clean.Architecture.Domain.Validation.Errors;
using Clean.Architecture.Domain.Validation.ReflectableGenericValidationRules;
using Clean.Architecture.Domain.Validation.ReflectableValidationBuilder;

namespace Clean.Architecture.Domain.ValueObjects.DigitalCertificateValueObject
{
    public class DigitalCertificateValidationBuilder
    {
        public ReflectableValidationBuilder Builder { get; set; }

        public DigitalCertificateValidationBuilder()
        {
            Builder = CreateTemplate();
        }

        private ReflectableValidationBuilder CreateTemplate()
        {

            ReflectableValidationBuilder builder = new ReflectableValidationBuilder(new());

            builder.AddValidation(
               new NotEmptyValidationRule(
                   "SerialNumber", Errors.DigitalCertificate.EmptySerialNumber
               )
            );

            return builder;
        }
    }
}
