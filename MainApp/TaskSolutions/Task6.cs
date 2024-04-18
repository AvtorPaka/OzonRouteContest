namespace MainApp;

public static partial class SolutionsClass
{
    static partial void Task6()
    {
        using var input = new StreamReader(Console.OpenStandardInput());
        using var output = new StreamWriter(Console.OpenStandardOutput());

        int t = Convert.ToInt32(input.ReadLine());
        for (int i = 0; i < t; ++i)
        {
            int[] dimensions = input.ReadLine()!.Split(' ').Select(x => int.Parse(x)).ToArray();
            int n = dimensions[0];
            int m = dimensions[1];

            List<int[]> dataGrid = new List<int[]>();

            int[] lstCntNums = new int[5];
            int overallMin = 10;
            List<(int, int)> minsPosition = new List<(int, int)>();

            for (int j = 0; j < n; ++j)
            {
                int[] tmpLine = new int[m];

                string lineWNums = input.ReadLine()!;
                for (int k = 0; k < m; ++k)
                {
                    string curCh = lineWNums[k].ToString();
                    int curNum = Convert.ToInt32(curCh);

                    tmpLine[k] = curNum;
                    lstCntNums[curNum - 1]++;

                    if (curNum < overallMin)
                    {
                        overallMin = curNum;
                        minsPosition.Clear();
                        minsPosition.Add((j, k));
                    }
                    else if (curNum == overallMin) { minsPosition.Add((j, k)); }
                }

                dataGrid.Add(tmpLine);
            }

            (int, int) ans = (0, 0);

            (int, int) curPosition = minsPosition[0];
            int rowNum = curPosition.Item1;
            int columNum = curPosition.Item2;

            //Случай для строки
            int[] tmpLstCntNumsRows = new int[5];
            Array.Copy(lstCntNums, tmpLstCntNumsRows, 5);

            int[] curRow = dataGrid[rowNum];
            for (int k = 0; k < curRow.Length; ++k)
            {
                tmpLstCntNumsRows[curRow[k] - 1]--;
            }

            int allMin = overallMin;

            for (int k = 0; k < m; ++k)
            {
                int[] tmpLst1 = new int[5];
                Array.Copy(tmpLstCntNumsRows, tmpLst1, 5);

                int tmpMin = 0;

                for (int h = 0; h < n; ++h)
                {
                    if (h == rowNum) { continue; }
                    tmpLst1[dataGrid[h][k] - 1]--;
                }

                for (int h = 0; h < 5; ++h)
                {
                    if (tmpLst1[h] > 0)
                    {
                        tmpMin = h + 1;
                        break;
                    }
                }

                if (tmpMin > allMin)
                {
                    allMin = tmpMin;
                    ans = (rowNum, k);
                }

            }

            //Случай для столбца
            int[] tmpLstCntNumsColumns = new int[5];
            Array.Copy(lstCntNums, tmpLstCntNumsColumns, 5);

            int[] curColumn = new int[n];
            for (int k = 0; k < dataGrid.Count; ++k)
            {
                curColumn[k] = dataGrid[k][columNum];
            }

            for (int k = 0; k < n; ++k)
            {
                tmpLstCntNumsColumns[curColumn[k] - 1]--;
            }

            for (int k = 0; k < dataGrid.Count; ++k)
            {
                int[] tmpLst2 = new int[5];
                Array.Copy(tmpLstCntNumsColumns, tmpLst2, 5);

                int tmpMin2 = 0;

                for (int h = 0; h < m; ++h)
                {
                    if (h == columNum) { continue; }
                    tmpLst2[dataGrid[k][h] - 1]--;
                }

                for (int h = 0; h < 5; ++h)
                {
                    if (tmpLst2[h] > 0)
                    {
                        tmpMin2 = h + 1;
                        break;
                    }
                }

                if (tmpMin2 > allMin)
                {
                    allMin = tmpMin2;
                    ans = (k, columNum);
                }
            }

            output.WriteLine($"{ans.Item1 + 1} {ans.Item2 + 1}");
        }
    }
}