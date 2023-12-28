using Clean.Architecture.Domain.Validation.ErrorBase;

namespace Clean.Architecture.Domain.Entities.InvoiceItemEntity.Errors
{
    public static partial class Errors
    {
        public static class InvoiceItem
        {
            public static Error EmptyDescription = Error.Validation(
                code: "InvoiceItem.EmptyDescription",
                description: "Descrição não informada!"
            );

            public static Error AmountNotInformed = Error.Validation(
                code: "InvoiceItem.AmountNotInformed",
                description: "Quantidade não informada!"
            );

            public static Error InvoiceNotInformed = Error.Validation(
                code: "InvoiceItem.InvoiceNotInformed",
                description: "Nota fiscal não informada!"
            );
        }
    }
}
