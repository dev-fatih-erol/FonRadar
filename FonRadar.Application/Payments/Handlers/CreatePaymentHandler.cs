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
    public class CreatePaymentHandler : IRequestHandler<CreatePaymentCommand, Unit>
    {
        private readonly IMediator _mediator;
        private readonly ApplicationDbContext _dbContext;

        public CreatePaymentHandler(IMediator mediator, ApplicationDbContext dbContext)
        {
            _mediator = mediator;
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {
            var isExist = await _dbContext.Payments.AnyAsync(p => p.InvoiceId == request.InvoiceId, cancellationToken: cancellationToken);

            if (isExist)
                throw new BadRequestException("An invoice payment request has already been generated for this bill.");

            var payment = new Payment
            {
                InvoiceStatus = InvoiceStatus.Used,
                InvoiceId = request.InvoiceId,
                FinancialInstitutionId = request.FinancialInstitutionId
            };

            await _dbContext.Payments.AddAsync(payment, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);


            await _mediator.Publish(new PaymentCreatedEvent(
                payment.FinancialInstitutionId), cancellationToken);

            return Unit.Value;
        }
    }
}