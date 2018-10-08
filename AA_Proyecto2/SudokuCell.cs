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
        private int Number { get; set; } = 0;
        private int Result { get; set; } = 0;
        private Label Lbl_Number;
        private Label Lbl_Result;

        public SudokuCell()
        {
            InitializeComponent();
            Lbl_Number = new Label();
            Lbl_Result = new Label();
            SuspendLayout();
            Controls.Add(Lbl_Number);
            Controls.Add(Lbl_Result);

            //Lbl_Number
            Lbl_Number.AutoSize = false;
            Lbl_Number.Font = new Font("Courier New", 16F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            Lbl_Number.Size = new Size(50, 40);
            Lbl_Number.Location = new Point(0, 5);
            Lbl_Number.TextAlign = ContentAlignment.BottomCenter;
            //Lbl_Number.Dock = DockStyle.Bottom;


            //Lbl_Result
            Lbl_Result.AutoSize = false;
            Lbl_Result.Font = new Font("Courier New", 8F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            Lbl_Result.Size = new Size(50, 15);
            Lbl_Result.Location = new Point(0, 0);
            Lbl_Result.BringToFront();

            ResumeLayout();
        }

        public void SetNumber(int pNumber)
        {
            Number = pNumber;
            Lbl_Number.Text = Number.ToString();
        }

        public void SetResult(int pResult)
        {
            Result = pResult;
            Lbl_Result.Text = Result.ToString();
        }
    }
}
