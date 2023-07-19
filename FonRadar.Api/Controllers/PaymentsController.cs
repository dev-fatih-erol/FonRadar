using FonRadar.Application.Payments.Commands;
using FonRadar.Application.Payments.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FonRadar.Api.Controllers
{
    [Route("[controller]")]
    public class PaymentsController : Controller
    {
        private readonly IMediator _mediator;

        public PaymentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("{id:int}/Paid")]
        [Authorize(Roles = "Financial-Institution")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Paid(int id)
        {
            return Ok(await _mediator.Send(new PaidPaymentCommand(id)));
        }

        [HttpPost]
        [Authorize(Roles = "Supplier")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] CreatePaymentRequest request)
        {
            return Ok(await _mediator.Send(new CreatePaymentCommand(request.FinancialInstitutionId, request.InvoiceId)));
        }
    }
}