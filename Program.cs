class Programm
{
    static void MakeCombinations(bool[][] combination, int positionY, int positionX, int elements)
    {
        if (elements == 0)
        {
            foreach (var line in combination)
            {
                foreach (var i in line)
                    Console.Write(i ? 1 : 0);
                Console.WriteLine();
            }
            Console.WriteLine();
            return;
        }

        if (positionX == combination.Length && positionY == combination.Length - 1)
            return;

        if (positionX != combination.Length)
        {
            if (CheckPosition(combination, positionY, positionX))
            {
                combination[positionY][positionX] = true;
                MakeCombinations(combination, positionY, positionX + 1, elements - 1);
            }
            combination[positionY][positionX] = false;
            MakeCombinations(combination, positionY, positionX + 1, elements);
        }
        else
            MakeCombinations(combination, positionY + 1, 0, elements);
    }

    private static bool CheckPosition(bool[][] combination, int positionY, int positionX)
    {
        var moves = new List<bool>();

        for (int i = 0; i < combination.Length; i++)
        {
            for (int j = 0; j < combination.Length; j++)
            {
                var offsetY = Math.Abs(positionY - i);
                var offsetX = Math.Abs(positionX - j);

                if (offsetX == offsetY || offsetX == 0 || offsetY == 0)
                    moves.Add(combination[i][j]);
            }
        }

        return !moves.Contains(true);
    }

    public static void Main()
    {
        var deskSize = 5;
        bool[][] desk = new bool[deskSize][];
        for (int i = 0; i < deskSize; i++)
            desk[i] = new bool[deskSize];

        CheckPosition(desk, 1, 1);
        MakeCombinations(desk, 0, 0, deskSize);
    }
}