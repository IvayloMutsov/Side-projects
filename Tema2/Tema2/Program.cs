using System;
using System.Collections.Generic;

namespace Tema2
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Enter a mathematical expression or type 'quit' to exit: ");
                string input = Console.ReadLine();

                if (input.ToLower() == "quit")
                {
                    break;
                }

                if (EvaluateExpression(input))
                {
                    Console.WriteLine("Result: " + result);
                }
                else
                {
                    Console.WriteLine("Invalid expression.");
                }

                result = 0;
            }
        }

        static bool IsOperator(char c)
        {
            return c == '+' || c == '-' || c == '*' || c == '/';
        }

        static bool EvaluateExpression(string expression)
        {
            expression = expression.Replace(" ", "");

            Stack<double> operands = new Stack<double>();
            Stack<char> operators = new Stack<char>();

            for (int i = 0; i < expression.Length; i++)
            {
                char c = expression[i];

                if (char.IsDigit(c))
                {
                    double num = 0;
                    while (i < expression.Length && char.IsDigit(expression[i]))
                    {
                        num = num * 10 + (expression[i] - '0');
                        i++;
                    }
                    i--;
                    operands.Push(num);
                }
                else if (IsOperator(c))
                {
                    while (operators.Count > 0 && operators.Peek() != '(' && Precedence(operators.Peek()) >= Precedence(c))
                    {
                        char op = operators.Pop();
                        double b = operands.Pop();
                        double a = operands.Pop();

                        operands.Push(Calculate(a, b, op));
                    }

                    operators.Push(c);
                }
                else if (c == '(')
                {
                    operators.Push(c);
                }
                else if (c == ')')
                {
                    while (operators.Count > 0 && operators.Peek() != '(')
                    {
                        char op = operators.Pop();
                        double b = operands.Pop();
                        double a = operands.Pop();

                        operands.Push(Calculate(a, b, op));
                    }

                    operators.Pop();
                }
            }

            while (operators.Count > 0)
            {
                char op = operators.Pop();
                double b = operands.Pop();
                double a = operands.Pop();

                operands.Push(Calculate(a, b, op));
            }

            if (operands.Count == 1)
            {
                result = operands.Pop();
                return true;
            }

            return false;
        }

        static int Precedence(char op)
        {
            switch (op)
            {
                case '+':
                case '-':
                    return 1;
                case '*':
                case '/':
                    return 2;
                default:
                    return -1;
            }
        }

        static double Calculate(double a, double b, char op)
        {
            switch (op)
            {
                case '+':
                    return a + b;
                case '-':
                    return a - b;
                case '*':
                    return a * b;
                case '/':
                    return a / b;
                default:
                    throw new ArgumentException("Invalid operator: " + op);
            }
        }

        static double result;
    }
}