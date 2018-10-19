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
        private const int CellSize = 35;
        private const int Spacer = 5;

        private int Dimension;
        private SudokuCell[,] CellGrid;
        public SudokuRegion[] Regions;
        public List<Tetromino> Tetrominos;

        public SudokuCell GetCellAt(int Row, int Column) { return CellGrid[Row, Column]; }
        public void SetCellAt(int Row, int Column, int Number) { CellGrid[Row, Column].SetNumber(Number); }

        public Sudoku(int pDimension)
        {
            InitializeComponent();
            Dimension = pDimension;
            CellGrid = new SudokuCell[Dimension, Dimension];
            Regions = new SudokuRegion[Dimension];
            Tetrominos = new List<Tetromino>();
            for (int i = 0; i < Dimension; i++)
                Regions[i] = new SudokuRegion(Dimension);
            SuspendLayout();
            ArrangeSetup();
            ResumeLayout();
        }

        private void RegionTest()
        {
            foreach (SudokuRegion r in Regions)
                r.test();
        }
        private void ArrangeSetup()
        {
            switch (Dimension)
            {
                case (5):
                    Arrange_5x5();
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
            //RegionTest();

            //Region Console test
            /*
            for (int i = 0; i < Dimension; i++)
                Console.WriteLine(i + " " + Regions[i].ToString());
            
            //*///Tetromino test
            /*
            if (CellGrid[0, 0] != null) {
                Tetromino t = new Tetromino(this, 0, 0);
                Tetrominos.Add(t);
            }
            //*/
        }

		private void Arrange_5x5()
		{
			int RegionSpacerV = Spacer,
				RegionSpacerH = Spacer,
				SelectedRegion = 0;
			for (int i = 0; i < Dimension; i++)
			{
                SelectedRegion = 0;
                if (i >= 2)
                    SelectedRegion = 3;

				for (int j = 0; j < Dimension; j++)
				{
					if (j == 0)
						RegionSpacerH = Spacer;
					switch(i)
					{
						case 0:
                            if (j == 3) {
                                RegionSpacerH += Spacer * 2;
                                SelectedRegion = 1;
                            }
							AddCell(i, j, RegionSpacerH, RegionSpacerV);
							break;

						case 1:
                            if (j == 2 || j == 3) {
                                RegionSpacerH += Spacer;
                                SelectedRegion = j;
                                if (j == 3)
                                    SelectedRegion -= 2;
                            }
							if (j == 2)
								AddCell(i, j, RegionSpacerH, RegionSpacerV + Spacer);
							else
								AddCell(i, j, RegionSpacerH, RegionSpacerV);
							break;

						case 2:
                            if (j == 1 || j == 4) {
                                RegionSpacerH += Spacer;
                                SelectedRegion--;
                            }
							if (j == 0)
								AddCell(i, j, RegionSpacerH, RegionSpacerV + Spacer*2);

							else if (j == 4)
								AddCell(i, j, RegionSpacerH, RegionSpacerV);

							else
								AddCell(i, j, RegionSpacerH, RegionSpacerV + Spacer);
							break;

						case 3:
                            if (j == 2 || j == 3) {
                                RegionSpacerH += Spacer;
                                SelectedRegion = j;
                                if (j == 3)
                                    SelectedRegion++;
                            }

							if (j == 2)
								AddCell(i, j, RegionSpacerH, RegionSpacerV + Spacer);
							else
								AddCell(i, j, RegionSpacerH, RegionSpacerV + Spacer*2);
							break;

						case 4:
                            if (j == 2) {
                                RegionSpacerH += Spacer * 2;
                                SelectedRegion++;
                            }
							AddCell(i, j, RegionSpacerH, RegionSpacerV + Spacer*2);
							break;
					}
                    Regions[SelectedRegion].AddCell(CellGrid[i, j]);
                }
            }
			Size = new Size(CellSize * Dimension + Spacer * 4, CellSize * Dimension + Spacer * 4);
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

                    AddCell(i, j, RegionSpacerH, RegionSpacerV);
                    Regions[(RegionSpacerH / Spacer - 1) + 2*(RegionSpacerV / Spacer - 1)].AddCell(CellGrid[i, j]);
                }
            }
            Size = new Size(CellSize * Dimension + Spacer*3, CellSize * Dimension + Spacer*4);
        }

        private void Arrange_7x7()
        {
            for (int i = 0; i < Dimension; i++)
            {
                for (int j = 0; j < Dimension; j++)
                    AddCell(i, j, Spacer, Spacer);
            }
            Size = new Size(CellSize * Dimension + Spacer * 2, CellSize * Dimension + Spacer * 2);
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

                    AddCell(i, j, RegionSpacerH, RegionSpacerV);
                    Regions[(RegionSpacerH / Spacer - 1) + 2*(RegionSpacerV / Spacer - 1)].AddCell(CellGrid[i, j]);
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

                    AddCell(i, j, RegionSpacerH, RegionSpacerV);
                    Regions[(RegionSpacerH / Spacer - 1) + 3*(RegionSpacerV / Spacer - 1)].AddCell(CellGrid[i, j]);
                }
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

                    AddCell(i, j, RegionSpacerH, RegionSpacerV);
                    Regions[(RegionSpacerH / Spacer - 1) + 2*(RegionSpacerV / Spacer - 1)].AddCell(CellGrid[i, j]);
                }
            }
            Size = new Size(CellSize * Dimension + Spacer * 3, CellSize * Dimension + Spacer * 6);
        }

        private void Arrange_11x11()
        {
            for (int i = 0; i < Dimension; i++)
            {
                for (int j = 0; j < Dimension; j++)
                    AddCell(i, j, Spacer, Spacer);
            }
            Size = new Size(CellSize * Dimension + Spacer * 2, CellSize * Dimension + Spacer * 2);
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

                    AddCell(i, j, RegionSpacerH, RegionSpacerV);
                    Regions[(RegionSpacerH / Spacer - 1) + 3*(RegionSpacerV / Spacer - 1)].AddCell(CellGrid[i, j]);
                }
            }
            Size = new Size(CellSize * Dimension + Spacer * 4, CellSize * Dimension + Spacer * 5);
        }

        private void Arrange_13x13()
        {
            for (int i = 0; i < Dimension; i++)
            {
                for (int j = 0; j < Dimension; j++)
                    AddCell(i, j, Spacer, Spacer);
            }
            Size = new Size(CellSize * Dimension + Spacer * 2, CellSize * Dimension + Spacer * 2);
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

                    AddCell(i, j, RegionSpacerH, RegionSpacerV);
                    Regions[(RegionSpacerH / Spacer - 1) + 2*(RegionSpacerV / Spacer - 1)].AddCell(CellGrid[i, j]);
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

                    AddCell(i, j, RegionSpacerH, RegionSpacerV);
                    Regions[(RegionSpacerH / Spacer - 1) + 3*(RegionSpacerV / Spacer - 1)].AddCell(CellGrid[i, j]);
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

                    AddCell(i, j, RegionSpacerH, RegionSpacerV);
                    Regions[(RegionSpacerH / Spacer - 1) + 4*(RegionSpacerV / Spacer - 1)].AddCell(CellGrid[i, j]);
                }
            }
            Size = new Size(CellSize * Dimension + Spacer * 5, CellSize * Dimension + Spacer * 5);
        }

        private void Arrange_17x17()
        {
            for (int i = 0; i < Dimension; i++)
            {
                for (int j = 0; j < Dimension; j++)
                    AddCell(i, j, Spacer, Spacer);
            }
            Size = new Size(CellSize * Dimension + Spacer * 2, CellSize * Dimension + Spacer * 2);
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

                    AddCell(i, j, RegionSpacerH, RegionSpacerV);
                    Regions[(RegionSpacerH / Spacer - 1) + 3*(RegionSpacerV / Spacer - 1)].AddCell(CellGrid[i, j]);
                }
            }
            Size = new Size(CellSize * Dimension + Spacer * 4, CellSize * Dimension + Spacer * 7);
        }

        private void Arrange_19x19()
        {
            for (int i = 0; i < Dimension; i++)
            {
                for (int j = 0; j < Dimension; j++)
                    AddCell(i, j, Spacer, Spacer);
            }
            Size = new Size(CellSize * Dimension + Spacer * 2, CellSize * Dimension + Spacer * 2);
        }

        private void AddCell(int Row, int Column, int RegionSpacerH, int RegionSpacerV)
        {
            CellGrid[Row, Column] = new SudokuCell(Row, Column);
            CellGrid[Row, Column].SuspendLayout();
            CellGrid[Row, Column].Location = new Point(Column * CellSize + RegionSpacerH, Row * CellSize + RegionSpacerV);
            CellGrid[Row, Column].ResumeLayout();
            CellGrid[Row, Column].PerformLayout();
            Controls.Add(CellGrid[Row, Column]);
        }

        public bool CheckRow(int Row, int Number)
        {
            bool result = false;
            SudokuCell Cell;
            for (int Column = 0; Column < Dimension; Column++)
            {
                Cell = CellGrid[Row, Column];
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
                Cell = CellGrid[Row, Column];
                if (Cell.GetNumber() == Number)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        override public string ToString()
        {
            string strOut = Dimension.ToString() + "\n-\n";

            for (int i = 0; i < Dimension; i++)
            {
                for (int j = 0; j < Dimension; j++)
                {
                    strOut += CellGrid[i, j].GetNumber().ToString();
                    if (j < Dimension - 1)
                        strOut += ",";
                }
                strOut += "\n";
            }
            strOut += "-\n";
            foreach (Tetromino t in Tetrominos)
                strOut += t.ToString() + "\n";
            strOut = strOut.TrimEnd('\n');
            return strOut;
        }
    }
}
