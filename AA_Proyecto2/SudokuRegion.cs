using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AA_Proyecto2
{
    class SudokuRegion
    {
        private SudokuCell[] Region;
        private int Length { get; set; } = 0;

        public SudokuRegion(int Dimension)
        {
            Region = new SudokuCell[Dimension];
        }

        public void AddCell(SudokuCell NewCell)
        {
            if (Length < Region.Length)
            {
                Region[Length] = NewCell;
                Length++;
            }
        }

        public Boolean CheckRegion(int Number)
        {
            bool NumberFound = false;
            foreach(SudokuCell Cell in Region)
            {
                if (Cell.GetNumber() == Number)
                {
                    NumberFound = true;
                    break;
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
