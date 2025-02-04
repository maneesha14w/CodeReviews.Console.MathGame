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
    else if (IsNotValidOperator(userOperator!))
    {
        Console.Clear();
        Console.WriteLine("Please enter a valid operator");
    }
    else if (IsNotValidOperator(userOperator!))
    {
        DisplayMessage("Please enter a valid operator");
    }
    else
    {
        DoOperation(GetOperator(userOperator!));
    }
}

void ShowMenu()
{
    Console.WriteLine("Please pick an operator you want to play:");
    Console.WriteLine("+ :: Addition \n- :: Subtraction \n* :: Multiplication \n/ :: Division \nq :: quit");
}

void DisplayMessage(String msg) {
    Console.Clear();
    Console.WriteLine(msg);
}

bool IsNotValidOperator(String userOperator) => !Array.Exists(validOperators, op => op == userOperator);
bool IsQuit(String? userOperator) => userOperator!.Equals("q", StringComparison.OrdinalIgnoreCase);

static Operators GetOperator(string userOperator) => userOperator switch
{
    "+" => Operators.Addition,
    "-" => Operators.Subtraction,
    "*" => Operators.Multiplication,
    "/" => Operators.Division,
    _ => throw new Exception("Invalid operator")
};

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