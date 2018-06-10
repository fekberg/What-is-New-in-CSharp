using System;

namespace Span_and_stackalloc
{
    class Program
    {
        static void Main(string[] args)
        {
            Span<int> tickets = stackalloc int[100];

            var sliceOfTickets = tickets.Slice(50, 10);
        }
    }
}
