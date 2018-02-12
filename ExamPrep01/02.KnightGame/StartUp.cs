using System;

namespace _02.KnightGame
{
    public class StartUp
    {
        public static void Main()
        {
            var boardSize = int.Parse(Console.ReadLine());
            var board = new char[boardSize][];

            for (int counter = 0; counter < boardSize; counter++)
            {
                board[counter] = Console.ReadLine().ToCharArray();
            }

            int maxRow = 0;
            int maxColumn = 0;
            int maxAttPositions = 0;
            int countOfRemovedK = 0;

            do
            {
                if (maxAttPositions > 0)
                {
                    board[maxRow][maxColumn] = '0';
                    maxAttPositions = 0;
                    countOfRemovedK++;
                }

                int currentAttPositions = 0;

                for (int row = 0; row < boardSize; row++)
                {
                    for (int column = 0; column < boardSize; column++)
                    {
                        if (board[row][column] == 'K')
                        {
                            currentAttPositions = CalculateAttPos(row, column, board);

                            if (currentAttPositions > maxAttPositions)
                            {
                                maxAttPositions = currentAttPositions;
                                maxRow = row;
                                maxColumn = column;
                            }
                        }
                    }
                }
            } while (maxAttPositions > 0);

            Console.WriteLine(countOfRemovedK);
        }

        static int CalculateAttPos(int row, int column, char[][] board)
        {
            var currentAttPositions = 0;
            if (IsPositionBeenAtt(row - 2, column - 1, board))
            {
                currentAttPositions++;
            }
            if (IsPositionBeenAtt(row - 2, column + 1, board))
            {
                currentAttPositions++;
            }
            if (IsPositionBeenAtt(row - 1, column - 2, board))
            {
                currentAttPositions++;
            }
            if (IsPositionBeenAtt(row - 1, column +2, board))
            {
                currentAttPositions++;
            }
            if (IsPositionBeenAtt(row +1, column -2, board))
            {
                currentAttPositions++;
            }
            if (IsPositionBeenAtt(row +1, column +2, board))
            {
                currentAttPositions++;
            }
            if (IsPositionBeenAtt(row +2, column - 1, board))
            {
                currentAttPositions++;
            }
            if (IsPositionBeenAtt(row +2, column + 1, board))
            {
                currentAttPositions++;
            }

            return currentAttPositions;
        }

        static bool IsPositionBeenAtt(int row, int column, char[][] board)
        {
            return IsPositionOnBoard(row, column, board[0].Length) && board[row][column] == 'K';
        }

        static bool IsPositionOnBoard(int row, int column, int boardSize)
        {
            return row >= 0 && row < boardSize && column >= 0 && column < boardSize;
        }
    }
}