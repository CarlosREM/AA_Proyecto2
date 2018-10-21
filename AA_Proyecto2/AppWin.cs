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
        private BackgroundWorker UIThread;

        private Stopwatch Watch;
        private BackgroundWorker TimerThread;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public AppWin()
        {
            InitializeComponent();

            TimerThread = new BackgroundWorker { WorkerReportsProgress = true };
            TimerThread.DoWork += Start_Watch;
            TimerThread.ProgressChanged += UpdateWatchLabel;
            

            UIThread = new BackgroundWorker() { WorkerSupportsCancellation = true };
            UIThread.DoWork += Th_InitializeBoard;
            UIThread.RunWorkerCompleted += Th_AddBoard;

            InitializeBoard(9);
            Controls.Add(Board);
        }

        /// <summary>
        /// Initializes Sudoku Board on executing UIThread.RunWorkerAsync, accepts the dimension as argument on 'e'
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Th_InitializeBoard(object sender, DoWorkEventArgs e)
        {
            int dimension = (int) e.Argument;
            InitializeBoard(dimension);
        }

        /// <summary>
        /// Adds the Sudoku Board to the UI, then reenables the controls disabled on dimension-changing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Th_AddBoard(object sender, RunWorkerCompletedEventArgs e)
        {
            Controls.Add(Board);
            sldr_size.Enabled = true;
            btn_generate.Enabled = true;
        }

        /// <summary>
        /// Constructs and places the Sudoku Board based on the 'dimension' parameter
        /// </summary>
        /// <param name="Dimension"></param>
        private void InitializeBoard(int Dimension)
        {
            Board = new Sudoku(Dimension);
            Board.Location = new Point(180, 30);
            Board.Name = "Board";
        }

        /// <summary>
        /// Disables user control, then generates the Numbers and tetrominos on the Sudoku Board
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_generate_Click(object s, EventArgs ev)
        {
            sldr_size.Enabled = false;
            btn_generate.Enabled = false;
            btn_solve.Enabled = true;
            btn_reset.Enabled = true;
            btn_save.Enabled = true;

            UIThread = new BackgroundWorker() { WorkerSupportsCancellation = true };
            UIThread.DoWork += (sender, e) => Board.AddTetros();
            UIThread.RunWorkerAsync();
            Start_Watch();
            // generate sudoku, execute Stop_Watch() on end
        }

        /// <summary>
        /// Solves the generated Sudoku Board
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_solve_Click(object sender, EventArgs e)
        {
            Start_Watch();
            // solve sudoku, execute Stop_Watch() on end
        }

        /// <summary>
        /// Resets  or clears the Sudoku Board
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_reset_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Perderá el sudoku generado/cargado actualmente. Desea continuar?",
                                  "Confirmacion - Limpiar Pantalla", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
            {
                Reset_Watch();

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

        /// <summary>
        /// Saves the Sudoku on display as a .txt file on the 'saves' directory
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_save_Click(object sender, EventArgs e)
        {
            string fileName = SudokuFileHandler.SaveSudoku(Board.ToString());
            MessageBox.Show("Guardado como \""+fileName+"\" en el directorio \"saves\" del proyecto",
                            "Guardar Killer Sudoku", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Loads a Sudoku based on a .txt with the appropiate format
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

                    Reset_Watch();
                }
                catch(Exception exc)
                {
                    DialogResult dr = MessageBox.Show("Error al cargar Sudoku: "+exc.Message,
                                                      "Error - Cargar Sudoku", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Updates the Sudoku Board size based on the selected Dimension
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Enables the sldr_thread control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_useThreads_CheckedChanged(object sender, EventArgs e)
        {
            if (btn_useThreads.Checked)
                lbl_threadNum.Text = sldr_thread.Value.ToString();
            else
                lbl_threadNum.Text = "";
            sldr_thread.Enabled = btn_useThreads.Checked;
            lbl_threadNum.Enabled = btn_useThreads.Checked;
        }

        /// <summary>
        /// Displays a pop-up with the Project and Devs information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Starts the stopwatch
        /// </summary>
        private void Start_Watch()
        {
            lbl_timer.ForeColor = Color.ForestGreen;
            TimerThread.RunWorkerAsync();
        }

        /// <summary>
        /// BackgroundWorker function. Runs the stopwatch
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Start_Watch(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = sender as BackgroundWorker;
            Watch = Stopwatch.StartNew();
            int ms = 0,
                oldms = 0;
            while (Watch.IsRunning)
            {
                ms = (int)Watch.ElapsedMilliseconds;
                if (ms > oldms)
                {
                    bw.ReportProgress(ms);
                    oldms = ms;
                }
            }
        }

        /// <summary>
        /// Updates lbl_timer based on the elapsed time on the stopwatch
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateWatchLabel(object sender, ProgressChangedEventArgs e)
        {
            TimeSpan t = TimeSpan.FromMilliseconds(e.ProgressPercentage);
            string elapsedTime = t.ToString("hh':'mm':'ss'.'ff");
            lbl_timer.Text = "Timer - " + elapsedTime;
        }

        /// <summary>
        /// Stops the stopwatch
        /// </summary>
        private void Stop_Watch()
        {
            Watch.Stop();
            lbl_timer.ForeColor = Color.Red;
        }

        /// <summary>
        /// Resets the stopwatch (BUGGED)
        /// </summary>
        private void Reset_Watch()
        {
            Watch.Reset();
            lbl_timer.Text = "Timer - 00:00:00.00"; //+ Watch.Elapsed.ToString("hh':'mm':'ss'.'ff");
            lbl_timer.ForeColor = Color.SaddleBrown;
        }
    }
}
