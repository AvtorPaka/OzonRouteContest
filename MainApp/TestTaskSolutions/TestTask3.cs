using System.Text;

namespace MainApp;

public static partial class SolutionsClass
{
    static void TestTask3()
    {
        using StreamReader input = new StreamReader(Console.OpenStandardInput());
        using StreamWriter output = new StreamWriter(Console.OpenStandardOutput());
        string carNum = input.ReadLine()!;

        string[] someLst = CarNumber(carNum);
        for (int i = 0; i < someLst.Length; ++i)
        {
            output.WriteLine(someLst[i]);
        }
    }

    private static string[] CarNumber(string lineToCheck)
    {
        HashSet<char> setNums = new HashSet<char>(new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' });
        const string alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";


        List<string> lstNumbersTmp = new List<string>();
        int cnt = 0;
        int typeOfNum = 0;
        StringBuilder curNumber = new StringBuilder();
        foreach (char ch in lineToCheck)
        {
            if (curNumber.Length > 5)
            {
                return Array.Empty<string>();
            }
            else
            {
                if (curNumber.Length == 0)
                {
                    if (alphabet.Contains(ch))
                    {
                        curNumber.Append(ch);
                        continue;
                    }
                    else { return Array.Empty<string>(); }
                }

                else if (curNumber.Length == 1)
                {
                    if (setNums.Contains(ch))
                    {
                        curNumber.Append(ch);
                        continue;
                    }
                    else { return Array.Empty<string>(); }
                }

                else if (curNumber.Length == 2)
                {
                    if (setNums.Contains(ch))
                    {
                        curNumber.Append(ch);
                        typeOfNum = 1;
                        continue;
                    }
                    else if (alphabet.Contains(ch))
                    {
                        curNumber.Append(ch);
                        typeOfNum = 2;
                        continue;
                    }
                    else { return Array.Empty<string>(); }
                }
                else if (curNumber.Length == 3)
                {
                    if (alphabet.Contains(ch))
                    {
                        curNumber.Append(ch);
                        if (typeOfNum == 2)
                        {
                            cnt += 4;
                            lstNumbersTmp.Add(curNumber.ToString());
                            typeOfNum = 0;
                            curNumber.Clear();
                        }
                        continue;
                    }
                    else { return Array.Empty<string>(); }
                }
                else if (curNumber.Length == 4)
                {

                    if (alphabet.Contains(ch))
                    {
                        curNumber.Append(ch);
                        cnt += 5;
                        lstNumbersTmp.Add(curNumber.ToString());
                        typeOfNum = 0;
                        curNumber.Clear();
                        continue;
                    }
                    else { return Array.Empty<string>(); }
                }
            }
        }

        if (cnt == lineToCheck.Length)
        {
            return lstNumbersTmp.ToArray();
        }
        else { return Array.Empty<string>(); }
    }
}