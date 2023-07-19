using FonRadar.Application.Invoices.Responses;
using MediatR;

namespace FonRadar.Application.Invoices.Queries
{
    public class GetSupplierInvoiceQuery : IRequest<List<InvoiceResponse>>
    {
		public int SupplierId { get; }

		public GetSupplierInvoiceQuery(int supplierId)
		{
			SupplierId = supplierId;
		}
	}
}