using FluentValidation;
using FonRadar.Application.Invoices.Requests;

namespace FonRadar.Application.Invoices.Validators
{
    public class CreateInvoiceValidator : AbstractValidator<CreateInvoiceRequest>
    {
		public CreateInvoiceValidator()
		{
            RuleFor(p => p.SupplierId)
              .NotEmpty();

            RuleFor(p => p.InvoiceNumber)
              .NotEmpty()
              .MaximumLength(30);

            RuleFor(p => p.TermDate)
              .NotEmpty();

            RuleFor(p => p.BuyerTaxId)
              .NotEmpty()
              .MaximumLength(30);

            RuleFor(p => p.SupplierTaxId)
              .NotEmpty()
              .MaximumLength(30);

            RuleFor(p => p.InvoiceCost)
              .NotEmpty();
        }
	}
}