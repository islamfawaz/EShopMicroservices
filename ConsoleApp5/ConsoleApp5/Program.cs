using System;
using System.Collections.Generic;

namespace RBSMaxMoves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine()!);

            while (t > 0)
            {
                string s = Console.ReadLine()!;
                int countRound = 0; // Count of valid () pairs
                int countSquare = 0; // Count of valid [] pairs
                Stack<char> stack = new Stack<char>();

                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] == '(' || s[i] == '[')
                    {
                        stack.Push(s[i]); // Push opening brackets onto the stack
                    }
                    else if (s[i] == ')')
                    {
                        if (stack.Count > 0 && stack.Peek() == '(')
                        {
                            countRound++; // Increment count for valid () pair
                            stack.Pop(); // Pop the matching '('
                        }
                    }
                    else if (s[i] == ']')
                    {
                        if (stack.Count > 0 && stack.Peek() == '[')
                        {
                            countSquare++; // Increment count for valid [] pair
                            stack.Pop(); // Pop the matching '['
                        }
                    }
                }

                // The total number of moves is the sum of valid () and [] pairs
                Console.WriteLine(countRound + countSquare);
                t--;
            }
        }
    }
}