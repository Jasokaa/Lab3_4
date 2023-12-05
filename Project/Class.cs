namespace Project;

public class AccountEventArgs : EventArgs
{
    public string EventMessage { get; }

    public AccountEventArgs(string message)
    {
        EventMessage = message;
    }
}
public delegate void AccountEventHandler(object sender, AccountEventArgs e);
public class Account
{
    public event AccountEventHandler? AccountEvent;//create event from delegate AccountEventHandler
    private int sum;
    private int credit;//money that you can take over you SUM from bank

    public int Sum
    {
        get => sum;
        set => sum = value;
    }

    public int Credit
    {
        get => credit;
        set => credit = value;
    }
    public Account() { }
    public Account(int sumInput, int creditInput)
    {
        sum = sumInput;
        credit = creditInput;
    }

    public void AddMoney(int money)
    {
        sum += money;
        OnAccountEvent($"Event. Now you have ${sum} on your account");
    }
    
    public void TakeMoney(int money)
    {
        
        if (sum - money < 0)
        {
            if (sum + credit < money)
            {
                OnAccountEvent($"Overdraft Event! You don't have enough money to take ${money}, now sum = ${sum}, credit = ${credit}");
            }
            else
            {
                credit -= money - sum;
                sum = 0;
                OnAccountEvent($"Event. Money were taken from your credit, now sum = ${sum}, credit = ${credit}");
            }
        }
        else
        {
            sum -= money;
            OnAccountEvent($"Event. Now sum = ${sum}, credit = ${credit}");
        }
        
    }
    public void OnAccountEvent(string message)
    {
        AccountEvent?.Invoke(this, new AccountEventArgs(message));
        //Invoke is used to explicitly call methods that subscribe to an event
    }
}
