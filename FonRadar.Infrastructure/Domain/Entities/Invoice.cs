namespace FonRadar.Infrastructure.Domain.Entities
{
    ///<summary>
    /// Represents an invoice.
    ///</summary>
    public class Invoice
    {
        ///<summary>
        /// Gets or sets the unique identifier of the invoice.
        ///</summary>
        public int Id { get; set; }

        ///<summary>
        /// Gets or sets the invoice number.
        ///</summary>
        public string InvoiceNumber { get; set; }

        ///<summary>
        /// Gets or sets the termination date of the invoice.
        ///</summary>
        public DateTime TermDate { get; set; }

        ///<summary>
        /// Gets or sets the tax identification number of the buyer.
        ///</summary>
        public string BuyerTaxId { get; set; }

        ///<summary>
        /// Gets or sets the tax identification number of the supplier.
        ///</summary>
        public string SupplierTaxId { get; set; }

        ///<summary>
        /// Gets or sets the cost of the invoice.
        ///</summary>
        public decimal InvoiceCost { get; set; }

        ///<summary>
        /// Gets or sets the date and time when the invoice was created.
        ///</summary>
        public DateTime CreatedAt { get; set; }


        #region Relations

        ///<summary>
        /// Gets or sets the ID of the associated user for this invoice.
        ///</summary>
        public int BuyerId { get; set; }

        ///<summary>
        /// Gets or sets the user associated with this invoice.
        ///</summary>
        public User Buyer { get; set; }

        ///<summary>
        /// Gets or sets the ID of the associated user for this invoice.
        ///</summary>
        public int SupplierId { get; set; }

        ///<summary>
        /// Gets or sets the user associated with this invoice.
        ///</summary>
        public User Supplier { get; set; }

        public Payment Payment { get; set; }

        #endregion
    }
}