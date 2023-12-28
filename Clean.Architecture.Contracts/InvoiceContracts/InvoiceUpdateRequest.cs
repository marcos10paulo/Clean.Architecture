namespace Clean.Architecture.Contracts.InvoiceContracts
{
    public record InvoiceUpdateRequest
    (
        int Id,
        DateTime Date,
        ICollection<InvoiceItemUpdateRequest> Items
    );
}
