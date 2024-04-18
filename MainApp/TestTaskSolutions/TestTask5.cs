namespace MainApp;

public static partial class SolutionsClass
{
    static void TestTask5()
    {
        using var input = new StreamReader(Console.OpenStandardInput());
        using var output = new StreamWriter(Console.OpenStandardOutput());

        int t = Convert.ToInt32(input.ReadLine());
        for (int i = 0; i < t; ++i)
        {
            int n = Convert.ToInt32(input.ReadLine());
            int[] lstWithData = input.ReadLine()!.Split().Select(x => int.Parse(x)).ToArray();
            int[] lstAns = SimpleComperssion(lstWithData, n);

            output.WriteLine($"\n{lstAns.Length}");
            output.WriteLine(string.Join(" ", lstAns));
        }
    }

    private static int[] SimpleComperssion(int[] lstWithData, int lstLen)
    {
        List<int> lstAns = new List<int>();

        int prevNum = lstWithData[0];
        int startNum = lstWithData[0];
        int curDiff = 0;
        if (lstLen != 1)
        {
            for (int i = 1; i < lstLen; ++i)
            {
                int curNum = lstWithData[i];
                if (curNum == prevNum + 1)
                {
                    if (curDiff < 0)
                    {
                        lstAns.Add(startNum);
                        lstAns.Add(curDiff);
                        curDiff = 0;
                        startNum = curNum;
                    }
                    else { curDiff++; }
                    prevNum = curNum;

                    if (i == lstLen - 1)
                    {
                        lstAns.Add(startNum);
                        lstAns.Add(curDiff);
                        break;
                    }
                    continue;
                }
                else if (curNum == prevNum - 1)
                {
                    if (curDiff > 0)
                    {
                        lstAns.Add(startNum);
                        lstAns.Add(curDiff);
                        curDiff = 0;
                        startNum = curNum;
                    }
                    else { curDiff--; }
                    prevNum = curNum;

                    if (i == lstLen - 1)
                    {
                        lstAns.Add(startNum);
                        lstAns.Add(curDiff);
                        break;
                    }
                    continue;
                }
                else
                {
                    lstAns.Add(startNum);
                    lstAns.Add(curDiff);
                    curDiff = 0;
                    startNum = curNum;
                    prevNum = curNum;

                    if (i == lstLen - 1)
                    {
                        lstAns.Add(startNum);
                        lstAns.Add(curDiff);
                        break;
                    }
                    continue;
                }
            }

            return lstAns.ToArray();
        }
        else
        {
            lstAns.Add(startNum);
            lstAns.Add(curDiff);
            return lstAns.ToArray();
        }
    }

}