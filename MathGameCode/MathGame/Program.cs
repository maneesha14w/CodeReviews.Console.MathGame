string[] validOperators = ["+", "-", "*", "/"];
var quit = false;

while (!quit)
{
    ShowMenu();
    var userOperator = Console.ReadLine();


    if (string.IsNullOrWhiteSpace(userOperator))
    {
        DisplayMessage("Operator cannot be empty");
        continue;
    }

    if (IsQuit(userOperator))
    {
        DisplayMessage("Thank you for playing :)");
        quit = true;
    }
    else if (IsNotValidOperator(userOperator))
    {
        DisplayMessage("Please enter a valid operator");
    }
    else if (IsNotValidOperator(userOperator))
    {
        DisplayMessage("Please enter a valid operator");
    }
    else
    {
        DoOperation(GetOperator(userOperator), userOperator);
    }
}

void ShowMenu()
{
    Console.WriteLine("Please pick an operator you want to play:");
    Console.WriteLine("+ :: Addition \n- :: Subtraction \n* :: Multiplication \n/ :: Division \nq :: quit");
}

void DisplayMessage(string msg)
{
    Console.Clear();
    Console.WriteLine(msg);
}

bool IsNotValidOperator(string userOperator)
{
    return !Array.Exists(validOperators, op => op == userOperator);
}

bool IsQuit(string? userOperator)
{
    return userOperator!.Equals("q", StringComparison.OrdinalIgnoreCase);
}

static Operators GetOperator(string userOperator)
{
    return userOperator switch
    {
        "+" => Operators.Addition,
        "-" => Operators.Subtraction,
        "*" => Operators.Multiplication,
        "/" => Operators.Division,
        _ => throw new Exception("Invalid operator")
    };
}

(int, int) IsValidDivision((int, int) tuple, Random random)
{
    if (tuple.Item1 % tuple.Item2 == 0) return tuple;
    while (tuple.Item1 % tuple.Item2 != 0)
    {
        (tuple.Item1, tuple.Item2) = (random.Next(1, 100), random.Next(1, 100));
    }
    Console.WriteLine(tuple.Item1 + " "+ tuple.Item2);
    return tuple;
}

void DoOperation(Operators operationType, string operationSignString)
{
    var rnd = new Random();
    var (num1, num2) = (rnd.Next(1, 100), rnd.Next(1, 100));
    Console.WriteLine(num1 +  " " + num2);
    if (operationType == Operators.Division)
    {
        (num1, num2) = IsValidDivision((num1, num2), rnd);
    };
    Console.WriteLine($"{num1} {operationSignString} {num2}");
    Console.WriteLine("What is the result of the expression above?");
    var result = GetResult(operationType, (num1, num2));
    while (true)
    {
        var userAnswer = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(userAnswer) && int.TryParse(userAnswer,out var ans))
        {
            if (result == ans)
            {
                Console.WriteLine("Success");
                break;
            }
            Console.WriteLine("Incorrect");
        }
    }
    Task.Delay(4000);
}

int GetResult(Operators operationType, (int, int) tuple)
{
    return operationType switch
    {
        Operators.Addition => tuple.Item1 + tuple.Item2,
        Operators.Subtraction => tuple.Item1 - tuple.Item2,
        Operators.Multiplication => tuple.Item1 * tuple.Item2,
        Operators.Division => tuple.Item1 / tuple.Item2,
        _ => 0
    };
}

internal enum Operators
{
    Addition,
    Subtraction,
    Multiplication,
    Division
}