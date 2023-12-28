namespace Clean.Architecture.Contracts.InvoiceContracts
{
    public record InvoiceCreateRequest
    (
        DateTime Date,
        ICollection<InvoiceItemCreateRequest> Items
    );
}
