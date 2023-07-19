using MediatR;

namespace FonRadar.Application.Invoices.Commands
{
    public class DeleteInvoiceCommand : IRequest<Unit>
    {
		public int InvoiceId { get; }

		public DeleteInvoiceCommand(int invoiceId)
		{
			InvoiceId = invoiceId;
		}
	}
}