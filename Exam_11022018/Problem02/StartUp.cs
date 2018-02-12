using System;
using System.Linq;

namespace Problem02
{
    public class StartUp
    {


        public static void Main()
        {
            int samStartRow = 0;
            int samStartCol = 0;
            int nStartRow = 0;
            int nStartCol = 0;
            var rows = int.Parse(Console.ReadLine());
            char[][] matrix = new char[rows][];

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine().ToCharArray();
            }

            string commands = Console.ReadLine();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 'S')
                    {
                        samStartRow = i;
                        samStartCol = j;
                    }
                }
            }

            Console.WriteLine($"{samStartRow}{samStartCol}");

            int samRow = 1;
            int samCol = 1;
            var turns = 0;
            SamPosition(matrix, commands, turns);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < matrix.Length; j++)
                {
                    if (matrix[i][j] == 'S')
                    {
                        samRow = i;
                        samCol = j;
                    }

                    if (matrix[i][j] == 'N')
                    {
                        nStartRow = i;
                        nStartCol = j;
                    }
                }
            }
            Console.WriteLine($"{samRow} {samCol}");
            char[][] enemyMove = EnemyMove(matrix, rows);

            for (int i = 0; i < UPPER; i++)
            {
                
            }


        }
        

        private static char[][] EnemyMove(char[][] matrix, int rows)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'b')
                    {
                        if (col == matrix[row].Length - 1)
                        {
                            matrix[row][col] = 'd';
                        }
                        else
                        {
                            matrix[row][col + 1] = 'b';
                            matrix[row][col] = '.';
                            break;
                        }
                    }

                    if (matrix[row][col] == 'd')
                    {
                        if (col == matrix[row].Length - 1)
                        {
                            matrix[row][col] = 'b';
                        }
                        else
                        {
                            matrix[row][col - 1] = 'd';
                            matrix[row][col] = '.';
                            break;
                        }
                    }
                    return matrix;
                }
            }
        }
    }
}

/*•	First, Enemies move either left or right, depending on which direction they are facing (b goes right, d goes left)
o	If an enemy is standing on the edge of the room, he flips his direction (from d to b or from b to d) and doesn’t move for the rest of the turn.
•	If an enemy is on the same row as Sam, and also facing Sam (eg. .b.S.), the enemy kills Sam.
•	After that, Sam moves in the direction he is instructed to (either U/D/L/R or W).
o	U -> Up, D -> Down, L -> Left, R -> Right, W -> Wait (Sam doesn’t move)
•	If Sam moves onto an enemy (same row and column), Sam kills the enemy and leaves no trace of him.
•	If Sam is reaches the same row as Nikoladze, Sam kills Nikoladze (replacing him with an X)
*/

/*Input
•	On the first line of input, you will receive n – the number of rows the room will consist of. Range: [2-20]
•	On the next n lines, you will receive the room, which Sam will have to navigate.
•	On the final line of input, you will receive a sequence of directions – one of (U, D, L, R, W)
Output
•	If Sam is killed, print “Sam died at {row}, {col}”
•	If Nikoladze is killed, print “Nikoladze killed!”
•	Then, in both cases, print the final state of the room on the console, with either Sam or Nikoladze’s symbols replaced by an X.
*/

/*5
......N...
b.........
..d.......
......d...
.....S....
UUUUR
*/
