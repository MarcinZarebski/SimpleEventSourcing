namespace SimpleEventSourcing.ProcessManagers
{
    using System;
    using System.Collections.Generic;
    using Commands;
    using Enums;
    using Events;
    using MediatR;
    using Models;

    public class AddInvoiceWithItemsProcessManager
    {
        public Guid InvoiceId { set; get; }

        public AddInvoiceWithItemsProcessState State;

        private List<IRequest<Guid>> commands;

        public AddInvoiceWithItemsProcessManager()
        {
            State = AddInvoiceWithItemsProcessState.NotStarted;
            commands = new List<IRequest<Guid>>();
        }

        public string CustomerFullName { get; set; }
        public string CustomerAddress { get; set; }

        public List<InvoiceItem> InvoiceItems { get; set; }


        public void When(InvoiceCreatedEvent @event)
        {
            switch (State)
            {
                case AddInvoiceWithItemsProcessState.NotStarted:
                    var createCommand = GetCreateCommand();
                    AddCommand(createCommand);
                    break;
                case AddInvoiceWithItemsProcessState.InvoiceCreated:
                    break;
                default:
                    throw new NotAllowedOperationException();
            }
        }

        public void When(ListOfInvoiceItemsAddedEvent @event)
        {
            switch (State)
            {
                case AddInvoiceWithItemsProcessState.InvoiceCreated:
                    var addItemsCommand = GetAddItemsCommand();
                    AddCommand(addItemsCommand);
                    break;
                case AddInvoiceWithItemsProcessState.InvoiceItemsAdded:
                    break;
                default:
                    throw new NotAllowedOperationException();
            }
        }

        private AddListOfInvoiceItemsCommand GetAddItemsCommand()
        {
            return new AddListOfInvoiceItemsCommand(InvoiceId, InvoiceItems);
        }

        private CreateInvoiceCommand GetCreateCommand()
        {
            return new CreateInvoiceCommand(CustomerFullName, CustomerAddress);
        }

        private void AddCommand(IRequest<Guid> command)
        {
            commands.Add(command);
        }
    }
}