using MediatR;

namespace FonRadar.Application.Invoices.Commands
{
    public class CreateInvoiceCommand : IRequest<Unit>
    {
        public int SupplierId { get; }
        public string InvoiceNumber { get; }
        public DateTime TermDate { get; }
        public string BuyerTaxId { get; }
        public string SupplierTaxId { get; }
        public decimal InvoiceCost { get; }

        public CreateInvoiceCommand(
            int supplierId,
            string invoiceNumber,
            DateTime termDate, string buyerTaxId,
            string supplierTaxId, decimal invoiceCost)
        {
            SupplierId = supplierId;
            InvoiceNumber = invoiceNumber;
            TermDate = termDate;
            BuyerTaxId = buyerTaxId;
            SupplierTaxId = supplierTaxId;
            InvoiceCost = invoiceCost;
        }
    }
}