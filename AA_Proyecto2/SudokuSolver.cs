using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AA_Proyecto2
{
    public class SudokuSolver
    {
        public static Sudoku Board { get; set; } = null;
        public static bool Stop = false;

        public void SolveSudoku(Sudoku pBoard)
        {
            Board = pBoard;
            Th_SolveSudoku();
            Board = null;
        }

        private bool Th_SolveSudoku()
        {
            bool progress = false,
                NoZero = true;
            int row = -1,
                col = -1;
            for (int i = 0; i < Board.Dimension && NoZero && !Stop; i++)
            {
                for (int j = 0; j < Board.Dimension && NoZero && !Stop; j++)
                {
                    if (Board.GetCellAt(i, j).GetNumber() == 0)
                    {
                        row = i;
                        col = j;
                        NoZero = false;
                    }
                }
            }
            if (NoZero || Stop)
                progress = true;
            else
            {
                for (int num = 1; num <= Board.Dimension && !progress && !Stop; num++)
                {
                    if (Board.CheckValue(num, row, col))
                    {
                        Board.SetCellAt(row, col, num);
                        System.Threading.Thread.Sleep(50);
                        if (Th_SolveSudoku())
                            progress = true;
                        else
                            Board.SetCellAt(row, col, 0);
                    }
                }
            }
            return progress;
        }

        private void SolveTetro(Tetromino Tetro)
        {

        }
    }
}
