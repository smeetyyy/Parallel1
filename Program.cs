using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AssignmentP1
{
    class Program
    {

        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            int[] bigArray = new int[100000];
            Random rnd = new Random();

            for (int i = 0; i < bigArray.Length; i++)
            {
                bigArray[i] = rnd.Next(0, 100000);

            }
            
            Thread[] t = new Thread[6];

            int k = 0;

            for (int i = 0; i < 6; i++)
            {
                int[] tmp = new int[bigArray.Length / 6];
                for (int j = 0; j < tmp.Length; j++)
                {
                    tmp[j] = bigArray[k];
                    k++;
                }
                Thread myT = new Thread(() => BubbleSort(tmp));
                t[i] = myT;
                t[i].Start();
            }
            stopwatch.Stop();
            
            Console.WriteLine($"Time elapsed: {stopwatch.Elapsed.Milliseconds}");
            Console.ReadKey();
        }

        static void BubbleSort(int [] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                //Console.WriteLine($"Im doing some" + $"work from thread {i}" + $"Thread ID:{Thread.CurrentThread.ManagedThreadId}");
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    //Console.WriteLine($"Im doing some" + $"work from thread {j}" + $"Thread ID:{Thread.CurrentThread.ManagedThreadId}");
                    if (arr[j + 1] < arr[j])
                    {
                        int tmp = arr[j + 1];
                        arr[j + 1] = arr[j];
                        arr[j] = tmp;
                    }
                }
            }
        }
    }
}