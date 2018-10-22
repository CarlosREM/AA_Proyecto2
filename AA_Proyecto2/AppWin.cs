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
        private Stopwatch Watch = null;

        private BackgroundWorker NewSudokuThread;
        private BackgroundWorker TimerThread;
        private BackgroundWorker GeneratorThread;
        private BackgroundWorker SolverThread;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public AppWin()
        {
            InitializeComponent();

            NewSudokuThread = new BackgroundWorker() { WorkerSupportsCancellation = true };
            NewSudokuThread.DoWork += Th_InitializeBoard;
            NewSudokuThread.RunWorkerCompleted += Th_AddBoard;

            TimerThread = new BackgroundWorker();
            TimerThread.DoWork += Start_Watch;

            GeneratorThread = new BackgroundWorker() { WorkerSupportsCancellation = true };
            GeneratorThread.DoWork += (sender, e) => Board.Generate();
            GeneratorThread.RunWorkerCompleted += GeneratorThreadCompleted;

            SolverThread = new BackgroundWorker() { WorkerSupportsCancellation = true };
            SolverThread.DoWork += (sender, e) =>
            {
                BackgroundWorker bw = sender as BackgroundWorker;
                for (int i = 0; i < 1000000000 && !Sudoku.stopSolver; i++) { }
            };
            SolverThread.RunWorkerCompleted += SolverThreadCompleted; ;

            InitializeBoard(9);
            Controls.Add(Board);
        }

        /// <summary>
        /// Initializes Sudoku Board on executing NewSudokuThread.RunWorkerAsync, accepts the dimension as argument on 'e'
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
        }

        /// <summary>
        /// Executes when the Generator thread finalizes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GeneratorThreadCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Stop_Watch();
            Board.Cursor = Cursors.Default;
            if (!Sudoku.stopGenerator)
            {
                btn_generate.Text = "GENERATED";
                btn_generate.Enabled = false;
                btn_reset.Enabled = true;
                btn_reset.Text = "Clear Board";
                btn_save.Enabled = true;
                btn_load.Enabled = true;
            }
            else
            {
                Sudoku.stopGenerator = false;
                btn_generate.Text = "GENERATE";
            }
        }

        /// <summary>
        /// Executes when the Solver thread finalizes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SolverThreadCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Stop_Watch();
            Board.Cursor = Cursors.Default;
            if (!Sudoku.stopSolver)
            {
                btn_solve.Text = "SOLVED";
                btn_solve.Enabled = false;
                btn_reset.Enabled = true;
                btn_save.Enabled = true;
                btn_load.Enabled = true;
            }
            else
            {
                Sudoku.stopSolver = false;
                btn_solve.Text = "SOLVE SUDOKU";
            }
        }

        // UI USABILITY - - - - - - - - -

        /// <summary>
        /// Disables user control, then generates the Numbers and tetrominos on the Sudoku Board
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_generate_Click(object s, EventArgs ev)
        {
            if (btn_generate.Text == "GENERATE")
            {
                Board.Cursor = Cursors.AppStarting;

                sldr_size.Enabled = false;
                btn_generate.Text = "STOP";
                btn_solve.Enabled = false;
                btn_reset.Enabled = false;
                btn_save.Enabled = false;
                btn_load.Enabled = false;

                GeneratorThread.RunWorkerAsync();
                Start_Watch();
            }
            else
            {
                Sudoku.stopGenerator = true;
                btn_generate.Enabled = false;
                btn_reset.Enabled = true;
                btn_load.Enabled = true;
            }
        }

        /// <summary>
        /// Solves the generated Sudoku Board
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_solve_Click(object sender, EventArgs e)
        {
            if (btn_solve.Text == "SOLVE SUDOKU")
            {
                Board.Cursor = Cursors.AppStarting;

                btn_solve.Text = "STOP";
                btn_reset.Text = "Clear Board";
                btn_reset.Enabled = false;
                btn_save.Enabled = false;
                btn_load.Enabled = false;
                SolverThread.RunWorkerAsync();
                Start_Watch();
            }
            else
            {
                Sudoku.stopSolver = true;
                btn_solve.Enabled = false;
                btn_reset.Enabled = true;
                btn_save.Enabled = true;
                btn_load.Enabled = true;
            }
        }

        /// <summary>
        /// Resets  or clears the Sudoku Board
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_reset_Click(object sender, EventArgs e)
        {
            bool reset = true;
            DialogResult dr;
            if (btn_solve.Enabled)
            {
                dr = MessageBox.Show("Perderá el sudoku generado/cargado actualmente. Desea continuar?",
                                      "Confirmacion - Reiniciar Sudoku", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                reset = (dr == DialogResult.Yes); 
            }
            else if (btn_reset.Text == "Clear Board")
            {
                dr = MessageBox.Show("Perderá la resolución del Sudoku y no lo podrá salvar. Desea continuar?",
                      "Confirmacion - Limpiar Sudoku", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                reset = (dr == DialogResult.Yes);
            }
            if (reset)
            {
                if (Watch != null)
                    Reset_Watch();

                if (btn_reset.Text == "Reset Board")
                {
                    Board.Dispose();
                    int dimension = sldr_size.Value;
                    NewSudokuThread.RunWorkerAsync(argument: dimension);
                    Refresh();

                    sldr_size.Enabled = true;
                    btn_generate.Enabled = true;
                    btn_generate.Text = "GENERATE";
                    btn_solve.Enabled = false;
                    btn_reset.Enabled = false;
                }
                else
                {
                    Board.Clear();
                    btn_solve.Enabled = true;
                    btn_solve.Text = "SOLVE SUDOKU";
                    btn_reset.Text = "Reset Board";
                    btn_solve.Enabled = true;
                }
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
            string fileName = SudokuFileHandler.SaveSudoku(Board.ToString(), Board.Dimension);
            MessageBox.Show("Guardado como \""+fileName+"\" en el directorio \"saves\" del proyecto",
                            "Guardar Killer Sudoku", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btn_save.Enabled = false;
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
                    Sudoku newBoard = SudokuFileHandler.LoadSudoku();
                    if (newBoard != null)
                    {
                        Board.Dispose();
                        Board = newBoard;
                        Board.Location = new Point(180, 30);
                        Controls.Add(Board);
                        Refresh();

                        sldr_size.Enabled = false;
                        sldr_size.Value = Board.Dimension;
                        btn_generate.Enabled = false;
                        btn_generate.Text = "GENERATED";
                        btn_solve.Enabled = false;
                        btn_reset.Enabled = true;
                        btn_reset.Text = "Clear Board";
                        btn_save.Enabled = false;

                        if (Watch != null)
                            Reset_Watch();
                    }
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
            lbl_sizeNum.Text = sldr_size.Value.ToString();
            if (!NewSudokuThread.IsBusy && sldr_size.Enabled)
            {
                sldr_size.Enabled = false;
                btn_generate.Enabled = false;
                Board.Dispose();
                int dimension = sldr_size.Value;
                NewSudokuThread.RunWorkerAsync(argument: dimension);
                Refresh();
            }
            else
                NewSudokuThread.CancelAsync();
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

        // STOPWATCH - - - - - - - -  - - - -
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
            Watch = Stopwatch.StartNew();
            int ms = 0,
                oldms = 0;
            while (Watch.IsRunning)
            {
                ms = (int)Watch.ElapsedMilliseconds;
                if (ms > oldms)
                {
                    lbl_timer.Invoke((MethodInvoker)(() =>
                    {
                        lbl_timer.Text = "Timer - " + Watch.Elapsed.ToString("hh':'mm':'ss'.'ff");
                    }));
                    oldms = ms;
                }
            }
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
