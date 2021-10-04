using System;
using System.Collections.Generic;
using System.Linq;

namespace MaxRepetitionsElements
{
    class Program
    {
        static int[] ReturnKmaximumReapeatingElements(int k, int[] numbers)
        {
            Dictionary<int, int> repetitions = new Dictionary<int, int>();
            int[] result = new int[k];
            foreach (int number in numbers)
            {
                if (repetitions.ContainsKey(number))
                    repetitions[number]++;
                else
                    repetitions[number] = 0;
            }
            var sortedReps = (from repetition in repetitions orderby repetition.Value descending select repetition).ToList();
            for (int i = 0; i < k; i++)
            {
                result[i] = (sortedReps[i]).Key;
            }

            return result;
        }
        static void Main(string[] args)
        {
            int n = 0, k = 0;
            int[] numbers = Array.Empty<int>();
            if(args.Length == 0)
            {
                Console.WriteLine("How many numbers will be introduced?");
                n = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Introduce Numbers(each per line");
                numbers = new int[n];
                for (int i = 0; i < n; i++)
                {
                    numbers[i] = Convert.ToInt32(Console.ReadLine());
                }
                Console.WriteLine("How many maximum repetitions should be found?");
                k = Convert.ToInt32(Console.ReadLine());
            }
            else
            {
                if(args.Length <= 3)
                {
                    throw new Exception(
                        "You must include the length of the array, length of returned array and the array of elements to read");
                }
                n = Convert.ToInt32(args[0]);
                k = Convert.ToInt32(args[1]);
                numbers = new int[n];
                for (int i = 0; i < n; i++)
                {
                    numbers[i] = Convert.ToInt32(args[i]);
                }
            }
            var res = ReturnKmaximumReapeatingElements(k, numbers);
            Console.Write("[ ");
            foreach (var r in res)
            {
                Console.Write("{0} ", r);
            }

            Console.WriteLine("]");
        }
    }
}
