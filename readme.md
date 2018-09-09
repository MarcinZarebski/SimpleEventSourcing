**Event sourcing** is based on idea of persisting the state of a business entity as a sequence of state-changing events. Whenever the state of a business entity changes, a new event is appended to the list of events. Project **SimpleEventSourcing** contains building blocks used to implement event sourcing. It uses invoices as domain objects and presents how commands, events and handlers can be defined to perform some basic tasks on domain objects. My main goal was to learn about event sourcing and I decided not to implement database repositories, I did not use service layer and I did not add configuration. In this project I focused on understanding concepts of commands, events and handlers.