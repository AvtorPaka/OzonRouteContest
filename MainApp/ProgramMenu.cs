namespace MainApp;

public class ProgramMenu
{
    private const string choosedTask = "    \u001b[32m";
    private const string taskEnd = "\u001b[0m";
    private int[] textGrid = new int[7]{1 ,2 ,3 ,4, 5, 6, 7};
    private (int, int) cursorPos;
    private int iPosition;
    private int jPosition;
    private bool haveChoosed;

    public ProgramMenu()
    {
        iPosition = 0;
        jPosition = 0;
        haveChoosed = false;
        cursorPos = (0, 0);
    }

    private void ChooseTask()
    {
        ConsoleKeyInfo keyInfo;
        Console.CursorVisible = false;

        while (!haveChoosed)
        {   
            Console.Clear();
            Console.SetCursorPosition(cursorPos.Item1, cursorPos.Item2);

            Console.WriteLine($"   Choose task to run\n{Environment.NewLine}Main Task № | Test Task № ");
            for (int i = 0; i < 7; ++i)
            {   
                Console.Write($"\n{(iPosition == i && jPosition == 0 ? choosedTask + "> " : new string(' ', 5))}{textGrid[i]}{taskEnd}\t{new string(' ', 4)}|");
                Console.Write($"{(iPosition == i&& jPosition == 1 ? choosedTask + " > " : new string(' ', 6))}{textGrid[i]}{taskEnd}");
            }

            keyInfo = Console.ReadKey(true);
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    iPosition = (iPosition > 0 ? iPosition - 1 : 6) % 7;
                    break;
                case ConsoleKey.DownArrow:
                    iPosition = (iPosition + 1) % 7;
                    break;
                case ConsoleKey.RightArrow:
                    jPosition = (jPosition + 1) % 2;
                    break;
                case ConsoleKey.LeftArrow:
                    jPosition = (jPosition > 0 ? jPosition - 1 : 1) % 2;
                    break;
                case ConsoleKey.Enter:
                    haveChoosed = true;
                    Console.Clear();
                    Console.CursorVisible = true;
                    Console.WriteLine($"{(jPosition == 1 ? "Test " : "")}Task № {iPosition + 1}:");
                    SolutionsClass.CallSolution(textGrid[iPosition], jPosition == 1);
                    break;
            }
        }

        haveChoosed = false;
    }

    public void Run()
    {
        ConsoleKeyInfo retryKey;
        do
        {
            ChooseTask();
            Console.WriteLine("\nPress 'Enter' to repeat the program\nPress 'Escape' to exit.");
            retryKey = Console.ReadKey(true);
            while (retryKey.Key != ConsoleKey.Escape && retryKey.Key != ConsoleKey.Enter)
            {
                retryKey = Console.ReadKey(true);
            }
        } while (retryKey.Key != ConsoleKey.Escape && retryKey.Key == ConsoleKey.Enter);
    }
}