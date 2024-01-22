#define DEBUG_MODE
using System;
using System.Collections.Generic;

namespace _04_Maze
{
	class Program
	{
		class AllPathsInLabyrinth
		{
			static char[,] lab =
			{
				{' ', ' ', ' ', '*', ' ', ' ', ' ' },
				{'*', '*', ' ', '*', ' ', '*', ' ' },
				{' ', ' ', ' ', ' ', ' ', ' ', ' ' },
				{' ', '*', '*', '*', '*', '*', ' ' },
				{' ', ' ', ' ', '*', ' ', ' ', 'e' },
			};
			static List<char> path = new List<char>();

			static bool InRange(int row, int col)
			{
				bool rowInRange = row >= 0 && row < lab.GetLength(0);
				bool colInRange = col >= 0 && col < lab.GetLength(1);
				return rowInRange && colInRange;
			}

			static void FindPathToExit(int row, int col, char direction)
			{
#if DEBUG_MODE
				PrintLabyrinth(row, col);
#endif
				if (!InRange(row, col))
				{
					return;
				}

				path.Add(direction);

				if (lab[row, col] == 'e')
				{
					PrintPath(path);
				}

				if (lab[row, col] == ' ')
				{
					lab[row, col] = 's';
					FindPathToExit(row, col - 1, 'L');
					FindPathToExit(row - 1, col, 'U');
					FindPathToExit(row, col + 1, 'R');
					FindPathToExit(row + 1, col, 'D');

					lab[row, col] = ' ';
				}

				path.RemoveAt(path.Count - 1);
			}

			private static void PrintLabyrinth(int currentRow, int currentCol)
			{
				for (int row = -1; row <= lab.GetLength(0); row++)
				{
					Console.WriteLine();
					for (int col = -1; col <= lab.GetLength(1); col++)
					{
						if ((row == currentRow) && (col == currentCol))
						{
							Console.BackgroundColor = ConsoleColor.Cyan;
							Console.Write("x");
							Console.BackgroundColor = ConsoleColor.Black;
						}
						else if (!InRange(row, col))
						{
							Console.Write(" ");
						}
						else if (lab[row, col] == ' ')
						{
							Console.Write("-");
						}
						else
						{
							Console.Write(lab[row, col]);
						}
						Console.Write(" ");
					}
				}
				Console.WriteLine();
				Console.ReadKey();
			}

			static void PrintPath(List<char> path)
			{
				Console.Write("Found path to the exit: ");
				foreach (var dir in path)
				{
					Console.Write(dir);
				}
				Console.WriteLine();
			}
			static void Main(string[] args)
			{
				FindPathToExit(0, 0, 'S');
			}
		}
	}
}
