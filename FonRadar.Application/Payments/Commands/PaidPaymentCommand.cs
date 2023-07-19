using MediatR;

namespace FonRadar.Application.Payments.Commands
{
    public class PaidPaymentCommand : IRequest<Unit>
    {
		public int Id { get; }

		public PaidPaymentCommand(int id)
		{
			Id = id;
		}
	}
}