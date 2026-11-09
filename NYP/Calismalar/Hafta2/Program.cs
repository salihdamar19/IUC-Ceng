using System;
using System.Diagnostics.CodeAnalysis;

class BankAccount
{
    private string accountNumber;
    private string owner;
    private decimal balance;


    public BankAccount(string accountNumber, string owner, decimal initialBalance){
        if(initialBalance < 0) initialBalance = 0;
        this.accountNumber = accountNumber;
        this.owner = owner;
        this.balance = initialBalance;
    }

    public string AccountNumber
    {
        get
        {
            return accountNumber;        
        }
    }

    public string Owner
    {
        get
        {
            return owner;    
        }

        set
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                owner = value;
            }
        }
    }

    public decimal Balance
    {
        get
        {
            return balance;
        }
    }

    public void Deposit(decimal amount)
    {
        if(amount > 0) balance += amount;
        else Console.WriteLine("Amount must be greater than zero.");
    }

    public void Withdraw(decimal amount)
    {
        if(amount <= 0)
        {
            Console.WriteLine("Amount must be greater than zero.");
        }else if(amount > balance)
        {
            Console.WriteLine("Insufficient balance.");
        }
        else
        {
            balance -= amount;
        }
    }

    public void ShowInfo()
    {
        Console.Write($"Account Number: {accountNumber}\n");
        Console.Write($"Account Owner: {owner}\n");
        Console.Write($"Balance: {balance} TL\n");
    }
}   

class Program
{
    static void Main()
    {
        BankAccount account1 = new BankAccount("TR1001", "Ahmet Yılmaz", 5000);
        account1.ShowInfo();
        account1.Deposit(1500);
        account1.Withdraw(1000);
        Console.WriteLine();
        account1.ShowInfo();

        account1.Withdraw(9000);
        account1.Owner = "   ";
        account1.Deposit(-5);
        BankAccount b = new BankAccount("X", "Y", -100);
        b.ShowInfo();
    }
}

/*
İstenenler:

private alanlar: accountNumber (string), owner (string), balance (decimal)
Constructor (accountNumber, owner, initialBalance): başlangıç bakiyesi negatifse 0 yap
AccountNumber → sadece get (sonradan değişemez)
Balance → sadece get
Owner → get ve set, set boş ya da sadece boşluk gelirse değiştirmesin
Deposit(decimal amount) → sadece amount > 0 ise ekler, yoksa Amount must be greater than zero.
Withdraw(decimal amount) → amount <= 0 ise aynı mesaj, amount > balance ise Insufficient balance., değilse çıkarır
ShowInfo() → 3 satır: Account Number: …, Owner: …, Balance: … TL
Main: account1 = new BankAccount("TR1001", "Ahmet Yılmaz", 5000). Sırayla: ShowInfo, Deposit(1500), Withdraw(1000), boş satır, ShowInfo
*/