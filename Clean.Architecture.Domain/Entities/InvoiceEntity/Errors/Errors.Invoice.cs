using Clean.Architecture.Domain.Validation.ErrorBase;

namespace Clean.Architecture.Domain.Entities.InvoiceEntity.Errors
{
    public static partial class Errors
    {
        public static class Invoice
        {
            public static Error InvalidDate = Error.Validation(
                code: "Invoice.InvalidDate",
                description: "Data inválida!"
            );
        }
    }
}
