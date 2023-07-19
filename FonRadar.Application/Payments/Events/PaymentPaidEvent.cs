using MediatR;

namespace FonRadar.Application.Payments.Events
{
    public class PaymentPaidEvent : INotification
    {
		public int InvoiceId { get; }

		public PaymentPaidEvent(int invoiceId)
		{
			InvoiceId = invoiceId;
		}
	}
}