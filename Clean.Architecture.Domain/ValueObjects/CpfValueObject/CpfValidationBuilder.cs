using Clean.Architecture.Domain.ValueObjects.CpfValueObject.CpfValidationRules;
using Clean.Architecture.Domain.Validation.Errors;
using Clean.Architecture.Domain.Validation.ReflectableGenericValidationRules;
using Clean.Architecture.Domain.Validation.ReflectableValidationBuilder;

namespace Clean.Architecture.Domain.ValueObjects.CpfValueObject
{
    public class CpfValidationBuilder
    {
        public ReflectableValidationBuilder Builder { get; set; }

        public CpfValidationBuilder()
        {
            Builder = CreateTemplate();
        }

        private ReflectableValidationBuilder CreateTemplate()
        {

            ReflectableValidationBuilder builder = new ReflectableValidationBuilder(new());

            builder.AddValidation(
                 new NotEmptyValidationRule(
                   "Value", Errors.Cpf.EmptyCPF
                 )
            ).AddValidation(
                new CpfLengthValidationRule()
            ).AddValidation(
                new CpfSequentialValidationRule()
            )
            .AddValidation(
               new CpfBaseValidationRule()
            );

            return builder;
        }
    }
}
