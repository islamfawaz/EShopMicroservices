using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int t = int.Parse(Console.ReadLine());
        while (t-- > 0)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = input[0];
            int x = input[1];

            int[] result = new int[n];
            int mex = 0;

            for (int i = 0; i < n; i++)
            {
                result[i] = i;
                mex = i + 1; 
            }

            int currentOr = result.Aggregate(0, (acc, val) => acc | val);
            if (currentOr != x)
            {
                result[n - 1] |= (x ^ currentOr);
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}