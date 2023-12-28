using Clean.Architecture.Domain.Validation.ReflectableGenericValidationRules;
using Clean.Architecture.Domain.Validation.ReflectableValidationBuilder;

namespace Clean.Architecture.Domain.Entities.InvoiceEntity
{
    public class InvoiceValidationBuilder
    {
        public ReflectableValidationBuilder Builder { get; set; }

        public InvoiceValidationBuilder()
        {
            Builder = CreateTemplate();
        }

        private ReflectableValidationBuilder CreateTemplate()
        {
            ReflectableValidationBuilder builder = new(new());

            builder.AddValidation(
                new GreaterThanMinDateValidationRule("Date", Errors.Errors.Invoice.InvalidDate)
            );

            return builder;
        }
    }
}
