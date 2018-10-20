using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace AA_Proyecto2
{
    public class Tetromino
    {
        public enum TetroShape {O, I, J, L, S, T, Z, Dot};
        public enum Orientation {Left, Up, Right, Down};

        private int Result;
        private TetroShape Shape;
        private Orientation Direction;
        private string Mode = "";
        private SudokuCell[] Cells;
        private int Length { get; set; } = 0;
        private readonly Color color;
        
        public string GetShape()
        {
            string strOut =  "";
            switch(Shape)
            {
                case (TetroShape.O):
                    strOut = "O";
                    break;
                case (TetroShape.I):
                    strOut = "I";
                    break;
                case (TetroShape.J):
                    strOut = "J";
                    break;
                case (TetroShape.L):
                    strOut = "L";
                    break;
                case (TetroShape.S):
                    strOut = "S";
                    break;
                case (TetroShape.T):
                    strOut = "T";
                    break;
                case (TetroShape.Z):
                    strOut = "Z";
                    break;
                case (TetroShape.Dot):
                    strOut = "D";
                    break;
            }
            return strOut;
        }
        public void SetShape(string strShape)
        {
            switch(strShape)
            {
                case ("O"):
                    Shape = TetroShape.O;
                    break;
                case ("I"):
                    Shape = TetroShape.I;
                    break;
                case ("J"):
                    Shape = TetroShape.J;
                    break;
                case ("L"):
                    Shape = TetroShape.L;
                    break;
                case ("S"):
                    Shape = TetroShape.S;
                    break;
                case ("T"):
                    Shape = TetroShape.T;
                    break;
                case ("Z"):
                    Shape = TetroShape.Z;
                    break;
                case ("D"):
                    Shape = TetroShape.Dot;
                    break;
            }
        }

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
            color = PickColor();
            Random r = new Random();
            Result = r.Next(2);
            List<TetroShape> ShapeTries = new List<TetroShape>(); 
            while (Length < 4)
            {
                if (ShapeTries.Count < 7)
                {
                    Shape = (TetroShape)r.Next(2);//(7);
                    switch (Shape)
                    {
                        case (TetroShape.O):
                            Arrange_O(Board, Row, Column);
                            break;

                        case (TetroShape.I):
                            Arrange_I(Board, Row, Column);
                            break;

                        case (TetroShape.J):
                            Arrange_J(Board, Row, Column); //WIP
                            break;

                        case (TetroShape.L):
                            Arrange_L(Board, Row, Column); //WIP
                            break;

                        case (TetroShape.S):
                            Arrange_S(Board, Row, Column); //WIP
                            break;

                        case (TetroShape.T):
                            Arrange_T(Board, Row, Column); //WIP
                            break;

                        case (TetroShape.Z):
                            Arrange_Z(Board, Row, Column); //WIP
                            break;
                    }
                    ShapeTries.Add(Shape);
                }
                else {
                    Shape = TetroShape.Dot;
                    Cells = new SudokuCell[1];
                    Length = 1;
                    AddCell(Board.GetCellAt(Row, Column));
                    break;
                }
            }
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
            color = PickColor();
            string[] infoTokens = strInfo.Split('-');
            SetShape(infoTokens[0]);
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

        private void Arrange_O(Sudoku Board, int Row, int Column)
        {
            try
            {
                AddCell(Board.GetCellAt(Row, Column));
                AddCell(Board.GetCellAt(Row, Column+1));
                AddCell(Board.GetCellAt(Row+1, Column));
                AddCell(Board.GetCellAt(Row+1, Column+1));
            }
            catch (Exception e)
            {
                Cells = new SudokuCell[4];
                Length = 0;
            }
        }

        private void Arrange_I(Sudoku Board, int Row, int Column)
        {
            Direction = (Orientation) new Random().Next(2);
            try
            {
                if (Direction == Orientation.Left)
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
                Cells = new SudokuCell[4];
                Length = 0;
            }
        }

        private void Arrange_J(Sudoku Board, int Row, int Column) //WIP
        {

        }

        private void Arrange_L(Sudoku Board, int Row, int Column) //WIP
        {

        }

        private void Arrange_S(Sudoku Board, int Row, int Column) //WIP
        {

        }

        private void Arrange_T(Sudoku Board, int Row, int Column) //WIP
        {

        }

        private void Arrange_Z(Sudoku Board, int Row, int Column) //WIP
        {

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
                NewCell.BackColor = color;
                Length++;
            }
            else
                throw new Exception();
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
            string strOut = GetShape() + "-" + GetDirection() + "-" + Mode + "-" + Result.ToString() + "-";
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
