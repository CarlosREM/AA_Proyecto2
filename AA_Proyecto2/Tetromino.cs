using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace AA_Proyecto2
{
    public class Tetromino
    {
        public enum Orientation {Left, Up, Right, Down};

        private int Result;
        private string Shape;
        private Orientation Direction;
        private string Mode = "";
        private SudokuCell[] Cells;
        private int Length { get; set; } = 0;
        private readonly Color BackColor;

        public string GetDirection()
        {
            string strOut = "";
            switch(Direction)
            {
                case (Orientation.Left):
                    strOut = "L";
                    break;
                case (Orientation.Up):
                    strOut = "U";
                    break;
                case (Orientation.Right):
                    strOut = "R";
                    break;
                case (Orientation.Down):
                    strOut = "D";
                    break;
            }
            return strOut;
        }
        public void SetDirection(string strDirection)
        {
            switch(strDirection)
            {
                case ("L"):
                    Direction = Orientation.Left;
                    break;
                case ("U"):
                    Direction = Orientation.Up;
                    break;
                case ("R"):
                    Direction = Orientation.Right;
                    break;
                case ("D"):
                    Direction = Orientation.Down;
                    break;
            }
        }

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="Board"></param>
        /// <param name="Row"></param>
        /// <param name="Column"></param>
        public Tetromino(Sudoku Board, int Row, int Column)
        {
            Cells = new SudokuCell[4];
            BackColor = PickColor();
            Result = new Random().Next(2);
            ArrangeTetro(Board, Row, Column);
            AssignResult();
        }

        /// <summary>
        /// Constructor from String (Sudoku Load).
        /// Assigns Attributes based on the formatted string
        /// </summary>
        /// <param name="Board"></param>
        /// <param name="strInfo"></param>
        public Tetromino(Sudoku Board, string strInfo)
        {
            //strInfo = 0[Shape] - 1[Direction] - 2[Mode] - 3[Result] - +4[Cells...] 5 6 7
            BackColor = PickColor();
            string[] infoTokens = strInfo.Split('-');
            Shape = infoTokens[0];
            SetDirection(infoTokens[1]);
            Mode = infoTokens[2];
            Result = int.Parse(infoTokens[3]);

            string[] coordinates;
            int cellNum = infoTokens.Length - 4,
                Row, Column;
            Cells = new SudokuCell[cellNum];
            for (int i = 0; cellNum + i < infoTokens.Length; i++)
            {
                coordinates = infoTokens[cellNum + i].Split(',');
                Row = int.Parse(coordinates[0]);
                Column = int.Parse(coordinates[1]);
                AddCell(Board.GetCellAt(Row, Column));
            }
        }

        /// <summary>
        /// Arranges the Shape of the Tetromino based on the SudokuCell location
        /// </summary>
        /// <param name="Board"></param>
        /// <param name="Row"></param>
        /// <param name="Column"></param>
        private void ArrangeTetro(Sudoku Board, int Row, int Column)
        {
            List<string> Shapes = new List<string> { "O", "I", "J", "L", "S", "T", "Z" };
            int shapeIndex;
            bool CellTetroVerify = false;
            Random r = new Random();
            while (Length < 4)
            {
                if (Shapes.Count > 0)
                {
                    shapeIndex = r.Next(2);//Shapes.Count);
                    Shape = Shapes[shapeIndex];
                    Direction = (Orientation) r.Next(4);
                    switch (Shape)
                    {
                        case ("O"):
                            CellTetroVerify = Arrange_O(Board, Row, Column);
                            break;

                        case ("I"):
                            CellTetroVerify = Arrange_I(Board, Row, Column);
                            break;

                        case ("J"):
                            CellTetroVerify = Arrange_J(Board, Row, Column); //WIP
                            break;

                        case ("L"):
                            CellTetroVerify = Arrange_L(Board, Row, Column); //WIP
                            break;

                        case ("S"):
                            CellTetroVerify = Arrange_S(Board, Row, Column); //WIP
                            break;

                        case ("T"):
                            CellTetroVerify = Arrange_T(Board, Row, Column); //WIP
                            break;

                        case ("Z"):
                            CellTetroVerify = Arrange_Z(Board, Row, Column); //WIP
                            break;
                    }
                    if (CellTetroVerify)
                        Shapes.RemoveAt(shapeIndex);
                }
                else
                {
                    Shape = "D";
                    Cells = new SudokuCell[1];
                    Length = 1;
                    AddCell(Board.GetCellAt(Row, Column));
                    break;
                }
            }
        }

        private bool Arrange_O(Sudoku Board, int Row, int Column)
        {
            bool CellWithTetro = false;
            try
            {
                AddCell(Board.GetCellAt(Row, Column));
                AddCell(Board.GetCellAt(Row, Column+1));
                AddCell(Board.GetCellAt(Row+1, Column));
                AddCell(Board.GetCellAt(Row+1, Column+1));
            }
            catch (Exception e)
            {
                if (e.Message == "Celda ya tiene Tetro")
                {
                    ResetCells();
                    CellWithTetro = true;
                }
            }
            return CellWithTetro;
        }

        private bool Arrange_I(Sudoku Board, int Row, int Column)
        {
            bool CellWithTetro = false;
            try
            {
                if (Direction == Orientation.Left || Direction == Orientation.Right)
                {
                    AddCell(Board.GetCellAt(Row, Column));
                    AddCell(Board.GetCellAt(Row, Column + 1));
                    AddCell(Board.GetCellAt(Row, Column + 2));
                    AddCell(Board.GetCellAt(Row, Column + 3));
                }
                else
                {
                    AddCell(Board.GetCellAt(Row, Column));
                    AddCell(Board.GetCellAt(Row + 1, Column));
                    AddCell(Board.GetCellAt(Row + 2, Column));
                    AddCell(Board.GetCellAt(Row + 3, Column));
                }
            }
            catch (Exception e)
            {
                if (e.Message == "Celda ya tiene Tetro")
                {
                    ResetCells();
                    CellWithTetro = true;
                }
            }
            return CellWithTetro;
        }

        private bool Arrange_J(Sudoku Board, int Row, int Column) //WIP
        {
            bool CellWithTetro = false;
            try
            {
                switch(Direction)
                {
                    case (Orientation.Left):
                        break;

                    case (Orientation.Up):
                        break;

                    case (Orientation.Right):
                        break;

                    case (Orientation.Down):
                        break;
                }
            }
            catch (Exception e)
            {
                if (e.Message == "Celda ya tiene Tetro")
                {
                    ResetCells();
                    CellWithTetro = true;
                }
            }
            return CellWithTetro;
        }

        private bool Arrange_L(Sudoku Board, int Row, int Column) //WIP
        {
            bool CellWithTetro = false;
            try
            {
                switch (Direction)
                {
                    case (Orientation.Left):
                        break;

                    case (Orientation.Up):
                        break;

                    case (Orientation.Right):
                        break;

                    case (Orientation.Down):
                        break;
                }
            }
            catch (Exception e)
            {
                if (e.Message == "Celda ya tiene Tetro")
                {
                    ResetCells();
                    CellWithTetro = true;
                }
            }
            return CellWithTetro;
        }

        private bool Arrange_S(Sudoku Board, int Row, int Column) //WIP
        {
            bool CellWithTetro = false;
            try
            {
                switch (Direction)
                {
                    case (Orientation.Left):
                        break;

                    case (Orientation.Up):
                        break;

                    case (Orientation.Right):
                        break;

                    case (Orientation.Down):
                        break;
                }
            }
            catch (Exception e)
            {
                if (e.Message == "Celda ya tiene Tetro")
                {
                    ResetCells();
                    CellWithTetro = true;
                }
            }
            return CellWithTetro;
        }

        private bool Arrange_T(Sudoku Board, int Row, int Column) //WIP
        {
            bool CellWithTetro = false;
            try
            {
                switch (Direction)
                {
                    case (Orientation.Left):
                        break;

                    case (Orientation.Up):
                        break;

                    case (Orientation.Right):
                        break;

                    case (Orientation.Down):
                        break;
                }
            }
            catch (Exception e)
            {
                if (e.Message == "Celda ya tiene Tetro")
                {
                    ResetCells();
                    CellWithTetro = true;
                }
            }
            return CellWithTetro;
        }

        private bool Arrange_Z(Sudoku Board, int Row, int Column) //WIP
        {
            bool CellWithTetro = false;
            try
            {
                switch (Direction)
                {
                    case (Orientation.Left):
                        break;

                    case (Orientation.Up):
                        break;

                    case (Orientation.Right):
                        break;

                    case (Orientation.Down):
                        break;
                }
            }
            catch (Exception e)
            {
                if (e.Message == "Celda ya tiene Tetro")
                {
                    ResetCells();
                    CellWithTetro = true;
                }
            }
            return CellWithTetro;
        }

        /// <summary>
        /// Adds a cell to the Cells Array (to a maximum of 4).
        /// NewCell.sTetro must return 'null'
        /// </summary>
        /// <param name="NewCell"></param>
        public void AddCell(SudokuCell NewCell)
        {
            if (Length < 4 && NewCell.sTetro == null)
            {
                Cells[Length] = NewCell;
                NewCell.sTetro = this;
                NewCell.BackColor = BackColor;
                Length++;
            }
            else
                throw new Exception("Celda ya tiene Tetro");
        }

        /// <summary>
        /// Clears the sTetro of every SudokuCell contained in the Cells array, and sets Lenght to zero
        /// </summary>
        public void ResetCells()
        {
            for (int i = 0; i < Length; i++) {
                Cells[i].sTetro = null;
                Cells[i].BackColor = System.Drawing.SystemColors.Info;
            }
            Cells = new SudokuCell[4];
            Length = 0;
        }
        
        /// <summary>
        /// Assigns the result for the sum/multiplication on the Tetromino
        /// and displays it on the upper-leftmost cell (position 0 on the array)
        /// </summary>
        private void AssignResult()
        {
            if (Length > 1)
            {
                if (Result == 0)
                {
                    Mode = "+";
                    foreach (SudokuCell Cell in Cells)
                        Result += Cell.GetNumber();
                }
                else
                {
                    Mode = "x";
                    foreach (SudokuCell Cell in Cells)
                        Result *= Cell.GetNumber();
                }
            }
            else
                Result = Cells[0].GetNumber();
            Cells[0].SetResult(Result, Mode);
        }

        /// <summary>
        /// Checks for an existing number in the Tetromino
        /// </summary>
        /// <param name="Number"></param>
        /// <returns></returns>
        public bool CheckNumber(int Number)
        {
            bool NumberFound = false;
            foreach (SudokuCell Cell in Cells)
            {
                if (Cell.GetNumber() == Number)
                {
                    NumberFound = true;
                    break;
                }
            }
            return NumberFound;
        }

        public static Color PickColor()
        {
            System.Threading.Thread.Sleep(50);
            Random rand = new Random();
            int max = byte.MaxValue + 1,
                min = max / 2;
            int r = rand.Next(min, max);
            int g = rand.Next(min, max);
            int b = rand.Next(min, max);
            return Color.FromArgb(r, g, b);
        }

        public override string ToString()
        {
            string strOut = Shape + "-" + GetDirection() + "-" + Mode + "-" + Result.ToString() + "-";
            SudokuCell cell;
            for (int i = 0; i < Length; i++)
            {
                cell = Cells[i];
                strOut += cell.Row.ToString() + "," + cell.Column.ToString();
                if (i != Length - 1)
                    strOut += "-";
            }
            return strOut;
            //Output = [Shape]-[Direction]-[Mode]-[Result]-[Cells...]
        }
    }
}
