namespace MainApp;

public static partial class SolutionsClass
{
    static partial void Task2()
    {
        using var input = new StreamReader(Console.OpenStandardInput());
        using var output = new StreamWriter(Console.OpenStandardOutput());

        int t = Convert.ToInt32(input.ReadLine());
        for (int i = 0; i < t; ++i)
        {
            int[] lstWithData = input.ReadLine()!.Split().Select(x => int.Parse(x)).ToArray();
            int n = lstWithData[0];
            int p = lstWithData[1];
            List<int> lstWNums = new List<int>();
            for (int j = 0; j < n; ++j)
            {
                lstWNums.Add(Convert.ToInt32(input.ReadLine()));
            }
            double ans = Rounding(lstWNums, p);
            output.WriteLine($"{ans:F2}");
        }
    }

    private static double Rounding(List<int> lstwNums, int p)
    {
        double ans = 0;
        for (int i = 0; i < lstwNums.Count; ++i)
        {
            double tmp = Math.Round(lstwNums[i] * ((p) / 100.0), 2);
            ans += tmp - Math.Truncate(tmp);
        }
        return Math.Abs(ans);
    }
}