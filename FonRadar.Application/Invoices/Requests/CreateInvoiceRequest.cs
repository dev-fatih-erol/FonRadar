namespace FonRadar.Application.Invoices.Requests
{
    public class CreateInvoiceRequest
	{
        public int SupplierId { get; set; }

        public string InvoiceNumber { get; set; }

        public DateTime TermDate { get; set; }

        public string BuyerTaxId { get; set; }

        public string SupplierTaxId { get; set; }

        public decimal InvoiceCost { get; set; }
    }
}