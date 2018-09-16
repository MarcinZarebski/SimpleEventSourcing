namespace SimpleEventSourcing.CommandHandlers
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Commands;
    using Infrastructure;
    using MediatR;
    using Repositories;

    public class AddListOfInvoiceItemsCommandHandler : IRequestHandler<AddListOfInvoiceItemsCommand, Guid>
    {
        private IPublisher publisher;
        private IInvoiceRepository invoiceRepository;

        public async Task<Guid> Handle(AddListOfInvoiceItemsCommand command, CancellationToken cancellationToken)
        {
            var invoice = invoiceRepository.GetById(command.InvoiceId);
            invoice.AddItems(command.InvoiceItems);

            await publisher.Publish(invoice.GetEvents());

            return invoice.Id;
        }
    }
}
