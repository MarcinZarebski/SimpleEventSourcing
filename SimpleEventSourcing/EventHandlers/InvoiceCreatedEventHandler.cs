namespace SimpleEventSourcing.EventHandlers
{
    using System.Threading;
    using System.Threading.Tasks;
    using Events;
    using MediatR;
    using Models;
    using Repositories;

    public class InvoiceCreatedEventHandler : EventHandler, IRequestHandler<InvoiceCreatedEvent>
    {
        private IInvoiceRepository invoiceRepository;

        public InvoiceCreatedEventHandler(IInvoiceRepository invoiceRepository, IEventRepository eventRepository)
            : base(eventRepository)
        {
            this.invoiceRepository = invoiceRepository;
        }

        public Task<Unit> Handle(InvoiceCreatedEvent @event, CancellationToken cancellationToken)
        {
            var invoice = Invoice.CreateEmpty();
            invoice.Apply(@event);

            invoiceRepository.Add(invoice);
            Save(@event);

            return Unit.Task;
        }
    }
}