using FonRadar.Application.Invoices.Commands;
using FonRadar.Application.Invoices.Queries;
using FonRadar.Application.Invoices.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FonRadar.Api.Controllers
{
    [Route("[controller]")]
    public class InvoicesController : Controller
    {
        private readonly IMediator _mediator;

        public InvoicesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpGet("{supplierId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetSupplierınvoice(int supplierId)
        {
            return Ok(await _mediator.Send(new GetSupplierInvoiceQuery(supplierId)));
        }

        [HttpGet]
        [Authorize(Roles="Supplier")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetInvoiceQuery()));
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Buyer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteInvoiceCommand(id)));
        }

        [HttpPost]
        [Authorize(Roles="Buyer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] CreateInvoiceRequest request)
        {
            return Ok(await _mediator.Send(new CreateInvoiceCommand(
                request.SupplierId,
                request.InvoiceNumber,
                request.TermDate,
                request.SupplierTaxId,
                request.BuyerTaxId,
                request.InvoiceCost)));
        }
    }
}