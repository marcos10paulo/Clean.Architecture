using Clean.Architecture.Domain.Entities.InvoiceEntity;
using Clean.Architecture.Domain.Entities.UserEntity;
using Clean.Architecture.Domain.Validation.ErrorBase;
using System.Text.Json.Serialization;

namespace Clean.Architecture.Domain.Entities.InvoiceItemEntity
{
    public class InvoiceItem : BaseEntity
    {
        public string Description { get; private set; }
        public double Amount { get; private set; }
        public int InvoiceId { get; private set; }

        [JsonIgnore]
        public Invoice Invoice { get; set; }

        public InvoiceItem() { }

        private InvoiceItem(string description, double amount, int invoiceId, int id)
        {
            Description = description;
            Amount = amount;
            InvoiceId = invoiceId;
            Id = id;
        }

        public static Result<InvoiceItem> Create(string description, double amount, int invoiceId, int id = 0)
        {
            var invoiceItem = new InvoiceItem(description, amount, invoiceId, id);

            return new InvoiceItemValidationBuilder().Builder.ValidateBatch(invoiceItem);
        }
    }
}
