using System;


class Program
{
    const string addition = "+";
    const string subtraction = "-";
    const string multiplication = "*";
    const string division = "/";

    public static void Main(string[] args)
    {
        string[] inputString = Console.ReadLine().Split(' ');

        for (int i=0; i < inputString.Length; i++)
        {
            if (CheckOperator(inputString[i]))
            {
                int[] terms = new int[2];
                int j = i-1;
                int termsCounter = 1;
                while (termsCounter >= 0)
                {
                    if (inputString[j] != null)
                    {
                        terms[termsCounter] = int.Parse(inputString[j]);
                        inputString[j] = null;
                        termsCounter--;
                    }
                    j--;
                }
                inputString[i] = DoOperation(terms, inputString[i]).ToString();
            }
        }

        Console.WriteLine(inputString[inputString.Length-1]);
    }

    public static int DoOperation(int[] terms, string @operator)
    {
        switch (@operator)
        {
            case addition:
                return terms[0] + terms[1];
            case subtraction:
                return terms[0] - terms[1];
            case multiplication:
                return terms[0] * terms[1];
            case division:
                return terms[0] / terms[1];
            default:
                throw new Exception("Operator is not defined");
        }
    }

    public static bool CheckOperator(string symbol)
    {
        string[] operators = { addition, subtraction, multiplication, division };
        foreach (var oper in operators)
        {
            if (oper == symbol)
                return true;
        }
        return false;
    }
}

