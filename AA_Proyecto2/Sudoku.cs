using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AA_Proyecto2
{
    public partial class Sudoku : Panel
    {
        private SudokuCell[,] CellMatrix;
        private SudokuRegion[] Regions;
        private int Dimension;

        private const int CellSize = 35;
        private const int Spacer = 5;

        public Sudoku(int pDimension)
        {
            InitializeComponent();
            BackColor = System.Drawing.Color.Black;
            Dimension = pDimension;
            CellMatrix = new SudokuCell[Dimension, Dimension];
            Regions = new SudokuRegion[Dimension];
            for (int i = 0; i < Dimension; i++)
                Regions[i] = new SudokuRegion(Dimension);
            SuspendLayout();
            ArrangeSetup();
            ResumeLayout();
        }

        private void ArrangeSetup()
        {
            switch (Dimension)
            {
                case (5):
                    Arrange_5x5(); //WIP
                    break;
                case (6):
                    Arrange_6x6();
                    break;
                case (7):
                    Arrange_7x7(); //WIP
                    break;
                case (8):
                    Arrange_8x8();
                    break;
                case (9):
                    Arrange_9x9();
                    break;
                case (10):
                    Arrange_10x10();
                    break;
                case (11):
                    Arrange_11x11(); //WIP
                    break;
                case (12):
                    Arrange_12x12();
                    break;
                case (13):
                    Arrange_13x13(); //WIP
                    break;
                case (14):
                    Arrange_14x14();
                    break;
                case (15):
                    Arrange_15x15();
                    break;
                case (16):
                    Arrange_16x16();
                    break;
                case (17):
                    Arrange_17x17(); //WIP
                    break;
                case (18):
                    Arrange_18x18();
                    break;
                case (19):
                    Arrange_19x19(); //WIP
                    break;
            }
            /*
            for (int i = 0; i < Dimension; i++)
                Console.WriteLine(i + " " + Regions[i].ToString());
            //*/
        }

        private void Arrange_5x5()
        {
            Size = new Size(CellSize * Dimension + Spacer * 6, CellSize * Dimension + Spacer * 6);
        }

        private void Arrange_6x6()
        {
            int RegionSpacerV = Spacer,
                RegionSpacerH = Spacer;
            for (int i = 0; i < Dimension; i++)
            {
                if (i == 0)
                    RegionSpacerV = Spacer;
                else if (i % 2 == 0)
                    RegionSpacerV += Spacer;

                for (int j = 0; j < Dimension; j++)
                {
                    if (j == 0)
                        RegionSpacerH = Spacer;
                    else if (j % 3 == 0)
                        RegionSpacerH += Spacer;

                    CellMatrix[i, j] = new SudokuCell(i, j);
                    CellMatrix[i, j].SuspendLayout();
                    CellMatrix[i, j].Location = new Point(j * CellSize + RegionSpacerH, i * CellSize + RegionSpacerV);
                    CellMatrix[i, j].ResumeLayout();
                    CellMatrix[i, j].PerformLayout();
                    Controls.Add(CellMatrix[i, j]);
                    CellMatrix[i, j].SetNumber(i);
                    CellMatrix[i, j].SetResult(j);
                    //Regions[(RegionSpacerH / Spacer - 1) + 2*(RegionSpacerV / Spacer - 1)].AddCell(CellMatrix[i, j]);
                }
            }
            Size = new Size(CellSize * Dimension + Spacer*3, CellSize * Dimension + Spacer*4);
        }

        private void Arrange_7x7()
        {
            Size = new Size(CellSize * Dimension + Spacer * 8, CellSize * Dimension + Spacer * 8);
        }

        private void Arrange_8x8()
        {
            int RegionSpacerV = Spacer,
                RegionSpacerH = Spacer;
            for (int i = 0; i < Dimension; i++)
            {
                if (i == 0)
                    RegionSpacerV = Spacer;
                else if (i % 2 == 0)
                    RegionSpacerV += Spacer;

                for (int j = 0; j < Dimension; j++)
                {
                    if (j == 0)
                        RegionSpacerH = Spacer;
                    else if (j % 4 == 0)
                        RegionSpacerH += Spacer;

                    CellMatrix[i, j] = new SudokuCell(i, j);
                    CellMatrix[i, j].SuspendLayout();
                    CellMatrix[i, j].Location = new Point(j * CellSize + RegionSpacerH, i * CellSize + RegionSpacerV);
                    CellMatrix[i, j].ResumeLayout();
                    CellMatrix[i, j].PerformLayout();
                    Controls.Add(CellMatrix[i, j]);
                    CellMatrix[i, j].SetNumber(i);
                    CellMatrix[i, j].SetResult(j);
                    //Regions[(RegionSpacerH / Spacer - 1) + 2*(RegionSpacerV / Spacer - 1)].AddCell(CellMatrix[i, j]);
                }
            }
            Size = new Size(CellSize * Dimension + Spacer * 3, CellSize * Dimension + Spacer * 5);
        }

        private void Arrange_9x9()
        {
            int RegionSpacerV = Spacer,
                RegionSpacerH = Spacer;
            for (int i = 0; i < Dimension; i++)
            {
                if (i == 0)
                    RegionSpacerV = Spacer;
                else if (i % 3 == 0)
                    RegionSpacerV += Spacer;

                for (int j = 0; j < Dimension; j++)
                {
                    if (j == 0)
                        RegionSpacerH = Spacer;
                    else if (j % 3 == 0)
                        RegionSpacerH += Spacer;

                    CellMatrix[i, j] = new SudokuCell(i, j);
                    CellMatrix[i, j].SuspendLayout();
                    CellMatrix[i, j].Location = new Point(j * CellSize + RegionSpacerH, i * CellSize + RegionSpacerV);
                    CellMatrix[i, j].ResumeLayout();
                    CellMatrix[i, j].PerformLayout();
                    Controls.Add(CellMatrix[i, j]);
                    CellMatrix[i, j].SetNumber(i);
                    CellMatrix[i, j].SetResult(j);
                    //Regions[(RegionSpacerH / Spacer - 1) + 3*(RegionSpacerV / Spacer - 1)].AddCell(CellMatrix[i, j]);
;                }
            }
            Size = new Size(CellSize * Dimension + Spacer*4, CellSize * Dimension + Spacer*4);
        }

        private void Arrange_10x10()
        {
            int RegionSpacerV = Spacer,
                RegionSpacerH = Spacer;
            for (int i = 0; i < Dimension; i++)
            {
                if (i == 0)
                    RegionSpacerV = Spacer;
                else if (i % 2 == 0)
                    RegionSpacerV += Spacer;

                for (int j = 0; j < Dimension; j++)
                {
                    if (j == 0)
                        RegionSpacerH = Spacer;
                    else if (j % 5 == 0)
                        RegionSpacerH += Spacer;

                    CellMatrix[i, j] = new SudokuCell(i, j);
                    CellMatrix[i, j].SuspendLayout();
                    CellMatrix[i, j].Location = new Point(j * CellSize + RegionSpacerH, i * CellSize + RegionSpacerV);
                    CellMatrix[i, j].ResumeLayout();
                    CellMatrix[i, j].PerformLayout();
                    Controls.Add(CellMatrix[i, j]);
                    CellMatrix[i, j].SetNumber(i);
                    CellMatrix[i, j].SetResult(j);
                    //Regions[(RegionSpacerH / Spacer - 1) + 2*(RegionSpacerV / Spacer - 1)].AddCell(CellMatrix[i, j]);
                }
            }
            Size = new Size(CellSize * Dimension + Spacer * 3, CellSize * Dimension + Spacer * 6);
        }

        private void Arrange_11x11()
        {
            Size = new Size(CellSize * Dimension + Spacer * 12, CellSize * Dimension + Spacer * 12);
        }

        private void Arrange_12x12()
        {
            int RegionSpacerV = Spacer,
                RegionSpacerH = Spacer;
            for (int i = 0; i < Dimension; i++)
            {
                if (i == 0)
                    RegionSpacerV = Spacer;
                else if (i % 3 == 0)
                    RegionSpacerV += Spacer;

                for (int j = 0; j < Dimension; j++)
                {
                    if (j == 0)
                        RegionSpacerH = Spacer;
                    else if (j % 4 == 0)
                        RegionSpacerH += Spacer;

                    CellMatrix[i, j] = new SudokuCell(i, j);
                    CellMatrix[i, j].SuspendLayout();
                    CellMatrix[i, j].Location = new Point(j * CellSize + RegionSpacerH, i * CellSize + RegionSpacerV);
                    CellMatrix[i, j].ResumeLayout();
                    CellMatrix[i, j].PerformLayout();
                    Controls.Add(CellMatrix[i, j]);
                    CellMatrix[i, j].SetNumber(i);
                    CellMatrix[i, j].SetResult(j);
                    //Regions[(RegionSpacerH / Spacer - 1) + 3*(RegionSpacerV / Spacer - 1)].AddCell(CellMatrix[i, j]);
                }
            }
            Size = new Size(CellSize * Dimension + Spacer * 4, CellSize * Dimension + Spacer * 5);
        }

        private void Arrange_13x13()
        {
            Size = new Size(CellSize * Dimension + Spacer * 10, CellSize * Dimension + Spacer * 10);
        }

        private void Arrange_14x14()
        {
            int RegionSpacerV = Spacer,
                RegionSpacerH = Spacer;
            for (int i = 0; i < Dimension; i++)
            {
                if (i == 0)
                    RegionSpacerV = Spacer;
                else if (i % 2 == 0)
                    RegionSpacerV += Spacer;

                for (int j = 0; j < Dimension; j++)
                {
                    if (j == 0)
                        RegionSpacerH = Spacer;
                    else if (j % 7 == 0)
                        RegionSpacerH += Spacer;

                    CellMatrix[i, j] = new SudokuCell(i, j);
                    CellMatrix[i, j].SuspendLayout();
                    CellMatrix[i, j].Location = new Point(j * CellSize + RegionSpacerH, i * CellSize + RegionSpacerV);
                    CellMatrix[i, j].ResumeLayout();
                    CellMatrix[i, j].PerformLayout();
                    Controls.Add(CellMatrix[i, j]);
                    CellMatrix[i, j].SetNumber(i);
                    CellMatrix[i, j].SetResult(j);
                    //Regions[(RegionSpacerH / Spacer - 1) + 2*(RegionSpacerV / Spacer - 1)].AddCell(CellMatrix[i, j]);
                }
            }
            Size = new Size(CellSize * Dimension + Spacer * 3, CellSize * Dimension + Spacer * 8);
        }

        private void Arrange_15x15()
        {
            int RegionSpacerV = Spacer,
                RegionSpacerH = Spacer;
            for (int i = 0; i < Dimension; i++)
            {
                if (i == 0)
                    RegionSpacerV = Spacer;
                else if (i % 3 == 0)
                    RegionSpacerV += Spacer;

                for (int j = 0; j < Dimension; j++)
                {
                    if (j == 0)
                        RegionSpacerH = Spacer;
                    else if (j % 5 == 0)
                        RegionSpacerH += Spacer;

                    CellMatrix[i, j] = new SudokuCell(i, j);
                    CellMatrix[i, j].SuspendLayout();
                    CellMatrix[i, j].Location = new Point(j * CellSize + RegionSpacerH, i * CellSize + RegionSpacerV);
                    CellMatrix[i, j].ResumeLayout();
                    CellMatrix[i, j].PerformLayout();
                    Controls.Add(CellMatrix[i, j]);
                    CellMatrix[i, j].SetNumber(i);
                    CellMatrix[i, j].SetResult(j);
                    //Regions[(RegionSpacerH / Spacer - 1) + 3*(RegionSpacerV / Spacer - 1)].AddCell(CellMatrix[i, j]);
                }
            }
            Size = new Size(CellSize * Dimension + Spacer * 4, CellSize * Dimension + Spacer * 6);
        }

        private void Arrange_16x16()
        {
            int RegionSpacerV = Spacer,
                RegionSpacerH = Spacer;
            for (int i = 0; i < Dimension; i++)
            {
                if (i == 0)
                    RegionSpacerV = Spacer;
                else if (i % 4 == 0)
                    RegionSpacerV += Spacer;

                for (int j = 0; j < Dimension; j++)
                {
                    if (j == 0)
                        RegionSpacerH = Spacer;
                    else if (j % 4 == 0)
                        RegionSpacerH += Spacer;

                    CellMatrix[i, j] = new SudokuCell(i, j);
                    CellMatrix[i, j].SuspendLayout();
                    CellMatrix[i, j].Location = new Point(j * CellSize + RegionSpacerH, i * CellSize + RegionSpacerV);
                    CellMatrix[i, j].ResumeLayout();
                    CellMatrix[i, j].PerformLayout();
                    Controls.Add(CellMatrix[i, j]);
                    CellMatrix[i, j].SetNumber(i);
                    CellMatrix[i, j].SetResult(j);
                    //Regions[(RegionSpacerH / Spacer - 1) + 4*(RegionSpacerV / Spacer - 1)].AddCell(CellMatrix[i, j]);
                }
            }
            Size = new Size(CellSize * Dimension + Spacer * 5, CellSize * Dimension + Spacer * 5);
        }

        private void Arrange_17x17()
        {
            Size = new Size(CellSize * Dimension + Spacer * 18, CellSize * Dimension + Spacer * 18);
        }

        private void Arrange_18x18()
        {
            int RegionSpacerV = Spacer,
                RegionSpacerH = Spacer;
            for (int i = 0; i < Dimension; i++)
            {
                if (i == 0)
                    RegionSpacerV = Spacer;
                else if (i % 3 == 0)
                    RegionSpacerV += Spacer;

                for (int j = 0; j < Dimension; j++)
                {
                    if (j == 0)
                        RegionSpacerH = Spacer;
                    else if (j % 6 == 0)
                        RegionSpacerH += Spacer;

                    CellMatrix[i, j] = new SudokuCell(i, j);
                    CellMatrix[i, j].SuspendLayout();
                    CellMatrix[i, j].Location = new Point(j * CellSize + RegionSpacerH, i * CellSize + RegionSpacerV);
                    CellMatrix[i, j].ResumeLayout();
                    CellMatrix[i, j].PerformLayout();
                    Controls.Add(CellMatrix[i, j]);
                    CellMatrix[i, j].SetNumber(i);
                    CellMatrix[i, j].SetResult(j);
                    //Regions[(RegionSpacerH / Spacer - 1) + 3*(RegionSpacerV / Spacer - 1)].AddCell(CellMatrix[i, j]);
                }
            }
            Size = new Size(CellSize * Dimension + Spacer * 4, CellSize * Dimension + Spacer * 7);
        }

        private void Arrange_19x19()
        {
            Size = new Size(CellSize * Dimension + Spacer * 16, CellSize * Dimension + Spacer * 18);
        }

        public bool CheckRow(int Row, int Number)
        {
            bool result = false;
            SudokuCell Cell;
            for (int Column = 0; Column < Dimension; Column++)
            {
                Cell = CellMatrix[Row, Column];
                if (Cell.GetNumber() == Number)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        public bool CheckColumn(int Column, int Number)
        {
            bool result = false;
            SudokuCell Cell;
            for (int Row = 0; Row < Dimension; Row++)
            {
                Cell = CellMatrix[Row, Column];
                if (Cell.GetNumber() == Number)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
    }
}
