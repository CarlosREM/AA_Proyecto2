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
    public partial class SudokuCell : Panel
    {
        public int Answer = 0;
        private int Number { get; set; } = 0;
        private int Result { get; set; } = 0;

        private int Row { get; set; }
        private int Column { get; set; }

        public SudokuRegion sRegion = null;
        public Tetromino sTetro = null;

        private Label Lbl_Number;
        private Label Lbl_Result;

        public int GetNumber() { return Number; }
        public void SetNumber(int pNumber)
        {
            Number = pNumber;
            Lbl_Number.Text = Number.ToString();
        }

        public int GetResult() { return Result; }
        public void SetResult(int pResult)
        {
            Result = pResult;
            Lbl_Result.Text = Result.ToString();
            Lbl_Result.Visible = true;
        }

        public SudokuCell(int pRow, int pColumn)
        {
            Row = pRow;
            Column = pColumn;
            InitializeComponent();
            Lbl_Number = new Label();
            Lbl_Result = new Label();
            SuspendLayout();
            Controls.Add(Lbl_Number);
            Controls.Add(Lbl_Result);

            //Lbl_Number
            Lbl_Number.AutoSize = false;
            Lbl_Number.Font = new Font("Courier New", 14F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            Lbl_Number.Size = new Size(35, 30);
            Lbl_Number.Location = new Point(0, 5);
            Lbl_Number.TextAlign = ContentAlignment.BottomCenter;

            //Lbl_Result
            Lbl_Result.AutoSize = false;
            Lbl_Result.Font = new Font("Courier New", 8F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            Lbl_Result.Size = new Size(35, 15);
            Lbl_Result.Location = new Point(0, 0);
            Lbl_Result.BringToFront();
            Lbl_Result.Visible = false;

            ResumeLayout();
        }

        override public string  ToString()
        {
            string strOut = "[" + Row.ToString() + ", " + Column.ToString() + "] - N: " + Number.ToString() + " - R: " + Result.ToString();
            return strOut;
        }
    }
}
