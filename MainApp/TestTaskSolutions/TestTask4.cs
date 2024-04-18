namespace MainApp;

public static partial class SolutionsClass
{
    static void TestTask4()
    {
        using StreamReader input = new StreamReader(Console.OpenStandardInput());
        using StreamWriter output = new StreamWriter(Console.OpenStandardOutput());

        List<string> ansOutput = new List<string>();

        int k = Convert.ToInt32(input.ReadLine());
        for (int i = 0; i < k; ++i)
        {
            int n = Convert.ToInt32(input.ReadLine());
            List<(string, int)> lstWithData = new List<(string, int)>();
            for (int j = 0; j < n; j++)
            {
                string[] line = input.ReadLine()!.Split();
                lstWithData.Add((line[0], Convert.ToInt32(line[1])));
            }

            ansOutput.Add(BFConditioner(lstWithData));
        }

        for (int i = 0; i < ansOutput.Count; ++i)
        {
            output.WriteLine(ansOutput[i] + "\n");
        }
    }

    private static string BFConditioner(List<(string, int)> lstWithData)
    {
        int minTemp = 15;
        int maxTemp = 30;

        List<string> ans = new List<string>();
        for (int i = 0; i < lstWithData.Count; ++i)
        {
            string curState = lstWithData[i].Item1;
            int curTemp = lstWithData[i].Item2;

            if (curState == ">=")
            {
                if (maxTemp >= curTemp)
                {
                    if (minTemp < curTemp) { minTemp = curTemp; }
                    ans.Add($"{minTemp}");
                    continue;
                }
                else { break; }
            }
            else if (curState == "<=")
            {
                if (minTemp <= curTemp)
                {
                    if (maxTemp > curTemp) { maxTemp = curTemp; }
                    ans.Add($"{minTemp}");
                    continue;
                }
                else { break; }
            }
        }

        int lenAns = ans.Count;
        for (int j = 0; j < (lstWithData.Count - lenAns); ++j)
        {
            ans.Add("-1");
        }

        return string.Join("\n", ans);
    }
}