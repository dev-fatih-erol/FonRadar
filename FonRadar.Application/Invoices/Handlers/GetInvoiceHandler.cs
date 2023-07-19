using FonRadar.Application.Common.Accessors;
using FonRadar.Application.Invoices.Queries;
using FonRadar.Application.Invoices.Responses;
using FonRadar.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FonRadar.Application.Invoices.Handlers
{
    public class GetInvoiceHandler : IRequestHandler<GetInvoiceQuery, List<InvoiceResponse>>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IUserAccessor _userAccessor;

        public GetInvoiceHandler(ApplicationDbContext dbContext,
            IUserAccessor userAccessor)
        {
            _dbContext = dbContext;
            _userAccessor = userAccessor;
        }

        public async Task<List<InvoiceResponse>> Handle(GetInvoiceQuery request, CancellationToken cancellationToken)
        {
            var invoices = await _dbContext.Invoices.Where(i => i.SupplierId == _userAccessor.UserId)
                .OrderByDescending(i => i.CreatedAt)
                .ToListAsync(cancellationToken: cancellationToken);

            var response = invoices.Select(i => new InvoiceResponse
            {
                Id = i.Id,
                InvoiceNumber = i.InvoiceNumber,
                TermDate = i.TermDate,
                BuyerTaxId = i.BuyerTaxId,
                SupplierTaxId = i.SupplierTaxId,
                InvoiceCost = i.InvoiceCost
            }).ToList();

            return response;
        }
    }
}