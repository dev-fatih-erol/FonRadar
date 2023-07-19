using FonRadar.Application.Common.Accessors;
using FonRadar.Application.Common.Exceptions;
using FonRadar.Application.Invoices.Events;
using FonRadar.Application.Payments.Commands;
using FonRadar.Application.Payments.Events;
using FonRadar.Infrastructure.Domain.Entities;
using FonRadar.Infrastructure.Domain.Enums;
using FonRadar.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FonRadar.Application.Payments.Handlers
{
    public class PaidPaymentHandler : IRequestHandler<PaidPaymentCommand, Unit>
    {
        private readonly IMediator _mediator;
        private readonly ApplicationDbContext _dbContext;
        private readonly IUserAccessor _userAccessor;

        public PaidPaymentHandler(IMediator mediator, ApplicationDbContext dbContext,
            IUserAccessor userAccessor)
        {
            _mediator = mediator;
            _dbContext = dbContext;
            _userAccessor = userAccessor;
        }

        public async Task<Unit> Handle(PaidPaymentCommand request, CancellationToken cancellationToken)
        {
            var payment = await _dbContext.Payments.Where(p => p.FinancialInstitutionId == _userAccessor.UserId && p.Id == request.Id)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (payment != null)
            {
                payment.InvoiceStatus = InvoiceStatus.Paid;

                _dbContext.Payments.Update(payment);
                await _dbContext.SaveChangesAsync(cancellationToken);

                await _mediator.Publish(new PaymentPaidEvent(payment.InvoiceId), cancellationToken);

                return Unit.Value;
            }

            throw new NotFoundException("Payment request not found.");
        }
    }
}