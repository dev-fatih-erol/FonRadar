using MediatR;

namespace FonRadar.Application.Payments.Events
{
    public class PaymentCreatedEvent : INotification
    {
        public int FinancialInstitutionId { get; }

        public PaymentCreatedEvent(int financialInstitutionId)
		{
            FinancialInstitutionId = financialInstitutionId;
		}
	}
}