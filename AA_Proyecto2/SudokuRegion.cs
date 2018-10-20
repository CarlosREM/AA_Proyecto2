using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AA_Proyecto2
{
    public class SudokuRegion
    {
        private SudokuCell[] Region;
        private int Length { get; set; } = 0;

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="Dimension"></param>
        public SudokuRegion(int Dimension)
        {
            Region = new SudokuCell[Dimension];
        }
        
        public void test()
        {
            if (Length == Region.Length)
            {
                System.Drawing.Color c = Tetromino.PickColor();
                foreach (SudokuCell cell in Region)
                    cell.BackColor = c;
            }
        }

        /// <summary>
        /// Adds a cell to the Region Array
        /// </summary>
        /// <param name="NewCell"></param>
        public void AddCell(SudokuCell NewCell)
        {
            if (Length < Region.Length)
            {
                Region[Length] = NewCell;
                NewCell.sRegion = this;
                Length++;
            }
        }

        /// <summary>
        /// Checks for an existing number in the region
        /// </summary>
        /// <param name="Number"></param>
        /// <returns></returns>
        public Boolean CheckNumber(int Number)
        {
            bool NumberFound = false;
            if (Length == Region.Length)
            {
                foreach (SudokuCell Cell in Region)
                {
                    if (Cell.GetNumber() == Number)
                    {
                        NumberFound = true;
                        break;
                    }
                }
            }
            return NumberFound;
        }

        override public string ToString()
        {
            string strOut = "Region contains cells: \n";
            for (int i = 0; i < Region.Length; i++)
                strOut += "\t" + Region[i].ToString() + "\n";
            return strOut;
        }
    }
}
