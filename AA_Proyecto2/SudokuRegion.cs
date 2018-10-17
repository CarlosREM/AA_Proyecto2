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

        public void AddCell(SudokuCell NewCell)
        {
            if (Length < Region.Length)
            {
                Region[Length] = NewCell;
                NewCell.sRegion = this;
                Length++;
            }
        }

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
