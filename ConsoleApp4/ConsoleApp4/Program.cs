using System;
using System.Collections.Generic;

namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine()!);

            while (t > 0)
            {
                int counter = 0;
                string str = Console.ReadLine()!;
                Stack<char> stack = new Stack<char>();

                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] == '(' || str[i] == '[')
                    {
                        stack.Push(str[i]); // Push opening characters onto the stack
                    }
                    else if (str[i] == ')' || str[i] == ']')
                    {
                        if (stack.Count > 0) // Ensure the stack is not empty
                        {
                            char top = stack.Peek(); // Get the top character from the stack

                            // Check for valid pairs
                            if ((str[i] == ')' && top == '(') || (str[i] == ']' && top == '['))
                            {
                                counter++; // Increment counter for a valid pair
                                stack.Pop(); // Pop the matching opening character
                            }
                            else
                            {
                                // If the closing character doesn't match the top of the stack, push it
                                stack.Push(str[i]);
                            }
                        }
                        else
                        {
                            // If the stack is empty, push the closing character
                            stack.Push(str[i]);
                        }
                    }
                }

                Console.WriteLine(counter); // Output the count of valid pairs
                t--;
            }
        }
    }
}