using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace AA_Proyecto2
{
    public class Tetromino
    {
        public static List<Color> UsedColors;

        private int Result;
        private string Shape;
        private string Direction;
        private string Mode = " ";
        private SudokuCell[] Cells;
        private int Length { get; set; } = 0;
        private readonly Color BackColor;

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
            Direction = infoTokens[1];
            Mode = infoTokens[2];
            Result = int.Parse(infoTokens[3]);

            string[] coordinates;
            int cellNum = infoTokens.Length,
                Row, Column;
            if (Shape != "D")
                cellNum -= 4;
            else
                cellNum--;
            Cells = new SudokuCell[cellNum];
            for (int i = 0; cellNum + i < infoTokens.Length; i++)
            {
                coordinates = infoTokens[cellNum + i].Split(',');
                Row = int.Parse(coordinates[0]);
                Column = int.Parse(coordinates[1]);
                AddCell(Board.GetCellAt(Row, Column));
            }
            Cells[0].SetResult(Result, Mode);
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
            while (Length < 1)
            {
                if (Shapes.Count > 0)
                {
                    shapeIndex = new Random().Next(Shapes.Count);
                    Shape = Shapes[shapeIndex];
                    switch (Shape)
                    {
                        case ("O"): //0
                            Arrange_O(Board, Row, Column);
                            break;

                        case ("I"): //1
                            Arrange_I(Board, Row, Column);
                            break;

                        case ("J"): //2
                            Arrange_J(Board, Row, Column);
                            break;

                        case ("L"): //3
                            Arrange_L(Board, Row, Column); 
                            break;

                        case ("S"): //4
                            Arrange_S(Board, Row, Column);
                            break;

                        case ("T"): //5
                            Arrange_T(Board, Row, Column);
                            break;

                        case ("Z"): //6
                            Arrange_Z(Board, Row, Column);
                            break;
                    }
                    Shapes.RemoveAt(shapeIndex);
                }
                else
                {
                    Cells = new SudokuCell[1];
                    Shape = "D";
                    Direction = "Dot";
                    AddCell(Board.GetCellAt(Row, Column));
                }
            }
        }

        private void Arrange_O(Sudoku Board, int Row, int Column)
        {
            try
            {
                AddCell(Board.GetCellAt(Row, Column));
                AddCell(Board.GetCellAt(Row, Column+1));
                AddCell(Board.GetCellAt(Row+1, Column));
                AddCell(Board.GetCellAt(Row+1, Column+1));
                Direction = "Square";
            }
            catch (Exception e)
            {
                e.ToString();
                ResetCells();
            }
        }

        private void Arrange_I(Sudoku Board, int Row, int Column)
        {
            int directionIndex = 0;
            List<string> Directions = new List<string> {"Up", "Left"};
            while (Directions.Count > 0 && Length < 4)
            {
                directionIndex = new Random().Next(Directions.Count);
                Direction = Directions[directionIndex];
                try
                {
                    if (Direction == "Up")
                    {
                        AddCell(Board.GetCellAt(Row, Column));
                        AddCell(Board.GetCellAt(Row + 1, Column));
                        AddCell(Board.GetCellAt(Row + 2, Column));
                        AddCell(Board.GetCellAt(Row + 3, Column));
                    }
                    else
                    {
                        AddCell(Board.GetCellAt(Row, Column));
                        AddCell(Board.GetCellAt(Row, Column + 1));
                        AddCell(Board.GetCellAt(Row, Column + 2));
                        AddCell(Board.GetCellAt(Row, Column + 3));
                    }
                }
                catch (Exception e)
                {
                    e.ToString();
                    ResetCells();
                }
                Directions.RemoveAt(directionIndex);
            }
        }

        private void Arrange_J(Sudoku Board, int Row, int Column)
        {
            int directionIndex = 0;
            List<string> Directions = new List<string> { "Up", "Left", "Down", "Right" };
            while (Directions.Count > 0 && Length < 4)
            {
                directionIndex = new Random().Next(Directions.Count);
                Direction = Directions[directionIndex];
                try
                {
                    switch (Direction)
                    {
                        case ("Up"):
                            AddCell(Board.GetCellAt(Row, Column));
                            AddCell(Board.GetCellAt(Row + 1, Column));
                            AddCell(Board.GetCellAt(Row + 2, Column));
                            AddCell(Board.GetCellAt(Row + 2, Column - 1));
                            break;
                        case ("Left"):
                            AddCell(Board.GetCellAt(Row, Column));
                            AddCell(Board.GetCellAt(Row, Column + 1));
                            AddCell(Board.GetCellAt(Row, Column + 2));
                            AddCell(Board.GetCellAt(Row + 1, Column + 2));
                            break;
                        case ("Down"):
                            AddCell(Board.GetCellAt(Row, Column));
                            AddCell(Board.GetCellAt(Row, Column + 1));
                            AddCell(Board.GetCellAt(Row + 1, Column));
                            AddCell(Board.GetCellAt(Row + 2, Column));
                            break;
                        case ("Right"):
                            AddCell(Board.GetCellAt(Row, Column));
                            AddCell(Board.GetCellAt(Row + 1, Column));
                            AddCell(Board.GetCellAt(Row + 1, Column + 1));
                            AddCell(Board.GetCellAt(Row + 1, Column + 1));
                            break;
                    }
                }
                catch (Exception e)
                {
                    e.ToString();
                    ResetCells();
                }
                Directions.RemoveAt(directionIndex);
            }
        }

        private void Arrange_L(Sudoku Board, int Row, int Column)
        {
            int directionIndex = 0;
            List<string> Directions = new List<string> { "Up", "Left", "Down", "Right" };
            while (Directions.Count > 0 && Length < 4)
            {
                directionIndex = new Random().Next(Directions.Count);
                Direction = Directions[directionIndex];
                try
                {
                    switch (Direction)
                    {
                        case ("Up"):
                            AddCell(Board.GetCellAt(Row, Column));
                            AddCell(Board.GetCellAt(Row + 1, Column));
                            AddCell(Board.GetCellAt(Row + 2, Column));
                            AddCell(Board.GetCellAt(Row + 2, Column + 1));
                            break;
                        case ("Left"):
                            AddCell(Board.GetCellAt(Row, Column));
                            AddCell(Board.GetCellAt(Row + 1, Column));
                            AddCell(Board.GetCellAt(Row + 1, Column - 1));
                            AddCell(Board.GetCellAt(Row + 1, Column - 2));
                            break;
                        case ("Down"):
                            AddCell(Board.GetCellAt(Row, Column));
                            AddCell(Board.GetCellAt(Row, Column + 1));
                            AddCell(Board.GetCellAt(Row + 1, Column + 1));
                            AddCell(Board.GetCellAt(Row + 2, Column + 1));
                            break;
                        case ("Right"):
                            AddCell(Board.GetCellAt(Row, Column));
                            AddCell(Board.GetCellAt(Row, Column + 1));
                            AddCell(Board.GetCellAt(Row, Column + 2));
                            AddCell(Board.GetCellAt(Row + 1, Column));
                            break;
                    }
                }
                catch (Exception e)
                {
                    e.ToString();
                    ResetCells();
                }
                Directions.RemoveAt(directionIndex);
            }
        }

        private void Arrange_S(Sudoku Board, int Row, int Column)
        {
            int directionIndex = 0;
            List<string> Directions = new List<string> { "Up", "Right"};
            while (Directions.Count > 0 && Length < 4)
            {
                directionIndex = new Random().Next(Directions.Count);
                Direction = Directions[directionIndex];
                try
                {
                    if (Direction == "Up")
                    {
                        AddCell(Board.GetCellAt(Row, Column));
                        AddCell(Board.GetCellAt(Row + 1, Column));
                        AddCell(Board.GetCellAt(Row + 1, Column + 1));
                        AddCell(Board.GetCellAt(Row + 2, Column + 1));
                    }
                    else
                    {
                        AddCell(Board.GetCellAt(Row, Column));
                        AddCell(Board.GetCellAt(Row, Column + 1));
                        AddCell(Board.GetCellAt(Row + 1, Column - 1));
                        AddCell(Board.GetCellAt(Row + 1, Column));
                    }
                }
                catch (Exception e)
                {
                    e.ToString();
                    ResetCells();
                }
                Directions.RemoveAt(directionIndex);
            }
        }

        private void Arrange_T(Sudoku Board, int Row, int Column)
        {
            int directionIndex = 0;
            List<string> Directions = new List<string> { "Up", "Left", "Down", "Right" };
            while (Directions.Count > 0 && Length < 4)
            {
                directionIndex = new Random().Next(Directions.Count);
                Direction = Directions[directionIndex];
                try
                {
                    switch (Direction)
                    {
                        case ("Up"):
                            AddCell(Board.GetCellAt(Row, Column));
                            AddCell(Board.GetCellAt(Row, Column + 1));
                            AddCell(Board.GetCellAt(Row, Column + 2));
                            AddCell(Board.GetCellAt(Row + 1, Column + 1));
                            break;
                        case ("Left"):
                            AddCell(Board.GetCellAt(Row, Column));
                            AddCell(Board.GetCellAt(Row + 1, Column));
                            AddCell(Board.GetCellAt(Row + 1, Column + 1));
                            AddCell(Board.GetCellAt(Row + 2, Column));
                            break;
                        case ("Down"):
                            AddCell(Board.GetCellAt(Row, Column));
                            AddCell(Board.GetCellAt(Row + 1, Column - 1));
                            AddCell(Board.GetCellAt(Row + 1, Column));
                            AddCell(Board.GetCellAt(Row + 1, Column + 1));
                            break;
                        case ("Right"):
                            AddCell(Board.GetCellAt(Row, Column));
                            AddCell(Board.GetCellAt(Row + 1, Column));
                            AddCell(Board.GetCellAt(Row + 1, Column - 1));
                            AddCell(Board.GetCellAt(Row + 1, Column));
                            break;
                    }
                }
                catch (Exception e)
                {
                    e.ToString();
                    ResetCells();
                }
                Directions.RemoveAt(directionIndex);
            }
        }

        private void Arrange_Z(Sudoku Board, int Row, int Column)
        {
            int directionIndex = 0;
            List<string> Directions = new List<string> { "Up", "Left" };
            while (Directions.Count > 0 && Length < 4)
            {
                directionIndex = new Random().Next(Directions.Count);
                Direction = Directions[directionIndex];
                try
                {
                    if (Direction == "Up")
                    {
                        AddCell(Board.GetCellAt(Row, Column));
                        AddCell(Board.GetCellAt(Row + 1, Column));
                        AddCell(Board.GetCellAt(Row + 1, Column - 1));
                        AddCell(Board.GetCellAt(Row + 2, Column - 1));
                    }
                    else
                    {
                        AddCell(Board.GetCellAt(Row, Column));
                        AddCell(Board.GetCellAt(Row, Column + 1));
                        AddCell(Board.GetCellAt(Row + 1, Column + 1));
                        AddCell(Board.GetCellAt(Row + 1, Column + 2));
                    }
                }
                catch (Exception e)
                {
                    e.ToString();
                    ResetCells();
                }
                Directions.RemoveAt(directionIndex);
            }
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
            bool uniqueColor = false;
            Color newColor = new Color();
            Random rand = new Random();
            while (!uniqueColor)
            {
                System.Threading.Thread.Sleep(50);
                int max = (byte.MaxValue + 1),
                    min = max / 3;
                int r = rand.Next(min, max);
                int g = rand.Next(min, max);
                int b = rand.Next(min, max);
                newColor = Color.FromArgb(r, g, b);
                if (!UsedColors.Contains(newColor))
                    uniqueColor = true;
            }
            return newColor;
        }

        public override string ToString()
        {
            string strOut = Shape + "-" + Direction + "-" + Mode + "-" + Result.ToString() + "-";
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
