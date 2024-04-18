using System.Text;

namespace MainApp;

public static partial class SolutionsClass
{
    static partial void Task4()
    {
        using var input = new StreamReader(Console.OpenStandardInput());
        using var output = new StreamWriter(Console.OpenStandardOutput());

        int t = Convert.ToInt32(input.ReadLine());
        for (int i = 0; i < t; ++ i)
        {
            int[] lstWithData = input.ReadLine()!.Split().Select(x => int.Parse(x)).ToArray();
            int n = lstWithData[0];
            int m = lstWithData[1];

            (int na, int ma) aPosition = (0, 0);
            (int nb, int mb) bPosition = (0, 0);
            List<StringBuilder> mxLayout = new List<StringBuilder>();

            for (int j = 0; j < n; ++j)
            {   
                string lineLayout = input.ReadLine()!;
                int idxa = lineLayout.IndexOf('A');
                int idxb = lineLayout.IndexOf('B');
                if (idxa != -1) {aPosition = (j, idxa);}
                if (idxb != - 1) {bPosition = (j, idxb);}
                mxLayout.Add(new StringBuilder(lineLayout));
            }

            double aDistanceS = Math.Sqrt(Math.Pow(aPosition.na, 2.0) + Math.Pow(aPosition.ma, 2.0));
            double bDistanceS = Math.Sqrt(Math.Pow(bPosition.nb, 2.0) + Math.Pow(bPosition.mb, 2.0));
            double aDistanceE = Math.Sqrt(Math.Pow(n - aPosition.na, 2.0) + Math.Pow(m - aPosition.ma, 2.0));
            double bDistanceE = Math.Sqrt(Math.Pow(n - bPosition.nb, 2.0) + Math.Pow(m - bPosition.mb, 2.0));

            if (Math.Min(aDistanceS, bDistanceS) == aDistanceS)
            {
                List<StringBuilder> pathToS = GetWayToS(mxLayout, aPosition, 'a');
                List<StringBuilder> finalLayout = GetWayToE(pathToS, bPosition, 'b', n, m);
                Console.WriteLine(string.Join("\n", finalLayout));
            }
            else
            {   
                List<StringBuilder> pathToS = GetWayToS(mxLayout, bPosition, 'b');
                List<StringBuilder> finalLayout = GetWayToE(pathToS, aPosition, 'a', n, m);
                Console.WriteLine(string.Join("\n", finalLayout));
            }

        }
    }

    private static List<StringBuilder> GetWayToS(List<StringBuilder> layOut, (int, int) startPosition, char rCh)
    {
        (int, int) curPosition = startPosition;
        while (curPosition != (0,0))
        {   
            if (curPosition.Item1 % 2 == 0 && curPosition.Item2 % 2 == 0)
            {
                if (curPosition.Item1 != 0) {curPosition.Item1--;}
                else {curPosition.Item2--;}
            }
            else if (curPosition.Item1 % 2 == 0 && curPosition.Item2 % 2 != 0) {curPosition.Item2--;}
            else if (curPosition.Item1 % 2 != 0 && curPosition.Item2 % 2 == 0) {curPosition.Item1--;}
            layOut[curPosition.Item1][curPosition.Item2] = rCh;
        }

        if (layOut[0][0] != char.ToUpper(rCh)) {layOut[0][0] = rCh;}
        
        return layOut;
    }

    private static List<StringBuilder> GetWayToE(List<StringBuilder> layOut, (int, int) startPosition, char rCh, int n, int m)
    {
        (int, int) curPosition = startPosition;
        while (curPosition != (n - 1, m - 1))
        {   
            if (curPosition.Item1 % 2 == 0 && curPosition.Item2 % 2 == 0)
            {
                if (curPosition.Item1 != n - 1) {curPosition.Item1++;}
                else {curPosition.Item2++;}
            }
            else if (curPosition.Item1 % 2 == 0 && curPosition.Item2 % 2 != 0) { curPosition.Item2++;}
            else if (curPosition.Item1 % 2 != 0 && curPosition.Item2 % 2 == 0) {curPosition.Item1++;}

            layOut[curPosition.Item1][curPosition.Item2] = rCh;
        }

        if (layOut[n-1][m-1] != char.ToUpper(rCh)) {layOut[n-1][m-1] = rCh;}
        return layOut;
    }
}