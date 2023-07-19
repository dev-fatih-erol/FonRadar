namespace FonRadar.Application.Payments.Requests
{
    public class CreatePaymentRequest
	{
        public int FinancialInstitutionId { get; set; }

        public int InvoiceId { get; set; }
    }
}