using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    static class SudokuSolver
    {
        public static void SolveSudoku(char[,] board)
        {
            if (board == null || board.Length == 0)
                return;
            Solve(board);
        }
        private static bool Solve(char[,] board)
        {
            /// iterate on all lines
            for (int rowNumber = 0; rowNumber < board.GetLength(0); rowNumber++)
            {
                // iterate on all columns
                for (int columnNumber = 0; columnNumber < board.GetLength(1); columnNumber++)
                {
                    // if the element is empty
                    if (board[rowNumber, columnNumber] == ' ')
                    {
                        for (char c = '1'; c <= '9'; c++)
                        {
                            if (IsValid(board, rowNumber, columnNumber, c))
                            {
                                board[rowNumber, columnNumber] = c;

                                if (Solve(board))
                                {
                                    return true;
                                }
                                else
                                {
                                    board[rowNumber, columnNumber] = ' ';
                                }

                            }
                        }
                        return false;
                    }
                }
            }
            return true;
        }
        /// <summary>
        /// Look if the character can be placed at the position
        /// </summary>
        /// <param name="board"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        private static bool IsValid(char[,] board, int row, int col, char c)
        {
            for (int i = 0; i < 9; i++)
            {
                
                //check row  
                if (board[i, col] != ' ' && board[i, col] == c)
                    return false;
                //check column  
                if (board[row, i] != ' ' && board[row, i] == c)
                    return false;
                //check 3*3 block  
                if (
                    /* WARNING : INT / INT => INT
                     * example with row = 4, col = 1, i = 1 :
                     * board[3*(4/3) + 1/3, 3*(1/3) + i % 3]
                     * => board[3 + 0, 0 + 0]
                     * => board[3, 0]
                     */
                    board[3 * (row / 3) + i / 3, /*end of first el */ 3 * (col / 3) + i % 3] != ' '
                    && board[3 * (row / 3) + i / 3,/*end of second el*/ 3 * (col / 3) + i % 3] == c
                    )
                {
                    return false;
                }
                
            }
            return true;
        }
    }
}
