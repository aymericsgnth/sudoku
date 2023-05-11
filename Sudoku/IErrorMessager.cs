using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public interface IErrorMessager
    {
        /// <summary>
        /// Show an error message
        /// </summary>
        /// <param name="message"></param>
        void ShowErrorMessage(string message);

        /// <summary>
        /// Hide error message
        /// </summary>
        void HideErrorMessage();
    }
}
