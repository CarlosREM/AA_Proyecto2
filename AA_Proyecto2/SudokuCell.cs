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
        public bool Locked = false;

        /// <summary>
        /// Number on the center of the Cell
        /// </summary>
        private int Number { get; set; } = 0;

        /// <summary>
        /// Number on the corner of the Cell
        /// </summary>
        private int Result { get; set; } = 0;

        public int Row { get; set; }
        public int Column { get; set; }

        public SudokuRegion sRegion = null;
        public Tetromino sTetro = null;

        private Label Lbl_Number;
        private Label Lbl_Result;

        public int GetNumber() { return Number; }
        public void SetNumber(int pNumber)
        {
			Number = pNumber;
            if (Lbl_Number.InvokeRequired)
                Lbl_Number.Invoke((MethodInvoker)(() =>
                {
                    Lbl_Number.Text = Number.ToString();
                    Lbl_Number.Visible = (Number > 0);
                }));
            else
            {
                Lbl_Number.Text = Number.ToString();
                Lbl_Number.Visible = (Number > 0);
            }
		}

        public int GetResult() { return Result; }
        public void SetResult(int pResult, string pMode)
        {
            Result = pResult;
            if (Lbl_Result.InvokeRequired)
                Lbl_Result.Invoke((MethodInvoker)(() =>
                {
                    Lbl_Result.Text = pMode + Result.ToString();
                    Lbl_Result.Visible = true;
                }));
            else
            {
                Lbl_Result.Text = pMode + Result.ToString();
                Lbl_Result.Visible = true;
            }
        }

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="pRow"></param>
        /// <param name="pColumn"></param>
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
            Lbl_Number.Font = new Font("Courier New", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Lbl_Number.Size = new Size(40, 30);
            Lbl_Number.Location = new Point(0, 5);
            Lbl_Number.TextAlign = ContentAlignment.BottomCenter;

            //Lbl_Result
            Lbl_Result.AutoSize = false;
            Lbl_Result.Font = new Font("Courier New", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Lbl_Result.Size = new Size(50, 15);
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
