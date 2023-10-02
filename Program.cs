string option = GetOption();


static string GetOption()
{
    System.Console.WriteLine("\nHello, welcome to the new and improved ASPS Application\nEnter 'c' to access the Compass\nEnter 'fee' to access Park Fees\nEnter 'e' to Exit\n");
    string option = Console.ReadLine();
    CheckOption(option);
    return option;
}


static void CheckOption(string option)
{
    if (option == "c")
    {
        Compass();
    }
    else if (option == "fee")
    {
        FindFee();
    }
    else if (option == "e")
    {
        System.Console.WriteLine("\nThank you for using the new and improved ASPS Application. We hope you enjoyed your stay, and look forward to your return!");
    }
    else
    {
        System.Console.WriteLine("\nSorry, the option you chose does not exist. Press any key to continue.");
        Console.ReadKey();
        GetOption();
    }
}


static void Compass()
{
    int right = 0;
    int left = 0;
    int direction = 0;
    string facing = "";
    System.Console.WriteLine("\nHow many right turns have you made thus far?");
    right = int.Parse(System.Console.ReadLine());
    System.Console.WriteLine("\nHow many left turns have you made thus far?");
    left = int.Parse(System.Console.ReadLine());
    if (right >= left)
    {
        direction = right - left;
        if (direction % 4 == 0)
        {
            facing = "North";
        }
        else if (direction % 4 == 1)
        {
            facing = "East";
        }
        else if (direction % 4 == 2)
        {
            facing = "South";
        }
        else if (direction % 4 == 3)
        {
            facing = "West";
        }
    }
    else
    {
        direction = left - right;
        if (direction % 4 == 0)
        {
            facing = "North";
        }
        else if (direction % 4 == 1)
        {
            facing = "West";
        }
        else if (direction % 4 == 2)
        {
            facing = "South";
        }
        else if (direction % 4 == 3)
        {
            facing = "East";
        }
    }
    System.Console.WriteLine("\nAssuming you were facing North to begin with, you are currectly facing " + facing + ".\n\nPress any key to continue back to the menu.");
    Console.ReadKey();
    GetOption();
}


static void FindFee()
{
    string rv = "";
    int vehicleCost = 0;
    int adult = 0;
    int child = 0;
    int totalAttendees = 0;
    int stateTax = 0;
    System.Console.WriteLine("\nAre you driving an RV? (y/n)");
    rv = System.Console.ReadLine();
    if (rv == "y")
    {
        vehicleCost = 20;
    }
    else if (rv == "n")
    {
        vehicleCost = 10;
    }
    else
    {
        System.Console.WriteLine("\nSorry, the option you chose does not exist. Press any key to continue.");
        Console.ReadKey();
        FindFee();
    }

    System.Console.WriteLine("\nHow many adults are in your party?");
    adult = int.Parse(System.Console.ReadLine());
    System.Console.WriteLine("\nHow many children are in your party?");
    child = int.Parse(System.Console.ReadLine());
    totalAttendees = adult + child;
    if (totalAttendees >= 6)
    {
        stateTax = 5;
    }
    double totalTicketCost = (adult * 12) + ((child * 12) - ((child * 12) * 0.2));
    double totalFedCost = totalTicketCost * 1.09;
    double totalCost = totalFedCost + stateTax + vehicleCost;
    System.Console.WriteLine("\nPress any key to continue to pay");
    Console.ReadKey();
    TakePayment(totalCost);
}

static void TakePayment(double totalCost)
{
    System.Console.WriteLine("\n\nYou owe $" + totalCost + ". Press any key to continue to pay");
    Console.ReadKey();
    System.Console.WriteLine("\nHow much have you paid?");
    double totalPaid = int.Parse(System.Console.ReadLine());
    if (totalPaid > totalCost)
    {
        double change = totalPaid - totalCost;
        System.Console.WriteLine("\nYou have successfully paid! Your change is: $" + change);
    }
    else if (totalPaid == totalCost)
    {
        System.Console.WriteLine("\nYou have successfully paid!");
    }
    else
    {
        double stillOwe = totalCost - totalPaid;
        totalCost = stillOwe;   // update total cost to the amount they still owe.
        System.Console.WriteLine("\nError. You still owe $" + stillOwe + ". Press any key to continue the payment process.");
        Console.ReadKey();
        TakePayment(totalCost);
    }
    System.Console.WriteLine("\nPress any key to continue back to the menu.");
    Console.ReadKey();
    GetOption();
}