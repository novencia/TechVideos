using System;
using System.Diagnostics;

namespace BigOExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");
            Console.WriteLine($"Stopwatch precision is : {1E9 / Stopwatch.Frequency} ns, High Resolution:{(Stopwatch.IsHighResolution ? "Enabled": "Disabled")}");
            Console.WriteLine();
            var muliplication = new MultiplyClass();

            muliplication.MultiplyNumbers(1, 1);
            muliplication.MultiplyNumbers(10, 10);
            muliplication.MultiplyNumbers(100, 100);
            muliplication.MultiplyNumbers(1000, 1000);
            muliplication.MultiplyNumbers(10000, 10000);
            muliplication.MultiplyNumbers(100000, 100000);
            muliplication.MultiplyNumbers(1000000, 1000000);

            Console.WriteLine();

            muliplication.MultiplyNumbersHighComplexity(1, 1);
            muliplication.MultiplyNumbersHighComplexity(10, 10);
            muliplication.MultiplyNumbersHighComplexity(100, 100);
            muliplication.MultiplyNumbersHighComplexity(1000, 1000);
            muliplication.MultiplyNumbersHighComplexity(10000, 10000);
            muliplication.MultiplyNumbersHighComplexity(100000, 100000);
            muliplication.MultiplyNumbersHighComplexity(1000000, 1000000);

            Console.WriteLine();

            muliplication.MultiplyNumbersVeryHighComplexity(1, 1);
            muliplication.MultiplyNumbersVeryHighComplexity(10, 10);
            muliplication.MultiplyNumbersVeryHighComplexity(100, 100);
            muliplication.MultiplyNumbersVeryHighComplexity(1000, 1000);
            muliplication.MultiplyNumbersVeryHighComplexity(10000, 10000);
            muliplication.MultiplyNumbersVeryHighComplexity(100000, 100000);
            muliplication.MultiplyNumbersVeryHighComplexity(1000000, 1000000);

            Console.WriteLine("End");

        }

        public class MultiplyClass
        {
            private readonly Stopwatch _sw;
            public MultiplyClass()
            {
                _sw = new Stopwatch();
                _sw.Start();
                _sw.Stop();
                _sw.Reset();
            }

            public long MultiplyNumbers(long firstNumber, long secondNumber)
            {
                _sw.Start();

                long result = firstNumber * secondNumber;

                _sw.Stop();
                Console.WriteLine($"MultiplyNumbers Got {result} for {firstNumber}*{secondNumber} in {FormatStopWatch(_sw)}");
                _sw.Reset();
                return result;
            }

            public long MultiplyNumbersHighComplexity(long firstNumber, long secondNumber)
            {
                _sw.Start();

                long result = 0;
                for (long i = 0; i < secondNumber; i++)
                {
                    result += firstNumber;
                }

                _sw.Stop();
                Console.WriteLine($"MultiplyNumbersHighComplexity Got {result} for {firstNumber}*{secondNumber} in {FormatStopWatch(_sw)}");
                _sw.Reset();
                return result;
            }

            public long MultiplyNumbersVeryHighComplexity(long firstNumber, long secondNumber)
            {
                _sw.Start();

                long result = 0;
                for (long i = 0; i < secondNumber; i++)
                {
                    for (long j = 0; j < firstNumber; j++)
                    {
                        result += 1;
                    }
                }

                _sw.Stop();
                Console.WriteLine($"MultiplyNumbersVeryHighComplexity Got {result} for {firstNumber}*{secondNumber} in {FormatStopWatch(_sw)}");
                _sw.Reset();
                return result;
            }

            public string FormatStopWatch(Stopwatch sw)
            {
                var nanoSeconds = (double)sw.ElapsedTicks / Stopwatch.Frequency * 1E9;
                var microSeconds = (double)sw.ElapsedTicks / Stopwatch.Frequency * 1E6;
                var milliSeconds = (double)sw.ElapsedTicks / Stopwatch.Frequency * 1E3;
                var seconds = (double)sw.ElapsedTicks / Stopwatch.Frequency;

                if (((int)seconds) != 0)
                {
                    return $"{seconds} s";
                }

                if (((int)milliSeconds) != 0)
                {
                    return $"{milliSeconds} ms";
                }

                if (((int)microSeconds) != 0)
                {
                    return $"{microSeconds} µs";
                }

                return $"{nanoSeconds} ns";
            }
        }
    }
}
