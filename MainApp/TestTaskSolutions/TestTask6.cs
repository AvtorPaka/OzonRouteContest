using System.Text;

namespace MainApp;

public static partial class SolutionsClass
{
    static void TestTask6()
    {
        using var input = new StreamReader(Console.OpenStandardInput());
        using var output = new StreamWriter(Console.OpenStandardOutput());

        int t = Convert.ToInt32(input.ReadLine());
        for (int i = 0; i < t; i++)
        {
            string comandLines = input.ReadLine()!;
            output.WriteLine(Terminal(comandLines));
        }
    }

    private static string Terminal(string comandLines)
    {
        int curPositionInLine = 0;
        int curLine = 0;
        HashSet<char> symsToPrint = new HashSet<char>(new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' });
        List<StringBuilder> finalTerminal = new List<StringBuilder>() { new StringBuilder() };

        for (int i = 0; i < comandLines.Length; ++i)
        {
            char curSym = comandLines[i];

            if (symsToPrint.Contains(curSym))
            {
                finalTerminal[curLine].Insert(curPositionInLine, curSym);
                curPositionInLine++;
                continue;
            }
            else if (curSym == 'L' || curSym == 'R')
            {
                if (curSym == 'L')
                {
                    if (curPositionInLine > 0) { curPositionInLine--; }
                }
                else
                {
                    if (curPositionInLine < finalTerminal[curLine].Length) { curPositionInLine++; }
                }
                continue;
            }
            else if (curSym == 'U' || curSym == 'D')
            {
                if (curSym == 'U')
                {
                    if (curLine > 0)
                    {
                        --curLine;
                        if (finalTerminal[curLine].Length < curPositionInLine)
                        {
                            curPositionInLine = finalTerminal[curLine].Length;
                        }
                    }
                }
                else
                {
                    if (curLine < finalTerminal.Count - 1)
                    {
                        ++curLine;
                        if (finalTerminal[curLine].Length < curPositionInLine)
                        {
                            curPositionInLine = finalTerminal[curLine].Length;
                        }
                    }
                }
                continue;
            }
            else if (curSym == 'B' || curSym == 'E')
            {
                if (curSym == 'B')
                {
                    curPositionInLine = 0;
                }
                else
                {
                    curPositionInLine = finalTerminal[curLine].Length;
                }
                continue;
            }
            else if (curSym == 'N')
            {
                if (curPositionInLine == finalTerminal[curLine].Length)
                {
                    curLine++;
                    finalTerminal.Insert(curLine, new StringBuilder());
                    curPositionInLine = 0;
                }
                else
                {
                    int numSyms = finalTerminal[curLine].Length - curPositionInLine;
                    string tmpLine = finalTerminal[curLine].ToString(curPositionInLine, numSyms);
                    finalTerminal[curLine].Remove(curPositionInLine, numSyms);
                    curLine++;
                    finalTerminal.Insert(curLine, new StringBuilder(tmpLine));
                    curPositionInLine = 0;
                }
                continue;
            }
        }

        StringBuilder ans = new StringBuilder();
        for (int i = 0; i < finalTerminal.Count; ++i)
        {
            ans.Append(finalTerminal[i].ToString() + "\n");
        }
        ans.Append('-');

        return ans.ToString();
    }
}