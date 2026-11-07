class BankAccount
{
    public string Owner { get; set; } = "";
    public decimal Balance { get; set; }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Deposit must be greater than 0.");
            return;
        }
        else
        {
            Balance += amount;
        }
    }
    public bool Withdraw(decimal amount)
    {
        if (amount <= 0 || amount > Balance)
        {
            Console.WriteLine("Amount Balance is insufficient.");
            return false;
        }
        else
        {
            Balance -= amount;
            return true;
        }
    }
    public void PrintBalance()
    {
        Console.WriteLine($"{Owner} current balance is {Balance:N2}");
    }
}
class Program
{
    static void Main(string[] args)
    {
        BankAccount account = new BankAccount();
        Console.Write("PLease Enter a name: ");
        string? name = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Please enter a name.");
            return;
        }
        account.Owner = name.Trim();
        Console.WriteLine($"Hello Sir/Ma'am {account.Owner}");
        while (true)
        {
            Console.WriteLine("\n Deposit[1] \n Withdraw[2] \n See Balance[3] \n Quit[4]");
            Console.Write("What do you want to do?: ");
            string? choice = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(choice))
            {
                Console.WriteLine("Please dont leave the choice blank");
                continue;
            }
            if (choice == "1") // DEPOSIT
            {
                Console.WriteLine("You choose to deposit!");
                Console.Write("Please Enter the amount you want to deposit: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal amount))
                {
                    Console.WriteLine("Please enter a valid amount");
                    continue;
                }
                if (account.Withdraw(amount))
                {
                    Console.WriteLine($"Amount Deposited is: {amount:N2}");
                    account.Deposit(amount);
                    Console.WriteLine($"Current Balance after Deposit is: {account.Balance:N2}");
                }
            }
            else if (choice == "2") // WITHDRAW
            {
                Console.Write("Please Enter The amount you want to Withdraw: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal amount))
                {
                    Console.WriteLine("Please enter a valid amount");
                    continue;
                }
                Console.WriteLine($"Amount Withdrawn is: {amount}");
                account.Withdraw(amount);
                Console.WriteLine($"Current Balance after witdraw is: {account.Balance:N2}");
            }
            else if (choice == "3") // PRINTBALANCE
            {
                account.PrintBalance();
            }
            else if (choice == "4")
            {
                Console.WriteLine($"Thank you for using the BankAccount Sir/Ma'am {account.Owner}");
                break;
            }
            else
            {
                Console.WriteLine("Please Choose from [1-4]");
            }
        }

    }
}