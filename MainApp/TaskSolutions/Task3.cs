namespace MainApp;

public static partial class SolutionsClass
{
    static partial void Task3()
    {
        using var input = new StreamReader(Console.OpenStandardInput());
        using var output = new StreamWriter(Console.OpenStandardOutput());

        int t = Convert.ToInt32(input.ReadLine());
        for (int i = 0; i < t; ++i)
        {

            string lineWComands = input.ReadLine()!;
            if (SHL(lineWComands)) { output.WriteLine("YES"); }
            else { output.WriteLine("NO"); }

        }
    }

    private static bool SHL(string lineWComands)
    {
        char lastComand = lineWComands[0];
        if (lastComand != 'M' || lineWComands[^1] != 'D') { return false; }

        for (int i = 1; i < lineWComands.Length; ++i)
        {
            char curComand = lineWComands[i];
            if (lastComand == 'M')
            {
                if (curComand == 'M') { return false; }
            }
            else if (lastComand == 'R')
            {
                if (curComand != 'C') { return false; }
            }
            else if (lastComand == 'C')
            {
                if (curComand != 'M') { return false; }
            }
            else if (lastComand == 'D')
            {
                if (curComand != 'M') { return false; }
            }
            lastComand = curComand;
        }

        return true;
    }
}