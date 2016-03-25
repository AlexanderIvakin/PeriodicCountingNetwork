using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PeriodicCountingNetwork
{
    class Program
    {
        static void Main(string[] args)
        {
            const int width = 4;
            var periodic = new Periodic(width);
            var counters = new int[width];

            const int tokenCount = 893235;
            var tokens = new int[tokenCount];

            var rand = new Random();
            var randLock = new object();
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            Parallel.For(0, tokenCount, (i) =>
            {
                int next;
                lock (randLock)
                {
                    next = rand.Next(width);
                }
                tokens[i] = next;
            });
            stopWatch.Stop();
            var inputGeneration = stopWatch.Elapsed;

            stopWatch.Restart();
            Parallel.For(0, tokenCount, (i) =>
            {
                Interlocked.Increment(ref counters[periodic.Traverse(tokens[i])]);
            });
            var traversing = stopWatch.Elapsed;

            stopWatch.Restart();
            for (var i = 0; i < width; ++i)
            {
                Console.WriteLine($"Output: {i} Count: {counters[i]}");
            }
            stopWatch.Stop();
            var outputing = stopWatch.Elapsed;

            Console.WriteLine($"Time to generate the input: {inputGeneration.ToString("mm\\:ss\\.fffffff")}.");
            Console.WriteLine($"Time to traverse the network: {traversing.ToString("mm\\:ss\\.fffffff")}.");
            Console.WriteLine($"Time to output to console: {outputing.ToString("mm\\:ss\\.fffffff")}.");

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
