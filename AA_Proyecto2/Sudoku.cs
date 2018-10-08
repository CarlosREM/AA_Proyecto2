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
        private int Dimension { get; set; }

        public Sudoku(int pDimension = 9)
        {
            InitializeComponent();
            BackColor = System.Drawing.Color.Black;
            Dimension = pDimension;
            CellMatrix = new SudokuCell[Dimension, Dimension];
            const int CellSize = 50,
                      Spacer = 5;
            SuspendLayout();
            Size = new Size(CellSize * Dimension + Spacer*4, CellSize * Dimension + Spacer*4);

            int RegionSpacerV = Spacer,
                RegionSpacerH = Spacer;
            for  (int i = 0; i < Dimension; i++)
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

                    CellMatrix[i, j] = new SudokuCell();
                    CellMatrix[i, j].SuspendLayout();
                    CellMatrix[i, j].Location = new Point(j * CellSize + RegionSpacerH, i * CellSize + RegionSpacerV);
                    CellMatrix[i, j].ResumeLayout();
                    CellMatrix[i, j].PerformLayout();
                    Controls.Add(CellMatrix[i, j]);
                    CellMatrix[i, j].SetNumber(i);
                    CellMatrix[i, j].SetResult(j*100);
                }
            }
            ResumeLayout();
        }
    }
}
