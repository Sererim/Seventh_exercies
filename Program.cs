int Main()
{
    string key = "", load = "";
    int m = 0, n = 0;
    
    
    Console.WriteLine("Program is running.");

    while(true)
    {
        Console.WriteLine("Enter 1 to create an array of m*n size and fill it with random numbers.\n" +
        "Enter 2 to create an array of m*n size and look at specific element i,j.\n" +
        "Enter 3 to create an array of m*n size and find a mean of all columns.\n" +
        "Enter 0 to terminate a program.");

        key = Console.ReadLine();

        Console.WriteLine("Enter m and n to generate an array.\n" +
        "Enter m");

        load = Console.ReadLine();
        m = System.Int32.Parse(load);

        Console.WriteLine("Enter n");
        load = Console.ReadLine();
        n = System.Int32.Parse(load);

        Homework arr = new Homework(m,n);

        switch(key)
        {
            case "1":
                arr.GenerateHalf();
                arr.Show();
                break;
            case "2":
                arr.GenerateWhole();
                Console.WriteLine("Enter i - column, j - row.\n" +
                "Enter -1 to end input.");
                while(true)
                {
                    key = Console.ReadLine();
                    m = System.Int32.Parse(key);
                    key = Console.ReadLine(key);
                    n = System.Int32.Parse(key);
                    if(m == -1 || n == -1)
                        break;
                    else
                        arr.ShowSpecific(m,n);
                }
                break;
            case "3":
                arr.GenerateWhole();
                arr.Show();
                arr.ShowMean();
                break;
            default:
                Main();
                break;
            case "0":
                return 0;
        }
    }
}

Main();

class Homework
{
    public int m = 0;
    public int n = 0;
    public double[,] matrix;
    public Homework(int x, int y)
    {
        m = x;
        n = y;
        double[,] array = new double[m,n];
        matrix = array;
    }

    public void GenerateWhole()
    {
        Random rand = new Random();
        for(int i = 0;i < m; i++)
            for(int j = 0; j < n; j++)
                matrix[i,j] = rand.Next(-100,100);
    }

    public void GenerateHalf()
    {
        Random rand = new Random();
        for(int i = 0;i < m; i++)
            for(int j = 0; j < n; j++)
                matrix[i,j] = rand.NextDouble() + rand.Next(-100,100); 
    }

    public void Show()
    {
        for(int i = 0; i < m; i++)
        {
            Console.Write($"Line {i + 1}: ");
            for(int j = 0; j < n; j++)
            {
                Console.Write($" {matrix[i,j]} ");
            }
            Console.WriteLine();
        }
    }

    public void ShowSpecific(int i, int j)
    {
        Console.WriteLine($" |{matrix[i,j]}| ");
    }

    public void ShowMean()
    {
        double num = 0;
        for(int j = 0; j < n; j++)
        {
            for(int i = 0; i < m; i++)
                num += matrix[i,j];
            num /= m;      
            Console.WriteLine($"Column {j}: average - {num}");
            num = 0;
        }
    }
}