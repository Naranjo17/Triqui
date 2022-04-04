using System;

class Program
{
    static int[,] table;
    static char[] symbols = { '.', 'O', 'X' };
    static int player = 1;
    static bool finished;

    static void Main()
    {
        finished = false;
        table = new int[3, 3];

        while (!finished)
        {
            drawTable();
            setUser(player);
            statusTable();
        }
    }


    private static void drawTable()
    {
        for (int row = 0; row < 3; row++)
        {
            for (int column = 0; column < 3; column++)
            {
                Console.Write(symbols[table[row, column]]);
            }
            Console.WriteLine();
        }
    }

    private static void setUser(int player)
    {
        Console.Write("Enter A Number In The Row 1,2 & 3: ");
        int row = Convert.ToInt32(Console.ReadLine()) - 1;
        Console.Write("Enter A Number In The Column 1,2 & 3: ");
        int column = Convert.ToInt32(Console.ReadLine()) - 1;

        table[row, column] = player;
    }

    private static void statusTable()
    {
        bool winMatch = false;
        for (int row = 0; row < 3; row++)
        {
            if ((table[row, 0] == table[row, 1])
                    && (table[row, 0] == table[row, 2])
                    && (table[row, 0] == player))
                winMatch = true;
        }

        for (int column = 0; column < 3; column++)
        {
            if ((table[0, column] == table[1, column])
                    && (table[0, column] == table[2, column])
                    && (table[0, column] == player))
                winMatch = true;
        }

        if ((table[0, 0] == table[1, 1])
                && (table[0, 0] == table[2, 2])
                && (table[0, 0] == player))
            winMatch = true;

        if ((table[0, 2] == table[1, 1])
                && (table[0, 2] == table[2, 0])
                && (table[0, 2] == player))
            winMatch = true;

        if (winMatch)
        {
            Console.WriteLine("Congratulations You Win!");
            finished = true;
        }
        int zeros = 0;
        for (int fila = 0; fila < 3; fila++)
        {
            for (int column = 0; column < 3; column++)
            {
                if (table[fila, column] == 0)
                    zeros++;
            }
        }
        if (zeros == 0)
        {
            Console.WriteLine("Clutch");
            finished = true;
        }
        if (player == 1)
            player = 2;
        else
            player = 1;
    }
}