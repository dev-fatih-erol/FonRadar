using MediatR;

namespace FonRadar.Application.Payments.Commands
{
    public class CreatePaymentCommand : IRequest<Unit>
    {
        public int FinancialInstitutionId { get; }
		public int InvoiceId { get; }

		public CreatePaymentCommand(int financialInstitutionId, int invoiceId)
		{
			FinancialInstitutionId = financialInstitutionId;
			InvoiceId = invoiceId;
		}
	}
}