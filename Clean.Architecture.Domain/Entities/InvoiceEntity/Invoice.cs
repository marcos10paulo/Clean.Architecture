using Clean.Architecture.Domain.Entities.InvoiceItemEntity;
using Clean.Architecture.Domain.Validation.ErrorBase;

namespace Clean.Architecture.Domain.Entities.InvoiceEntity
{
    public class Invoice : BaseEntity
    {
        public DateTime Date {  get; private set; }
        public virtual ICollection<InvoiceItem> InvoiceItems { get; private set; }

        public Invoice() 
        { 
            InvoiceItems = new HashSet<InvoiceItem>();
        }

        private Invoice(DateTime date, ICollection<InvoiceItem> invoiceItems)
        {
            Date = date;
            InvoiceItems = invoiceItems;
        }

        public static Result<Invoice> Create(DateTime date, ICollection<InvoiceItem> invoiceItems = null)
        {
            var invoice = new Invoice(date, invoiceItems);

            return new InvoiceValidationBuilder().Builder.ValidateBatch(invoice);
        }

        public void AddItem(InvoiceItem item)
        {
            InvoiceItems.Add(item);
        }        
    }
}
