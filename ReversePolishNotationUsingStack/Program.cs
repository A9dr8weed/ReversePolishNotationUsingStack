using System;
using System.Collections;

namespace ReversePolishNotationUsingStack
{
    public static class Program
    {
        private static void RpnLoop()
        {
            while (true)
            {
                Console.Write("> ");

                string input = Console.ReadLine();
                // If input == "quit", exit from loop.
                if (string.Equals(input.Trim(), "quit", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                // The stack of values that have not yet been processed.
                Stack values = new Stack();

                // Enter input data via space.
                foreach (string token in input.Split(new char[] { ' ' }))
                {
                    // If the value is an integer.
                    if (int.TryParse(token, out int value))
                    {
                        // Put it on the stack.
                        values.Push(value);
                    }
                    else
                    {
                        // Otherwise, perform the operation.
                        int rhs = (int)values.Pop();
                        int lhs = (int)values.Pop();

                        // And put the result back.
                        switch (token)
                        {
                            case "+":
                                values.Push(lhs + rhs);
                                break;
                            case "-":
                                values.Push(lhs - rhs);
                                break;
                            case "*":
                                values.Push(lhs * rhs);
                                break;
                            case "/":
                                values.Push(lhs / rhs);
                                break;
                            case "%":
                                values.Push(lhs % rhs);
                                break;
                            default:
                                // If the operation is not +, -, * or /
                                throw new ArgumentException($"Unrecognized token: {token}");
                        }
                    }
                }

                // The last item on the stack is the result.
                Console.WriteLine(values.Peek());
            }
        }

        private static void Main()
        {
            RpnLoop();
        }
    }
}