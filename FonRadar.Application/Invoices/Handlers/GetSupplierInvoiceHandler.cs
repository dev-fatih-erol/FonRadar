using FonRadar.Application.Invoices.Queries;
using FonRadar.Application.Invoices.Responses;
using FonRadar.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FonRadar.Application.Invoices.Handlers
{
    public class GetSupplierInvoiceHandler : IRequestHandler<GetSupplierInvoiceQuery, List<InvoiceResponse>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetSupplierInvoiceHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<InvoiceResponse>> Handle(GetSupplierInvoiceQuery request, CancellationToken cancellationToken)
        {
            var invoices = await _dbContext.Invoices.Where(i => i.SupplierId == request.SupplierId)
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