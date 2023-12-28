using Clean.Architecture.Domain.Validation.ReflectableGenericValidationRules;
using Clean.Architecture.Domain.Validation.ReflectableValidationBuilder;
using Clean.Architecture.Domain.Validation.ReflectionGenericValidationRule;

namespace Clean.Architecture.Domain.Entities.InvoiceItemEntity
{
    public class InvoiceItemValidationBuilder
    {
        public ReflectableValidationBuilder Builder { get; set; }

        public InvoiceItemValidationBuilder()
        {
            Builder = CreateTemplate();
        }

        private ReflectableValidationBuilder CreateTemplate()
        {
            ReflectableValidationBuilder builder = new(new());

            builder
                .AddValidation(new NotEmptyValidationRule("Description", Errors.Errors.InvoiceItem.EmptyDescription))
                .AddValidation(new GreaterThanZeroValidationRule("Amount", Errors.Errors.InvoiceItem.AmountNotInformed))
                .AddValidation(new GreaterThanZeroValidationRule("InvoiceId", Errors.Errors.InvoiceItem.InvoiceNotInformed))
                ;

            return builder;
        }
    }
}
