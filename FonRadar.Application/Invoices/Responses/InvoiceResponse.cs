namespace FonRadar.Application.Invoices.Responses
{
    public class InvoiceResponse
	{
        public int Id { get; set; }

        public string InvoiceNumber { get; set; }

        public DateTime TermDate { get; set; }

        public string BuyerTaxId { get; set; }

        public string SupplierTaxId { get; set; }

        public decimal InvoiceCost { get; set; }
    }
}