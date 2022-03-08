// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Customer.Start();

class Customer
{
    static IAccount account1, account2;

    public static void Start()
    {
        account1 = new SavingsAccount("Raman Gujral", "HFDC113400111", 'S');
        account2 = new CurrentAccount("Raman Gujral", "HFDC113400111", 'S');

        Console.WriteLine("------------------------------");
        Console.WriteLine("Savings Account Demo");
        Console.WriteLine("------------------------------");
        account1.Deposit(10000);
        account1.DisplayBalance();
        account1.CalculateInterest();
        account1.Withdraw(500);
        account1.DisplayBalance();

        Console.WriteLine("------------------------------");
        Console.WriteLine("Current Account Demo");
        Console.WriteLine("------------------------------");
        account2.Deposit(10000);
        account2.DisplayBalance();
        account2.Withdraw(9100);
        account2.DisplayBalance();
        account2.CalculateInterest();
        account2.DisplayBalance();
        Console.WriteLine("------------------------------");
    }
}

public interface IAccount
{
    void CalculateInterest();
    void Deposit(int amount);
    void DisplayBalance();
    void Withdraw(int amount);
}

public abstract class Account : IAccount
{
    protected string _customerName;
    protected string _accountNumber;
    protected char _typeOfAccount;
    protected double _balance;
    protected DateTime _accountCreationDate;

    public abstract void CalculateInterest();

    public void Deposit(int amount)
    {
        _balance += amount;
    }

    public void DisplayBalance()
    {
        Console.WriteLine($"Balance of {_customerName} is {_balance}");
    }

    public virtual void Withdraw(int amount)
    {
        _balance -= amount;
    }
}

public class SavingsAccount : Account
{
    double rateOfInterest = 4.5;
    public SavingsAccount(string customerName, string accountNumber, char typeOfAccount)
    {
        _customerName = customerName;
        _accountNumber = accountNumber;
        _typeOfAccount = typeOfAccount;
        _balance = 0;
        _accountCreationDate = DateTime.Now.AddYears(-3);
    }

    public override void CalculateInterest()
    {
        var interest = _balance * 3 * rateOfInterest / 100;
        _balance += interest;
    }
}

public class CurrentAccount : Account
{
    int minimumBalance = 1000;
    int penaltyAmount = 200;

    public CurrentAccount(string customerName, string accountNumber, char typeOfAccount)
    {
        _customerName = customerName;
        _accountNumber = accountNumber;
        _typeOfAccount = typeOfAccount;
        _balance = 0;
        _accountCreationDate = DateTime.Now.AddYears(-3);
    }

    public override void CalculateInterest()
    {        
    }

    public override void Withdraw(int amount)
    {
        base.Withdraw(amount);

        if (_balance < minimumBalance)
        {
            _balance -= penaltyAmount;
            Console.WriteLine($"Your balance is below minimum balance. So penalty of Rs.{penaltyAmount} is applied!!");
        }
    }
}