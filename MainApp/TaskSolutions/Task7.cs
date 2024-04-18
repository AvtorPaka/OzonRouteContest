namespace MainApp;

public static partial class SolutionsClass
{
    static partial void Task7()
    {
        using var input = new StreamReader(Console.OpenStandardInput());
        using var output = new StreamWriter(Console.OpenStandardOutput());

        int n = Convert.ToInt32(input.ReadLine());
        List<string> lstUsedLogs = new List<string>();
        for (int i = 0; i < n; ++i)
        {
            lstUsedLogs.Add(input.ReadLine()!);
        }

        int m = Convert.ToInt32(input.ReadLine());
        for (int i = 0; i < m; ++i)
        {
            string curNewLogin = input.ReadLine()!;

            if (CheckLogin(lstUsedLogs, curNewLogin)) { output.WriteLine(1); }
            else { output.WriteLine(0); }
        }
    }

    private static bool CheckLogin(List<string> lstUsedLogs, string newLog)
    {
        bool isMatched = false;
        for (int i = 0; i < lstUsedLogs.Count; ++i)
        {
            string curLog = lstUsedLogs[i];
            if (curLog.Length != newLog.Length) { continue; }
            else
            {
                isMatched = CorectSwap(newLog, curLog);
                if (isMatched) { break; }
            }
        }

        return isMatched;
    }

    private static bool CorectSwap(string newLog, string curLog)
    {
        bool correctSwap = true;
        bool hasChanged = false;
        for (int j = 0; j < newLog.Length; ++j)
        {

            if (newLog[j] != curLog[j])
            {
                if (hasChanged)
                {
                    correctSwap = false;
                    break;
                }
                else
                {
                    if (j == newLog.Length - 1)
                    {
                        correctSwap = false;
                        break;
                    }
                    else
                    {
                        if (newLog[j] == curLog[j + 1] && newLog[j + 1] == curLog[j])
                        {
                            hasChanged = true;
                            j += 1;
                            continue;
                        }
                        else
                        {
                            correctSwap = false;
                            break;
                        }
                    }

                }
            }
        }
        return correctSwap;
    }
}