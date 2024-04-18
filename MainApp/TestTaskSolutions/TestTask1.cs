namespace MainApp;

public static partial class SolutionsClass
{
    static void TestTask1()
    {
        using StreamReader input = new StreamReader(Console.OpenStandardInput());
        using StreamWriter output = new StreamWriter(Console.OpenStandardOutput());

        int[] lstWithData = input.ReadLine()!.Split().Select(x => Convert.ToInt32(x)).ToArray();
        output.WriteLine(SeaBattle(lstWithData) ? "Yes" : "No");
    }

    private static bool SeaBattle(int[] shipInfo)
    {
        int oneDeck = 0;
        int twoDeck = 0;
        int threeDeck = 0;
        int maxDeck = 0;

        for (int i = 0; i < shipInfo.Length; ++i)
        {
            if (shipInfo[i] == 1) { oneDeck++; }
            else if (shipInfo[i] == 2) { twoDeck++; }
            else if (shipInfo[i] == 3) { threeDeck++; }
            else { maxDeck++; }
        }

        if (oneDeck == 4 && twoDeck == 3 && threeDeck == 2 && maxDeck == 1)
        {
            return true;
        }
        return false;
    }
}