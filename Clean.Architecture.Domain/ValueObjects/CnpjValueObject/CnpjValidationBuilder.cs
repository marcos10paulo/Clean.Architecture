using Clean.Architecture.Domain.ValueObjects.CnpjValueObject.CnpjValidationRules;
using Clean.Architecture.Domain.Validation.ReflectableGenericValidationRules;
using Clean.Architecture.Domain.Validation.ReflectableValidationBuilder;
using Clean.Architecture.Domain.Validation.Errors;

namespace Clean.Architecture.Domain.ValueObjects.CnpjValueObject
{
    public class CnpjValidationBuilder
    {
        public ReflectableValidationBuilder Builder { get; set; }

        public CnpjValidationBuilder()
        {
            Builder = CreateTemplate();
        }

        private ReflectableValidationBuilder CreateTemplate()
        {

            ReflectableValidationBuilder builder = new ReflectableValidationBuilder(new());

            builder.AddValidation(
                 new NotEmptyValidationRule(
                   "Value", Errors.Cnpj.EmptyCnpj
               )
            ).AddValidation(
                new CnpjLengthValidationRule()
            ).AddValidation(
                new CnpjSequentialValidationRule()
            )
            .AddValidation(
               new CnpjBaseValidationRule()
            );

            return builder;
        }
    }
}
