namespace MainApp;

public static partial class SolutionsClass
{
    static void TestTask2()
    {
        using StreamReader input = new StreamReader(Console.OpenStandardInput());
        using StreamWriter output = new StreamWriter(Console.OpenStandardOutput());

        int[] lstWithData = input.ReadLine()!.Split().Select(x => Convert.ToInt32(x)).ToArray();
        output.WriteLine(DataCheck(lstWithData) ? "Yes" : "No");
    }

    private static bool DataCheck(int[] lstWithData)
    {
        HashSet<int> largeMonths = new HashSet<int>(new int[] { 1, 3, 5, 7, 8, 10, 12 });
        HashSet<int> smallMonths = new HashSet<int>(new int[] { 4, 6, 9, 11 });
        int day = lstWithData[0];
        int month = lstWithData[1];
        int yearNum = lstWithData[^1];
        bool isLeap = (yearNum % 4 == 0 && yearNum % 100 > 0) || (yearNum % 400 == 0);
        if (month == 2 && ((isLeap && day <= 29) || (isLeap == false && day <= 28))) { return true; }
        else if (largeMonths.Contains(month) && day <= 31) { return true; }
        else if (smallMonths.Contains(month) && day <= 30) { return true; }
        else { return false; }
    }
}