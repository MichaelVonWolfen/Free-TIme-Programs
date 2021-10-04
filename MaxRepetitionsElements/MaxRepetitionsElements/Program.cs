using System;

namespace MaxRepetitionsElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int n, k;
            int[] numbers;
            if(args.Length == 0)
            {
                //TODO Read all variables data from the console
            }
            else
            {
                //TODO Read all variables from args
                if(args.Length !> 3)
                {
                    throw new Exception("You must include the length of the returned array and the array of elements to read")
                }
            }
        }
    }
}
