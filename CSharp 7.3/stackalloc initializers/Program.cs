using System;

namespace stackalloc_initializers
{
    class Program
    {
        static void Main(string[] args)
        {
            Span<int> ticketData = stackalloc [] { 2, 3, 1, 1, 4 };
        }
    }
}
