namespace Clean.Architecture.Contracts.InvoiceContracts
{
    public record InvoiceItemUpdateRequest
    (
        int Id,
        string Description,
        double Amount,
        int InvoiceId
    );
}
