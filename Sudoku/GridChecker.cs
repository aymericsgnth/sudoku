using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{/*
  * Aymeric Siegenthaler
  * 11.05.2023
  * GridChecker.cs
  * V1
  */
    public static class GridChecker
    {
        private static readonly int[] NUMBERS = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        /// <summary>
        /// Check if a value is in a specific row
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="row"></param>
        /// <param name="value"></param>
        /// <returns>True if value is in row, false otherwise</returns>
        public static bool ValueIsInRow(string[][] grid, int row, string value)
        {
            return grid[row].Contains(value);
        }

        /// <summary>
        /// Check if a specific value is in a specific column
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns>True if the value is in the column, false otherwise</returns>
        public static bool ValueIsInColumn(string[][] grid, int column, string value)
        {
            
            return grid.Select(gridraw => gridraw.Where(gridCol => Array.IndexOf(gridraw, gridCol) == column).ElementAtOrDefault(0)).ToList().Contains(value);
        }

        /// <summary>
        /// Check if the value is in a specific square
        /// </summary>
        /// <param name="rowOfValue"></param>
        /// <param name="columnOfValue"></param>
        /// <param name="value"></param>
        /// <returns>True if the value is in a specific square, false otherwise</returns>
        public static bool ValueInSquare(string[][] grid, int rowOfValue, int columnOfValue, string value)
        {
            int[] rowsToGet = NUMBERS.Skip(rowOfValue - rowOfValue % 3).Take(3).ToArray();

            int[] colsToTake = NUMBERS.Skip(columnOfValue - columnOfValue % 3).Take(3).ToArray();
            // check if in the square
            for (int i = 0; i < grid.Length; i++)
            {
                if (rowsToGet.Contains(i))
                {
                    string[] gridRow = grid[i];
                    for (int j = 0; j < gridRow.Length; j++)
                    {
                        if (colsToTake.Contains(j) && grid[i][j] == value)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
