using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace AA_Proyecto2
{
    public class Tetromino
    {
        public enum Shape {O, I, J, L, S, T, Z};
        public enum Orientation {Left, Up, Right, Down};

        private int Result;
        private SudokuCell[] Cells;
        private int Length { get; set; } = 0;
        private Color color;

        public bool isFull() { return Length == 4; }
        
        public Tetromino(Sudoku Board, int Row, int Column)
        {
            Cells = new SudokuCell[4];
            color = PickColor();
            Random r = new Random();
            Result = r.Next(2);
            Shape newShape;
            while (Length < 4)
            {
                newShape = (Shape) r.Next(2);
                switch (newShape)
                {
                    case (Shape.O):
                        Arrange_O(Board, Row, Column);
                        break;

                    case (Shape.I):
                        Arrange_I(Board, Row, Column);
                        break;

                    case (Shape.J):
                        Arrange_J(Board, Row, Column); //WIP
                        break;

                    case (Shape.L):
                        Arrange_L(Board, Row, Column); //WIP
                        break;

                    case (Shape.S):
                        Arrange_S(Board, Row, Column); //WIP
                        break;

                    case (Shape.T):
                        Arrange_T(Board, Row, Column); //WIP
                        break;

                    case (Shape.Z):
                        Arrange_Z(Board, Row, Column); //WIP
                        break;
                }
            }
            AssignResult();
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
            Orientation o = (Orientation) new Random().Next(2);
            try
            {
                if (o == Orientation.Left)
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

        private void Arrange_J(Sudoku Board, int Row, int Column)
        {

        }

        private void Arrange_L(Sudoku Board, int Row, int Column)
        {

        }

        private void Arrange_S(Sudoku Board, int Row, int Column)
        {

        }

        private void Arrange_T(Sudoku Board, int Row, int Column)
        {

        }

        private void Arrange_Z(Sudoku Board, int Row, int Column)
        {

        }

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

        private void AssignResult()
        {
            if (Result == 0)
                foreach (SudokuCell Cell in Cells)
                    Result += Cell.Answer;
            else
                foreach (SudokuCell Cell in Cells)
                    Result *= Cell.Answer;
            Cells[0].SetResult(Result);
        }

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
    }
}
