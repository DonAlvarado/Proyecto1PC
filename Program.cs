using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("--------------------------\n");
        Console.Write("Proyecto 1, Smoothie Machine\n");
        Console.Write("--------------------------\n");

        DateTime startTime = DateTime.Now;

        string userName;
        string NITConfirmation;
        int NITNumber = 0;
        int sugarType = 0;
        int numSugar = 0;
        int milkType = 0;
        int numMilk = 0;
        bool enlarged = false;
        double sugarCost = 0;
        double milkCost = 0;

        Console.WriteLine("Introduce your name: ");
        userName = Console.ReadLine();
        Console.Clear();
        Console.WriteLine("Press Any Key to Continue...");
        Console.ReadLine();
        Console.Clear();
        Console.WriteLine("Do you want NIT?\n Y (Yes), N (No).");
        NITConfirmation = Console.ReadLine();
        Console.Clear();

        if (NITConfirmation == "Y")
        {
            Console.WriteLine("Enter your NIT: ");
            NITNumber = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Press Any Key to Continue...");
            Console.ReadLine();
            Console.Clear();
        }
        else
        {
            Console.WriteLine("No NIT");
            Console.Clear();
            Console.WriteLine("Press Any Key to Continue...");
            Console.ReadLine();
            Console.Clear();
        }

        do
        {
            Console.Write(startTime+"\n");
            Console.WriteLine("OPTIONS: \n(1) Chocolate\n(2) Vanilla\n(3) Strawberry\n(4) Mango\n(5) CONTINUE");
            int resp = int.Parse(Console.ReadLine());
            if (resp >= 1 && resp <= 4) 
            {
                Console.WriteLine("Smoothie Flavor: " + GetSmoothieFlavor(resp));
            }
            Console.WriteLine("Selected option: " + resp);
            Console.WriteLine("Press Any Key to Continue...");
            Console.ReadLine();
            Console.Clear();

            switch (resp)
            {
                case 1:
                    Process(ref sugarType, ref numSugar, ref milkType, ref numMilk, ref sugarCost, ref milkCost);
                    break;
                case 2:
                    Process(ref sugarType, ref numSugar, ref milkType, ref numMilk, ref sugarCost, ref milkCost);
                    break;
                case 3:
                    Process(ref sugarType, ref numSugar, ref milkType, ref numMilk, ref sugarCost, ref milkCost);
                    break;
                case 4:
                    Process(ref sugarType, ref numSugar, ref milkType, ref numMilk, ref sugarCost, ref milkCost);
                    break;
                case 5:
                    Console.WriteLine("Would you like to enlarge your smoothie?\nY (Yes), N (No).");
                    char enlargeChoice = char.Parse(Console.ReadLine());
                    Console.Clear();

                    if (enlargeChoice == 'Y' && !enlarged)
                    {
                        enlarged = true;
                        Console.WriteLine("Smoothie Enlarged!");
                        Console.WriteLine("Press Any Key to Continue...");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    else if (enlargeChoice == 'Y' && enlarged)
                    {
                        Console.WriteLine("You have already enlarged your smoothie once!");
                        Console.WriteLine("Press Any Key to Continue...");
                        Console.ReadLine();
                        Console.Clear();
                    }

                    Console.WriteLine("Confirm order:\n");
                    Console.WriteLine("Name: " + userName);
                    Console.WriteLine("NIT: " + (NITConfirmation == "Y" ? NITNumber.ToString() : "No NIT provided"));
                    Console.WriteLine("Smoothie Flavor: " + GetSmoothieFlavor(resp));
                    Console.WriteLine("Sugar Type: " + GetSugarType(sugarType));
                    Console.WriteLine("Sugar Quantity: " + numSugar);
                    Console.WriteLine("Sugar Cost: Q" + sugarCost);
                    Console.WriteLine("Milk Type: " + GetMilkType(milkType));
                    Console.WriteLine("Milk Quantity: " + numMilk);
                    Console.WriteLine("Milk Cost: Q" + milkCost);
                    Console.WriteLine("Enlarged: " + (enlarged ? "Yes" : "No"));
                    Console.WriteLine("Total Price: Q" + CalculateTotalPrice(sugarCost, milkCost, enlarged));
                    Console.WriteLine("\nOrder confirmed. Enjoy your smoothie!");
                    Console.WriteLine("\nPress Any Key to Exit...");
                    Console.ReadLine();
                    return;
            }

        } while (true);
    }

    static void Process(ref int sugarType, ref int numSugar, ref int milkType, ref int numMilk, ref double sugarCost, ref double milkCost)
    {
        Console.WriteLine("Would you like sugar?\nY (Yes), N (No).");
        char sugarChoice = char.Parse(Console.ReadLine());
        Console.Clear();

        if (sugarChoice == 'Y')
        {
            Console.WriteLine("Type of Sugar: \n(1) Supplement [Q 0.60]\n(2) White Sugar [Q 0.50]\n(3) Brown Sugar [Q 0.40]");
            sugarType = int.Parse(Console.ReadLine());
            Console.WriteLine("How many Sugars?");
            numSugar = int.Parse(Console.ReadLine());
            sugarCost = CalculateSugarCost(sugarType, numSugar);
            Console.Clear();
        }
        else
        {
            Console.WriteLine("No Sugar");
            Console.WriteLine("Press Any Key to Continue...");
            Console.ReadLine();
            Console.Clear();
        }

        Console.WriteLine("Would you like Milk?\n Y (Yes), N (No).");
        char milkChoice = char.Parse(Console.ReadLine());
        Console.Clear();

        if (milkChoice == 'Y')
        {
            Console.WriteLine("Type of Milk: \n(1) Lactose-free Milk \n(2) Whole Milk \n(3) Soy Milk");
            milkType = int.Parse(Console.ReadLine());
            Console.WriteLine("How many glasses of Milk?");
            numMilk = int.Parse(Console.ReadLine());
            milkCost = CalculateMilkCost(milkType, numMilk);
            Console.Clear();
        }
        else
        {
            Console.WriteLine("Water-Based Smoothie");
            Console.WriteLine("Press Any Key to Continue...");
            Console.ReadLine();
            Console.Clear();
        }
    }

    static double CalculateSugarCost(int sugarType, int numSugar)
    {
        double costPerSugar = 0;

        switch (sugarType)
        {
            case 1:
                costPerSugar = 0.60;
                break;
            case 2:
                costPerSugar = 0.50;
                break;
            case 3:
                costPerSugar = 0.40;
                break;
        }

        return costPerSugar * numSugar;
    }

    static double CalculateMilkCost(int milkType, int numMilk)
    {
        double costPerGlass = 0;

        switch (milkType)
        {
            case 1:
            case 2:
                costPerGlass = 1;
                break;
            case 3:
                costPerGlass = 3;
                break;
        }

        return costPerGlass * numMilk;
    }

    static string GetSugarType(int sugarType)
    {
        switch (sugarType)
        {
            case 1:
                return "Supplement";
            case 2:
                return "White Sugar";
            case 3:
                return "Brown Sugar";
            default:
                return "None";
        }
    }

    static string GetMilkType(int milkType)
    {
        switch (milkType)
        {
            case 1:
                return "Lactose-free Milk";
            case 2:
                return "Whole Milk";
            case 3:
                return "Soy Milk";
            default:
                return "None";
        }
    }

    static string GetSmoothieFlavor(int option)
    {
        switch (option)
        {
            case 1:
                return "Chocolate";
            case 2:
                return "Vanilla";
            case 3:
                return "Strawberry";
            case 4:
                return "Mango";
            default:
                return "Unknown Flavor";
        }
    }


    static double CalculateTotalPrice(double sugarCost, double milkCost, bool enlarged)
    {
        double basePrice = 20;
        double discountForWater = 2;
        double enlargementRate = 0.07;

        double totalPrice = basePrice + sugarCost + milkCost;

        if (enlarged)
        {
            totalPrice += totalPrice * enlargementRate;
        }

        return totalPrice;
    }
}