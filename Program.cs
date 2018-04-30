using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace ModHeapsort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input 10 numbers");
            int[] input = new int[10];
            for (int i = 0; i <= 9; i++)
            {
                input[i] = int.Parse(Console.ReadLine());
            }
            Stopwatch stopwatch = new Stopwatch();
            // Begin timing.
            stopwatch.Start();
            TernaryHeapSort(input);
            stopwatch.Stop();
            Console.WriteLine("\nTime elapsed: {0}", stopwatch.Elapsed);
            Console.ReadKey();
        }

        public static void buildMaxHeap(int heapSize,int[] input)
        {
            for (int p = (heapSize /2)-1; p >= 0; p--)
                MaxHeapify(input, heapSize, p);
        }
        public static void Swap(int[] input, int index1, int index2)
        {
            int temp = input[index1];
            input[index1] = input[index2];
            input[index2] = temp;
        }
        public static void TernaryHeapSort(int[] input)
        {
            int heapSize = input.Length;
            buildMaxHeap(heapSize,input);
            for (int i = input.Length - 1; i > 0; i--)
            {
                Swap(input,i,0);
                heapSize--;
                MaxHeapify(input, heapSize, 0);
            }

            for (int i = 0; i <= (input.Length - 1); i++)
                Console.Write(input[i] + " ");
        }
        private static void MaxHeapify(int[] input, int heapSize, int index)
        {
            int child = index * 2 + 1; /* get its left child index */
            while (child < heapSize) 
            {
                /* choose the largest child */
                if (child + 1 < heapSize  &&  input[child + 1] > input[child])
                {
                    child++; /* right child exists and is bigger */
                }
                /* is the largest child larger than the entry? */
                if (input[child] > index)
                {
                    int temp = input[index];
                    input[index] = input[child];
                    input[child] = temp;
                    index = child; /* move index to the child */
                    child = index * 2 + 1; /* get the left child and go around again */
                } 
                else 
                {
                    break; /* t's place is found */
                }
            }
            /* store the temporary value at its new location */; 
        }

        }
        
        
    }

