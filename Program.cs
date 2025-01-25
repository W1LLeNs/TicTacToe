public class TicTacToe
{
    public void Play()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        int activePlayer = 0;
        char[] markers = new char[] { 'X', 'O' };

        string[,] playField = new string[3, 3];
        InitiatePlayfield(playField);

        bool gameRunning = true;

        while (gameRunning)
        {
            Console.Clear();
            PrintPlayfield(playField);
            activePlayer = MakeMove(activePlayer, markers, playField);

            if (CheckWin(playField, markers[activePlayer == 0 ? 1 : 0]))
            {
                Console.Clear();
                PrintPlayfield(playField);
                Console.WriteLine($"Гравець {markers[activePlayer == 0 ? 1 : 0]} виграв!");
                gameRunning = false;
            }
            else if (CheckTie(playField))
            {
                Console.Clear();
                PrintPlayfield(playField);
                Console.WriteLine("Нічия!");
                gameRunning = false;
            }
        }
    }
    public void InitiatePlayfield(string[,] playField)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        for (int i = 0; i < playField.GetLength(0); i++)
            for (int j = 0; j < playField.GetLength(1); j++)
                playField[i, j] = (i * 3 + j + 1).ToString();
    }
    public void PrintPlayfield(string[,] playField)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        for (int i = 0; i < playField.GetLength(0); i++)
        {
            for (int j = 0; j < playField.GetLength(1); j++)
            {
                Console.Write($" {playField[i, j]} ");
                if (j < playField.GetLength(1) - 1) Console.Write("|");
            }
            Console.WriteLine();
            if (i < playField.GetLength(0) - 1) Console.WriteLine("---+---+---");
        }
    }
    public int MakeMove(int activePlayer, char[] markers, string[,] playField)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        while (true)
        {
            Console.WriteLine($"\nГравець {markers[activePlayer]}, введіть ваш хід (1-9): ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int move) && move >= 1 && move <= 9)
            {
                int row = (move - 1) / 3;
                int col = (move - 1) % 3;

                if (playField[row, col] != "X" && playField[row, col] != "O")
                {
                    playField[row, col] = markers[activePlayer].ToString();
                    return activePlayer == 0 ? 1 : 0;
                }
                else
                {
                    Console.WriteLine("Ячейка зайнята!");
                }
            }
            else
            {
                Console.WriteLine("Неправильне значення! Введіть цифру від 1 до 9");
            }
        }
    }
    public bool CheckWin(string[,] playField, char marker)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        for (int i = 0; i < 3; i++)
        {
            if ((playField[i, 0] == marker.ToString() && playField[i, 1] == marker.ToString() && playField[i, 2] == marker.ToString()) ||
                (playField[0, i] == marker.ToString() && playField[1, i] == marker.ToString() && playField[2, i] == marker.ToString()))
                return true;
        }
        if ((playField[0, 0] == marker.ToString() && playField[1, 1] == marker.ToString() && playField[2, 2] == marker.ToString()) ||
            (playField[0, 2] == marker.ToString() && playField[1, 1] == marker.ToString() && playField[2, 0] == marker.ToString()))
            return true;

        return false;
    }
    public bool CheckTie(string[,] playField)
    {
        foreach (string cell in playField)
            if (cell != "X" && cell != "O")
                return false;
        return true;
    }
}
class Program
{
    static void Main()
    {
        TicTacToe game = new TicTacToe();
        game.Play();
    }
}
