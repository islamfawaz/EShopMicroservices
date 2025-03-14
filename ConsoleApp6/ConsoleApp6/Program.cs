using System;
using System.Collections;
using System.Numerics;

class Program
{
 
    static void Main(string[] args)
    {
        int n=int.Parse(Console.ReadLine()!);    
       
        int[] arr= new int[n];
        int count= 0;
        for (int i = 0; i < n; i++)
        {
            arr[i] = int.Parse(Console.ReadLine()!);
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = i+1; j < n; j++)
            {

                if ( (arr[i] ^ arr[j]) == 0 )
                {
                    count++;
                }


            }
        }
        if (arr.Length==1)
        {
            count++;
        }
        Console.WriteLine(count);

    }
}