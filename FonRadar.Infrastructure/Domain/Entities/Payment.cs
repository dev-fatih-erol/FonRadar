using FonRadar.Infrastructure.Domain.Enums;

namespace FonRadar.Infrastructure.Domain.Entities
{
    public class Payment
	{
        public int Id { get; set; }

        public InvoiceStatus InvoiceStatus { get; set; }

        public DateTime CreatedAt { get; set; }


        #region Relations

        public int InvoiceId { get; set; }

        public Invoice Invoice { get; set; }


        public int FinancialInstitutionId { get; set; }

        public User FinancialInstitution { get; set; }

        #endregion Relations
    }
}