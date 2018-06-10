using System;

namespace Generic_Constraints
{
    class Program
    {
        static void Main(string[] args)
        {
            var ticket = new Ticket<TicketData, ValidTicketTypes>();
            ticket.IsValidForTransport(ValidTicketTypes.Boat);
        }
    }

    class Ticket<TData, TType> 
        where TData : ITicketData
        where TType : Enum
    {
        public bool IsValidForTransport(TType types) => false;
    }

    public enum ValidTicketTypes
    {
        Bus,
        Boat,
        Train,
        Taxi,
        Spaceship
    }

    interface ITicketData { }

    class TicketData : ITicketData { }
}
