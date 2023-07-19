using FonRadar.Application.Accounts.Commands;
using FonRadar.Application.Accounts.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FonRadar.Api.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class AccountsController : Controller
    {
        private readonly IMediator _mediator;

        public AccountsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody]LoginRequest request)
        {
            return Ok(await _mediator.Send(new LoginCommand(request.Email, request.Password)));
        }
    }
}