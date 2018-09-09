namespace SimpleEventSourcing.EventHandlers
{
    using System.Threading;
    using System.Threading.Tasks;
    using Events;
    using MediatR;
    using Repositories;

    public class InvoiceItemAddedEventHandler : EventHandler, IRequestHandler<InvoiceItemAddedEvent>
    {
        private IInvoiceRepository invoiceRepository;

        public InvoiceItemAddedEventHandler(IInvoiceRepository invoiceRepository, IEventRepository eventRepository)
            :base(eventRepository)
        {
            this.invoiceRepository = invoiceRepository;
        }

        public Task<Unit> Handle(InvoiceItemAddedEvent @event, CancellationToken cancellationToken)
        {
            var invoice = invoiceRepository.GetById(@event.AggregateRootId);
            invoice.Apply(@event);

            invoiceRepository.UpdateItems(invoice.Items);
            Save(@event);

            return Unit.Task;
        }
    }
}
