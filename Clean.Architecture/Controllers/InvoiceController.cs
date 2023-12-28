using Clean.Architecture.Application.Interfaces.UseCases.InvoiceCases.Commands;
using Clean.Architecture.Contracts.InvoiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace Clean.Architecture.Controllers
{
    [ApiController]
    [Route("invoice")]
    public class InvoiceController : BaseApiController
    {
        private readonly IInvoiceCreateCommand _invoiceCreateCommand;

        public InvoiceController(IInvoiceCreateCommand invoiceCreateCommand)
        {
            _invoiceCreateCommand = invoiceCreateCommand;
        }

        [HttpPost]
        public async Task<IActionResult> Post(InvoiceCreateRequest request)
        {
            var result = await _invoiceCreateCommand.Execute(request);
            return result.IsSuccess ? Ok(result.GetValue()) : Problem(result.Error);
        }
    }
}
