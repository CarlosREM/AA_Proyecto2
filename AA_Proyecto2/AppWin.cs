using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        private bool WatchRun = false;
        private System.Timers.Timer Watch;
        private BackgroundWorker TimerThread,
                                 UIThread;

        public AppWin()
        {
            InitializeComponent();

            /* TIMER STUFF
            Watch = new System.Timers.Timer();
            Watch.Interval = 10;
            Watch.Elapsed += Watch_Elapsed;

            TimerThread = new BackgroundWorker();
            TimerThread.WorkerReportsProgress = true;
            TimerThread.DoWork += RunStopwatch;
            TimerThread.ProgressChanged += UpdateWatchLabel;
            */

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
            Board.Location = new Point(180, 30);
            Board.Name = "Board";
        }

        //UI Usability
        private void btn_generate_Click(object sender, EventArgs e)
        {
            sldr_size.Enabled = false;
            btn_generate.Enabled = false;
            btn_solve.Enabled = true;
            btn_reset.Enabled = true;
            btn_save.Enabled = true;

            //TimerThread.RunWorkerAsync();
        }

        private void btn_solve_Click(object sender, EventArgs e)
        {

        }

        //Done
        private void btn_reset_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Perderá el sudoku generado/cargado actualmente. Desea continuar?",
                                  "Confirmacion - Limpiar Pantalla", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
            {
                Board.Dispose();
                int dimension = sldr_size.Value;
                UIThread.RunWorkerAsync(argument: dimension);
                Refresh();
                sldr_size.Enabled = true;
                btn_generate.Enabled = true;
                btn_solve.Enabled = false;
                btn_reset.Enabled = false;
                btn_save.Enabled = false;
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            string fileName = SudokuFileHandler.SaveSudoku(Board.ToString());
            MessageBox.Show("Guardado como \""+fileName+"\" en el directorio \"saves\" del proyecto",
                            "Guardar Killer Sudoku", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            bool load = true;
            if (btn_reset.Enabled)
            {
                load = false;
                DialogResult dr = MessageBox.Show("Perderá el sudoku generado/cargado actualmente. Desea continuar?",
                                                  "Confirmación - Cargar Sudoku", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                    load = true;
            }

            if (load)
            {
                try
                {
                    Board = SudokuFileHandler.LoadSudoku();
                    sldr_size.Enabled = false;
                    btn_generate.Enabled = false;
                    btn_solve.Enabled = true;
                    btn_reset.Enabled = true;
                    btn_save.Enabled = false;
                }
                catch(Exception exc)
                {
                    DialogResult dr = MessageBox.Show("Error al cargar Sudoku: "+exc.Message,
                                                      "Error - Cargar Sudoku", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

        /* TIMER STUFF
        private void RunStopwatch(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = sender as BackgroundWorker;
            Watch.Start();
            int ms = 0,
                oldms = 0;
            while(ms <= 1000)
            {
                ms = ((int) 
                bw.ReportProgress(ms);

                //Dispatcher.Invoke;
            }
        }

        private void UpdateWatchLabel(object sender, ProgressChangedEventArgs e)
        {
            TimeSpan t = TimeSpan.FromMilliseconds(e.ProgressPercentage);
            string elapsedTime = t.ToString("hh':'mm':'ss'.'ff");
            lbl_timer.Text = "Timer - " + elapsedTime;
        }


        private void UpdateWatchLabel(object sender, System.Timers.ElapsedEventArgs e)
        {
            e.SignalTime.
        }
        */
    }
}
