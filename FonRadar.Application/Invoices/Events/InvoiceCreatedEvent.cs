using MediatR;

namespace FonRadar.Application.Invoices.Events
{
    public class InvoiceCreatedEvent : INotification
    {
        public int BuyerId { get; }

        public int SupplierId { get; }

        public string InvoiceNumber { get; }

        public decimal InvoiceCost { get; }

        public InvoiceCreatedEvent(int buyerId, int supplierId, string invoiceNumber, decimal invoiceCost)
        {
            BuyerId = buyerId;
            SupplierId = supplierId;
            InvoiceNumber = invoiceNumber;
            InvoiceCost = invoiceCost;
        }
    }
}