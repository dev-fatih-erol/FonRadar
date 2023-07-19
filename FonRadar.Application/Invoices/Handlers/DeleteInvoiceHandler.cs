using FonRadar.Application.Common.Accessors;
using FonRadar.Application.Common.Exceptions;
using FonRadar.Application.Invoices.Commands;
using FonRadar.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FonRadar.Application.Invoices.Handlers
{
    public class DeleteInvoiceHandler : IRequestHandler<DeleteInvoiceCommand, Unit>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IUserAccessor _userAccessor;

        public DeleteInvoiceHandler(ApplicationDbContext dbContext, IUserAccessor userAccessor)
        {
            _dbContext = dbContext;
            _userAccessor = userAccessor;
        }

        public async Task<Unit> Handle(DeleteInvoiceCommand request, CancellationToken cancellationToken)
        {
            var invoice = await _dbContext.Invoices.Where(i => i.Id == request.InvoiceId && i.BuyerId == _userAccessor.UserId)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (invoice != null)
            {
                _dbContext.Invoices.Remove(invoice);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }

            throw new NotFoundException("Invoice not found.");
        }
    }
}