using System;

namespace Ranges
{
    class Program
    {
        static void Main(string[] args)
        {
            Span<int> data = stackalloc[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            #region Slice 5..^1

            var slice = data.Slice(5..^1);

            foreach (var number in slice)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine();

            #endregion

            #region Range 1..4

            foreach (var number in data[1..4])
            {
                Console.WriteLine(number);
            }
            Console.WriteLine();

            #endregion

            #region Index ^5
            Index index = ^5;
            Console.WriteLine(data[index]);
            Console.WriteLine();
            #endregion

            #region [first..last]
            var first = ^4;
            var last = ^2;
            foreach (var number in data[first..last])
            {
                Console.WriteLine(number);
            }
            Console.WriteLine();
            #endregion
        }
    }
}

namespace System
{
    static class Extensions
    {
        public static int get_IndexerExtension(this int[] array, Index index) =>
            index.IsFromEnd ? array[array.Length - index.Value] : array[index.Value];

        public static int get_IndexerExtension(this Span<int> span, Index index) =>
            index.IsFromEnd ? span[span.Length - index.Value] : span[index.Value];

        public static char get_IndexerExtension(this string s, Index index) =>
            index.IsFromEnd ? s[s.Length - index.Value] : s[index.Value];

        public static Span<int> get_IndexerExtension(this int[] array, Range range) =>
            array.Slice(range);

        public static Span<int> get_IndexerExtension(this Span<int> span, Range range) =>
            span.Slice(range);

        public static string get_IndexerExtension(this string s, Range range) =>
            s.Substring(range);

        public static Span<T> Slice<T>(this T[] array, Range range)
            => array.AsSpan().Slice(range);

        public static Span<T> Slice<T>(this Span<T> span, Range range)
        {
            var (start, length) = GetStartAndLength(range, span.Length);
            return span.Slice(start, length);
        }

        public static string Substring(this string s, Range range)
        {
            var (start, length) = GetStartAndLength(range, s.Length);
            return s.Substring(start, length);
        }

        private static (int start, int length) GetStartAndLength(Range range, int entityLength)
        {
            var start = range.Start.IsFromEnd ? entityLength - range.Start.Value : range.Start.Value;
            var end = range.End.IsFromEnd ? entityLength - range.End.Value : range.End.Value;
            var length = end - start;

            return (start, length);
        }
    }
}