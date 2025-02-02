string[] validOperators = ["+", "-", "*", "/"];
bool quit = false;
while (true && !quit)
{
    Console.WriteLine("Please pick an operator you want to play:");
    Console.WriteLine("+ :: Addition \n- :: Subtraction \n* :: Multiplication \n/ :: Division \nq :: quit");

    var userOperator = Console.ReadLine();
    var isNotValidOperator = !Array.Exists(validOperators, op => op == userOperator);

    
    if (!string.IsNullOrWhiteSpace(userOperator))
    {
        if (userOperator.Equals("q", StringComparison.OrdinalIgnoreCase))
        {
            quit = true;
            Console.Clear();
            Console.WriteLine("Thank you for playing :)");
        }
        else if (isNotValidOperator)
        {
            Console.Clear();
            Console.WriteLine("Please enter a valid operator");
        }
        else
        {
            var selectedOperator = userOperator switch
            {
                "+" => Operators.Addition,
                "-" => Operators.Subtraction,
                "*" => Operators.Multiplication,
                "/" => Operators.Division,
                _ => throw new InvalidOperationException("Invalid operator")
            };
            DoOperation(selectedOperator);
        }
    }
    else
    {
        Console.Clear();
        Console.WriteLine("Input cannot be empty!");

    }
    
}

void DoOperation(Operators op)
{
    Console.WriteLine(op);
}

internal enum Operators
{
    Addition,
    Subtraction,
    Multiplication,
    Division
}