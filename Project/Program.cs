using Project;
internal static class Program
{
    public static void Main(string[] args)
    {
        //Obtaining sums of row elements of a two-dimensional array into a one-dimensional array
        RowSumDelegate rowSum;
        int[,] array2 = {
            {1, 2, 3},//6
            {4, 5, 6},//15
            {7, 8, 9} //24
        };

        Console.WriteLine("Rows sum: (normal method)");
        rowSum = RowSumMethod;
        int[] normalMethod = rowSum(array2);
        Console.WriteLine(normalMethod[0] + " " + normalMethod[1] + " " + normalMethod[2]);
        
        Console.WriteLine("Rows sum: (anonymous)");
        rowSum = delegate (int[,] array)
        {
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);
            int[] rowSumArray = new int[rows];
            for (int i = 0; i < rows; i++)
            {
                int sum = 0;
                for (int j = 0; j < cols; j++)
                {
                    sum += array2[i, j];
                }
                rowSumArray[i] = sum;
            }
            return rowSumArray;
        };
        int[] anonymousMethod = rowSum(array2);
        Console.WriteLine(anonymousMethod[0] + " " + anonymousMethod[1] + " " + anonymousMethod[2]);
        
        Console.WriteLine("Rows sum: (lambda)");
        rowSum = (input) =>
        {
            int rows = input.GetLength(0);
            int cols = input.GetLength(1);
            int[] rowSumArray = new int[rows];
            for (int i = 0; i < rows; i++)
            {
                int sum = 0;
                for (int j = 0; j < cols; j++)
                {
                    sum += array2[i, j];
                }
                rowSumArray[i] = sum;
            }
            return rowSumArray;
        };
        int[] lambdaMethod = rowSum(array2);
        Console.WriteLine(lambdaMethod[0] + " " + lambdaMethod[1] + " " + lambdaMethod[2]);
        
        //bank account tasks
        Account account = new Account(100, 50);
        account.AccountEvent += AccountEventHandler;//subscribe event
        //event calls
        account.AddMoney(10);
        account.TakeMoney(100);
        account.TakeMoney(100);//can't get
    }
    private delegate int[] RowSumDelegate(int[,] array2);
    private static int[] RowSumMethod(int[,] array2)
    {
        int rows = array2.GetLength(0);
        int cols = array2.GetLength(1);
        int[] rowSumArray = new int[rows];
        for (int i = 0; i < rows; i++)
        {
            int sum = 0;
            for (int j = 0; j < cols; j++)
            {
                sum += array2[i, j];
            }
            rowSumArray[i] = sum;
        }
        return rowSumArray;
    }
    static void AccountEventHandler(object sender, AccountEventArgs e)
    {
        Console.WriteLine(e.EventMessage);
    }
}
