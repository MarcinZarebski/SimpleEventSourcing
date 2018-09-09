namespace SimpleEventSourcing.Models
{
    using System;
    using System.Collections.Generic;
    using Events;
    using Microsoft.EntityFrameworkCore.Internal;

    public class Invoice : AggregateRoot
    {
        public DateTime IssueDate { get; set; }

        public int InvoiceNumber { get; set; }

        public string CustomerFullName { get; set; }

        public string CustomerAddress { get; set; }

        public List<InvoiceItem> Items { get; set; }

        private Invoice()
        {
            RegisterEvents();
        }

        public static Invoice CreateEmpty()
        {
            return new Invoice();
        }

        public Invoice(string customerFullName, string customerAddress)
        {
            EnsureEventsAreRegistered();
            Raise(new InvoiceCreatedEvent(Id, customerFullName, customerAddress));
        }

        public void Update(string customerFullName, string customerAddress)
        {
            EnsureEventsAreRegistered();
            Raise(new InvoiceUpdatedEvent(Id, customerFullName, customerAddress));
        }

        public void AddItem(int price, int quantity)
        {
            EnsureEventsAreRegistered();
            Raise(new InvoiceItemAddedEvent(Id, price, quantity));
        }

        private void EnsureEventsAreRegistered()
        {
            var events = GetEvents();
            if (events == null || events.Any())
            {
                RegisterEvents();
            }
        }

        private void RegisterEvents()
        {
            Register<InvoiceCreatedEvent>(When);
            Register<InvoiceUpdatedEvent>(When);
            Register<InvoiceItemAddedEvent>(When);
        }

        protected void When(InvoiceCreatedEvent @event)
        {
            Id = @event.AggregateRootId;
            CustomerFullName = @event.CustomerFullName;
            CustomerAddress = @event.CustomerAddress;
        }

        protected void When(InvoiceUpdatedEvent @event)
        {
            CustomerFullName = @event.CustomerFullName;
            CustomerAddress = @event.CustomerAddress;
        }

        private void When(InvoiceItemAddedEvent @event)
        {
            Id = @event.AggregateRootId;
            var invoiceItem =  new InvoiceItem
            {
                Price =  @event.Price,
                Quantity = @event.Quantity
            };

            Items.Add(invoiceItem);
        }
    }
}