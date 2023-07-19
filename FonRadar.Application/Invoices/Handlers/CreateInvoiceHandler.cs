using FonRadar.Application.Common.Accessors;
using FonRadar.Application.Common.Exceptions;
using FonRadar.Application.Invoices.Commands;
using FonRadar.Application.Invoices.Events;
using FonRadar.Infrastructure.Domain.Entities;
using FonRadar.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FonRadar.Application.Invoices.Handlers
{
    public class CreateInvoiceHandler : IRequestHandler<CreateInvoiceCommand, Unit>
    {
        private readonly IMediator _mediator;
        private readonly ApplicationDbContext _dbContext;
        private readonly IUserAccessor _userAccessor;

        public CreateInvoiceHandler(IMediator mediator, ApplicationDbContext dbContext,
            IUserAccessor userAccessor)
        {
            _mediator = mediator;
            _dbContext = dbContext;
            _userAccessor = userAccessor;
        }

        public async Task<Unit> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {
            var isExist = await _dbContext.Invoices.AnyAsync(i => i.InvoiceNumber == request.InvoiceNumber, cancellationToken: cancellationToken);

            if (isExist)
                throw new BadRequestException("This invoice has already been added.");
            
            var invoice = new Invoice
            {
                InvoiceNumber = request.InvoiceNumber,
                TermDate = request.TermDate,
                BuyerTaxId = request.BuyerTaxId,
                SupplierTaxId = request.SupplierTaxId,
                InvoiceCost = request.InvoiceCost,
                BuyerId = _userAccessor.UserId,
                SupplierId = request.SupplierId
            };

            await _dbContext.Invoices.AddAsync(invoice, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            await _mediator.Publish(new InvoiceCreatedEvent(
                invoice.BuyerId,
                invoice.SupplierId,
                invoice.InvoiceNumber,
                invoice.InvoiceCost), cancellationToken);

            return Unit.Value;
        }
    }
}