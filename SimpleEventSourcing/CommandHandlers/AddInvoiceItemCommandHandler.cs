namespace SimpleEventSourcing.CommandHandlers
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Commands;
    using Infrastructure;
    using MediatR;
    using Repositories;

    public class AddInvoiceItemCommandHandler : IRequestHandler<AddInvoiceItemCommand, Guid>
    {
        private IPublisher publisher;
        private IInvoiceRepository invoiceRepository;

        public AddInvoiceItemCommandHandler(IPublisher publisher, IInvoiceRepository invoiceRepository)
        {
            this.publisher = publisher;
            this.invoiceRepository = invoiceRepository;
        }

        public async Task<Guid> Handle(AddInvoiceItemCommand command, CancellationToken cancellationToken)
        {
            var invoice = invoiceRepository.GetById(command.InvoiceId);
            invoice.AddItem(command.Price, command.Quantity);

            await publisher.Publish(invoice.GetEvents());

            return invoice.Id;
        }
    }
}