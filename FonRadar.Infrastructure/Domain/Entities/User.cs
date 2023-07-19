using Microsoft.AspNetCore.Identity;

namespace FonRadar.Infrastructure.Domain.Entities
{
    public class User : IdentityUser<int>
    {
        public string Name { get; set; }


        #region Relations

        public List<Invoice> BuyerInvoice { get; set; }

        public List<Invoice> SupplierInvoice { get; set; }

        public List<Payment> FinancialInstitutionPayment { get; set; }

        #endregion
    }
}