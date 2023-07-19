using FonRadar.Application.Invoices.Events;
using FonRadar.Application.Notifications.Hubs;
using FonRadar.Application.Payments.Events;
using FonRadar.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace FonRadar.Application.Notifications.Handlers
{
    public class NotificationHandler : INotificationHandler<InvoiceCreatedEvent>,
                                       INotificationHandler<PaymentCreatedEvent>,
                                       INotificationHandler<PaymentPaidEvent>
    {
        private readonly IHubContext<NotificationHub> _hubContext;
        private readonly ApplicationDbContext _dbContext;

        public NotificationHandler(IHubContext<NotificationHub> hubContext, ApplicationDbContext dbContext)
		{
            _hubContext = hubContext;
            _dbContext = dbContext;
        }

        public async Task Handle(InvoiceCreatedEvent notification, CancellationToken cancellationToken)
        {
            await _hubContext.Clients.User(notification.SupplierId.ToString())
                .SendAsync($"BuyerId: {notification.BuyerId} created an invoice. " +
                $"Invoice Number: {notification.InvoiceNumber}, Invoice Cost: {notification.InvoiceCost}, ",
                cancellationToken);
        }

        public async Task Handle(PaymentCreatedEvent notification, CancellationToken cancellationToken)
        {
            await _hubContext.Clients.User(notification.FinancialInstitutionId.ToString())
                .SendAsync($"New payment request has been created",
                cancellationToken);
        }

        public async Task Handle(PaymentPaidEvent notification, CancellationToken cancellationToken)
        {
            var invoice = await _dbContext.Invoices.FirstOrDefaultAsync(i => i.Id == notification.InvoiceId);
            await _hubContext.Clients.User(invoice.SupplierId.ToString())
                .SendAsync($"Your invoice payment has been made. Invoice Number: {invoice.InvoiceNumber}",
                cancellationToken);
        }
    }
}