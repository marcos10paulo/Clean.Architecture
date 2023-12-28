namespace Clean.Architecture.Contracts.InvoiceContracts
{
    public record InvoiceItemCreateRequest
    (
        string Description,
        double Amount

    );
}
