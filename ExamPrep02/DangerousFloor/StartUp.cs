using System;
using System.Linq;

namespace DangerousFloor
{
    public class StartUp
    {
        private static char[][] board;

        public static void Main()
        {
            board = new char[8][];

            for (int row = 0; row < board.Length; row++)
            {
                board[row] = Console.ReadLine()
                    .Split(",")
                    .Select(char.Parse)
                    .ToArray();
            }

            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                var figureType = command[0];
                var startingRow = int.Parse(command[1].ToString());
                var startingCol = int.Parse(command[2].ToString());
                var newRow = int.Parse(command[4].ToString());
                var newCol = int.Parse(command[5].ToString());

                if (!CheckFigureExist(figureType, startingRow, startingCol))
                {
                    Console.WriteLine("There is no such a piece!");
                    continue;
                }

                if (!IsValidMove(figureType, startingRow, startingCol, newRow, newCol))
                {
                    Console.WriteLine("Invalid move!");
                    continue;
                }

                if (!OutOfBoard(newRow, newCol))
                {
                    Console.WriteLine("Move go out of board!");
                    continue;
                }

                board[newRow][newCol] = figureType;
                board[startingRow][startingCol] = 'x';
            }
        }

        private static bool OutOfBoard(int newRow, int newCol)
        {
            bool validRow = newRow >= 0 && newRow <= 7;
            bool validCol = newCol >= 0 && newCol <= 7;

            return validRow && validCol;
        }

        private static bool IsValidMove(char figureType, int startingRow, int startingCol, int newRow, int newCol)
        {
            switch (figureType)
            {
                case 'P':
                    return ValidPawnMove(startingRow,startingCol,newRow,newCol);
                case 'R':
                    return ValidRookMove(startingRow, startingCol, newRow, newCol);
                case 'B':
                    return ValidBishopMove(startingRow, startingCol, newRow, newCol);
                case 'Q':
                    return ValidRookMove(startingRow, startingCol, newRow, newCol) ||
                           ValidBishopMove(startingRow, startingCol, newRow, newCol);
                case 'K':
                    return ValidKingMove(startingRow, startingCol, newRow, newCol);
                    default:
                        throw new Exception();
            }
        }

        private static bool ValidKingMove(int startingRow, int startingCol, int newRow, int newCol)
        {
            bool validRow = Math.Abs(startingRow - newRow) == 1 && Math.Abs(startingCol - newCol) == 0;
            bool validCol = Math.Abs(startingCol - newCol) == 1 && Math.Abs(startingRow - newRow) == 0;
            bool validDiagonal = Math.Abs(startingCol - newCol) == 1 && Math.Abs(startingRow - newRow) == 1;

            return validRow || validCol || validDiagonal;
        }

        private static bool ValidBishopMove(int startingRow, int startingCol, int newRow, int newCol)
        {
            return Math.Abs(startingRow - newRow) == Math.Abs(startingCol - newCol);
        }

        private static bool ValidRookMove(int startingRow, int startingCol, int newRow, int newCol)
        {
            bool validRow = startingRow == newRow;
            bool validCol = startingCol == newCol;

            return validRow || validCol;
        }

        private static bool ValidPawnMove(int startingRow, int startingCol, int newRow, int newCol)
        {
            bool validColumn = startingCol == newCol;
            bool validRow = startingRow -1 == newRow;

            return validRow && validColumn;
        }

        private static bool CheckFigureExist(char figureType, int startingRow, int startingCol)
        {
            return board[startingRow][startingCol] == figureType;
        }
    }
}