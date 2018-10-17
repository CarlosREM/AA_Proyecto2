using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace AA_Proyecto2
{
    public partial class AppWin : Form
    {
        private Sudoku Board { get; set; }
        private BackgroundWorker UIThread;

        public AppWin()
        {
            InitializeComponent();
            UIThread = new BackgroundWorker();
            UIThread.WorkerSupportsCancellation = true;
            UIThread.DoWork += Th_InitializeBoard;
            UIThread.RunWorkerCompleted += Th_AddBoard;
            InitializeBoard(9);
            Controls.Add(Board);
        }

        private void Th_InitializeBoard(object sender, DoWorkEventArgs e)
        {
            //Thread.Sleep(100);
            int dimension = (int) e.Argument;
            InitializeBoard(dimension);
        }

        private void Th_AddBoard(object sender, RunWorkerCompletedEventArgs e)
        {
            Controls.Add(Board);
            sldr_size.Enabled = true;
            btn_generate.Enabled = true;
        }

        private void InitializeBoard(int Dimension)
        {
            Board = new Sudoku(Dimension);
            Board.Location = new Point(180, 20);
            Board.Name = "Board";
        }

        //UI Usability
        private void btn_generate_Click(object sender, EventArgs e)
        {
            sldr_size.Enabled = false;
            btn_generate.Enabled = false;
            btn_solve.Enabled = true;
            btn_clear.Enabled = true;
            btn_save.Enabled = true;
        }

        private void btn_solve_Click(object sender, EventArgs e)
        {

        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            int dimension = sldr_size.Value;
            //generate new sudoku
            sldr_size.Enabled = true;
            btn_generate.Enabled = true;
            btn_solve.Enabled = false;
            btn_clear.Enabled = false;
            btn_save.Enabled = false;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {

        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            bool load = true;
            if (btn_clear.Enabled)
            {
                load = false;
                DialogResult dr = MessageBox.Show("Podría perder el sudoku generado/cargado previamente. Desea continuar?",
                                                  "Confirmacion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                    load = true;
            }

            if (load)
            {
                //load sudoku
                sldr_size.Enabled = false;
                btn_generate.Enabled = false;
                btn_solve.Enabled = true;
                btn_clear.Enabled = true;
                btn_save.Enabled = false;
            }
        }

        private void sldr_size_ValueChanged(object sender, EventArgs e)
        {
            if (!UIThread.IsBusy)
            {
                sldr_size.Enabled = false;
                btn_generate.Enabled = false;
                lbl_sizeNum.Text = sldr_size.Value.ToString();
                Board.Dispose();
                int dimension = sldr_size.Value;
                UIThread.RunWorkerAsync(argument: dimension);
                Refresh();
            }
            else
                UIThread.CancelAsync();
        }

        private void sldr_thread_ValueChanged(object sender, EventArgs e)
        {
            lbl_threadNum.Text = sldr_thread.Value.ToString();
        }

        private void btn_useThreads_CheckedChanged(object sender, EventArgs e)
        {
            if (btn_useThreads.Checked)
                lbl_threadNum.Text = sldr_thread.Value.ToString();
            else
                lbl_threadNum.Text = "";
            sldr_thread.Enabled = btn_useThreads.Checked;
            lbl_threadNum.Enabled = btn_useThreads.Checked;
        }

        private void btn_about_Click(object sender, EventArgs e)
        {
            String info = "IC-3002 - Análisis de Algoritmos, GR 1\n" +
                          "Profesor: José Carranza Rojas\n" +
                          "\n" +
                          "Proyecto 2: Killer Sudoku\n" +
                          "Elaborado por:\n" +
                          "  >  2017146886 = Carlos Roberto Esquivel Morales\n" +
                          "  >  2017100950 = José Fabio Hidalgo Rodríguez\n" +
                          "\n" +
                          "Semestre 2, 2018";
            MessageBox.Show(info, "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
