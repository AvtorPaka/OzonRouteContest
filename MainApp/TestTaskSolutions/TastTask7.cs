namespace MainApp;

public static partial class SolutionsClass
{
    static void TestTask7()
    {
        using var input = new StreamReader(Console.OpenStandardInput());
        using var output = new StreamWriter(Console.OpenStandardOutput());

        int t = Convert.ToInt32(input.ReadLine());
        for (int i = 0; i < t; ++i)
        {
            int k = Convert.ToInt32(input.ReadLine());
            string lineWNums = input.ReadLine()!;
            output.WriteLine(GetUndonePages(GetDonePages(lineWNums), k));
        }
    }

    private static HashSet<int> GetDonePages(string lineWithPages)
    {
        string[] lstWithPages = lineWithPages.Split(",");
        HashSet<int> donePages = new HashSet<int>();
        for (int i = 0; i < lstWithPages.Length; ++i)
        {
            bool conv = int.TryParse(lstWithPages[i], out int num);
            if (conv) { donePages.Add(num); }
            else
            {
                string[] startEndNum = lstWithPages[i].Split("-");
                int start = int.Parse(startEndNum[0]);
                int end = int.Parse(startEndNum[^1]);
                for (int j = start; j <= end; ++j)
                {
                    donePages.Add(j);
                }
            }
        }

        return donePages;
    }

    private static string GetUndonePages(HashSet<int> setDonePages, int k)
    {
        List<int> lstUnformatedUndone = new List<int>();
        for (int i = 1; i <= k; ++i)
        {
            if (!setDonePages.Contains(i))
            {
                lstUnformatedUndone.Add(i);
            }
        }

        List<string> lstAns = new List<string>();
        int startNum = lstUnformatedUndone[0];
        bool inAsend = false;
        for (int i = 1; i < lstUnformatedUndone.Count; ++i)
        {
            int curNum = lstUnformatedUndone[i];
            int prevNum = lstUnformatedUndone[i - 1];

            if (curNum == prevNum + 1)
            {
                if (!inAsend)
                {
                    inAsend = true;
                    startNum = prevNum;
                }
                if (i == lstUnformatedUndone.Count - 1) { lstAns.Add($"{startNum}-{curNum}"); }
                continue;
            }
            else if (curNum != prevNum + 1)
            {
                if (inAsend)
                {
                    inAsend = false;
                    lstAns.Add($"{startNum}-{prevNum}");
                }
                else
                {
                    lstAns.Add($"{prevNum}");
                }
                if (i == lstUnformatedUndone.Count - 1) { lstAns.Add($"{curNum}"); }
                continue;
            }
        }

        if (lstUnformatedUndone.Count == 1)
        {
            lstAns.Add($"{lstUnformatedUndone[0]}");
        }

        return string.Join(",", lstAns);
    }
}