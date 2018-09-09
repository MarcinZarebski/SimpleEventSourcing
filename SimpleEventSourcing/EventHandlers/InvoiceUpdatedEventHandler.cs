namespace SimpleEventSourcing.EventHandlers
{
    using System.Threading;
    using System.Threading.Tasks;
    using Events;
    using MediatR;
    using Repositories;

    public class InvoiceUpdatedEventHandler : EventHandler, IRequestHandler<InvoiceUpdatedEvent>
    {
        private IInvoiceRepository invoiceRepository;

        public InvoiceUpdatedEventHandler(IInvoiceRepository invoiceRepository, IEventRepository eventRepository)
            :base(eventRepository)
        {
            this.invoiceRepository = invoiceRepository;
        }

        public Task<Unit> Handle(InvoiceUpdatedEvent @event, CancellationToken cancellationToken)
        {
            var invoice = invoiceRepository.GetById(@event.AggregateRootId);
            invoice.Apply(@event);

            invoiceRepository.Update(invoice);
            Save(@event);

            return Unit.Task;
        }
    }
}