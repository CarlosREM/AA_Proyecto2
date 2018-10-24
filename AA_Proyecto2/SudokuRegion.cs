using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AA_Proyecto2
{
    public class SudokuRegion
    {
        private SudokuCell[] Cells;
        private int Length { get; set; } = 0;

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="Dimension"></param>
        public SudokuRegion(int Dimension)
        {
            Cells = new SudokuCell[Dimension];
        }
        
        public void test()
        {
            if (Length == Cells.Length)
            {
                System.Drawing.Color c = Tetromino.PickColor();
                foreach (SudokuCell cell in Cells)
                    cell.BackColor = c;
            }
        }

        /// <summary>
        /// Adds a cell to the Cells Array
        /// </summary>
        /// <param name="NewCell"></param>
        public void AddCell(SudokuCell NewCell)
        {
            if (Length < Cells.Length)
            {
                Cells[Length] = NewCell;
                NewCell.sRegion = this;
                Length++;
            }
        }

        /// <summary>
        /// Checks for an existing number in the Cells
        /// </summary>
        /// <param name="Number"></param>
        /// <returns></returns>
        public bool CheckNumber(int Number)
        {
            bool NumberFound = false;
            if (Length == Cells.Length)
            {
                foreach (SudokuCell Cell in Cells)
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
            string strOut = "Cells contains cells: \n";
            for (int i = 0; i < Cells.Length; i++)
                strOut += "\t" + Cells[i].ToString() + "\n";
            return strOut;
        }

        /// <summary>
        /// To be used with the Solver
        /// </summary>
        public class RegionTemplate
        {
            private int[,] CellCoord;

            /// <summary>
            /// Creates a Template based on a Region from the Sudoku Board
            /// </summary>
            /// <param name="pRegion"></param>
            public RegionTemplate(SudokuRegion pRegion)
            {
                CellCoord = new int[pRegion.Cells.Length, 2];
                for (int i = 0; i < pRegion.Length; i++)
                {
                    CellCoord[i, 0] = pRegion.Cells[i].Row;
                    CellCoord[i, 1] = pRegion.Cells[i].Column;
                }
            }

            /// <summary>
            /// Checks if the Region contains the respective Coordinates
            /// </summary>
            /// <param name="Row"></param>
            /// <param name="Col"></param>
            /// <returns></returns>
            public bool ContainsCoord(int Row, int Col)
            {
                bool contains = false;
                for (int i = 0; i < CellCoord.GetUpperBound(0) && !contains; i++)
                    if (CellCoord[i, 0] == Row && CellCoord[i, 1] == Col)
                        contains = true;
                return contains;
            }

            /// <summary>
            /// Checks for an existing number in the Cells
            /// </summary>
            /// <param name="newValue"></param>
            /// <param name="Board"></param>
            /// <returns></returns>
            public bool CheckNumber(int newValue, int thisRow, int thisCol, int[,] Board)
            {
                bool NumberFound = false;
                int CellNum = CellCoord.GetUpperBound(0) + 1,
                    Cell;
                for (int i = 0; i < CellNum && !NumberFound; i++)
                {
                    if (CellCoord[i, 0] == thisRow && CellCoord[i, 1] == thisCol)
                        continue;
                    else
                    {
                        Cell = Board[CellCoord[i, 0], CellCoord[i, 1]];
                        if (Cell == newValue)
                        {
                            NumberFound = true;
                            //Console.WriteLine("Found number on Region");
                        }
                    }
                }
                return NumberFound;
            }
        }
    }
}
