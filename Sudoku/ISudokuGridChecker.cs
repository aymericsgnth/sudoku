using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    /*
     * Aymeric Siegenthaler
     * 11.05.2023
     * ISudokuGridChecker.cs
     */
    public interface ISudokuGridChecker : IErrorMessager
    {
        string[][] GetGrid();
    }
}
