using FonRadar.Application.Invoices.Responses;
using MediatR;

namespace FonRadar.Application.Invoices.Queries
{
    public class GetInvoiceQuery : IRequest<List<InvoiceResponse>>
    {
	}
}