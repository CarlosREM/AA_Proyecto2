using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AA_Proyecto2
{
    public class SudokuSolver
    {
        public static Sudoku Board = null;
        private static int availableThreads;

        public static bool Stop = false;
        public static bool Solved = false;

        private static readonly object AvailableThreadsLocker = new object();
        private static readonly object SolutionLocker = new object();

        private SudokuRegion.RegionTemplate[] Regions;
        private Tetromino.TetroTemplate[] Tetros;

        public void StartSolver(Sudoku pBoard, int threadNum)
        {
            Board = pBoard;
            int[,] BoardTemplate = new int[Board.Dimension, Board.Dimension];
            Regions = new SudokuRegion.RegionTemplate[Board.Dimension];
            for (int i = 0; i < Board.Dimension; i++)
            {
                Regions[i] = new SudokuRegion.RegionTemplate(Board.Regions[i]);
                for (int j = 0; j < Board.Dimension; j++)
                    BoardTemplate[i, j] = 0;
            }

            Tetros = new Tetromino.TetroTemplate[Board.Tetrominos.Count];
            for (int t = 0; t < Board.Tetrominos.Count; t++)
                Tetros[t] = new Tetromino.TetroTemplate(Board.Tetrominos[t]);

            PartialSolve(BoardTemplate);
        }

        private bool PartialSolve(int[,] BoardTemplate)
        {
            bool LockedCoord = false;
            int row = -1,
                col = -1;
            for (int i = 0; i < Board.Dimension && !Stop && !LockedCoord; i++)
            {
                for (int j = 0; j < Board.Dimension && !Stop && !LockedCoord; j++)
                {
                    if (BoardTemplate[i, j] == 0)
                    {
                        LockedCoord = true;
                        row = i;
                        col = j;
                    }
                }
            }
            if (!Stop && !LockedCoord && !Solved)
                SetSolution(BoardTemplate);

            Tetromino.TetroTemplate tetro;
            bool advance = true;
            List<Task> ThreadPool = new List<Task>();
            for (int num = 1; num <= Board.Dimension && !Stop && !Solved; num++)
            {
                //Console.WriteLine("\n> Cell [{0},{1}] - Attempting #{2}", row, col, num);
                advance = true;
                BoardTemplate[row, col] = num;
                if (!Solved && !Stop && CheckValueTemplate(num, row, col, BoardTemplate))
                {
                    tetro = FindTetroAt(row, col);
                    if (!Solved && !Stop &&  tetro.IsFull(BoardTemplate))
                    {
                        if (!Solved && !Stop &&  !tetro.CheckResult(BoardTemplate))
                            advance = false;
                    }
                }
                else
                    advance = false;

                if (!Solved && !Stop && advance)
                {
                    if (GetAvailableThreads() > 0)
                    {
                        ChangeAvailableThreads(-1);
                        Task t = Task.Factory.StartNew(() => {
                            PartialSolve(BoardTemplate);
                        });
                        t.ContinueWith((t1) => ChangeAvailableThreads(1));
                        ThreadPool.Add(t);
                        continue;
                    }

                    if (!Solved && !Stop && ThreadPool.Count > 0)
                        Task.WaitAll(ThreadPool.ToArray());
                    else
                    {
                        //Console.WriteLine("=> Advancing to next Cell!");
                        if (!Solved && !Stop && !PartialSolve(BoardTemplate))
                        {
                            advance = false;
                            BoardTemplate[row, col] = 0;
                        }
                    }
                }
                else
                {
                    //Console.WriteLine("=> Failed to Advance, try next number?");
                    BoardTemplate[row, col] = 0;
                }
                //Thread.Sleep(100);
            }
            //Console.WriteLine(">> Returning to previous Cell... <<");
            return advance;
        }

        /// <summary>
        /// Checks if a number value is unique for a row, column, tetro and region on the partial solution
        /// </summary>
        /// <param name="Row"></param>
        /// <param name="Col"></param>
        /// <param name="newValue"></param>
        /// <returns></returns>
        private bool CheckValueTemplate(int newValue, int Row, int Col, int[,] BoardTemplate)
        {
            //Console.Write(">> Testing... ");
            bool aptValue = true;
            SudokuRegion.RegionTemplate Region = FindRegionAt(Row, Col);
            Tetromino.TetroTemplate Tetro = FindTetroAt(Row, Col);
            if ((Region != null && Region.CheckNumber(newValue, Row, Col, BoardTemplate)) || (Tetro != null && Tetro.CheckNumber(newValue, Row, Col, BoardTemplate)))
                aptValue = false;
            else
            {
                int RowCell, ColCell;
                for (int i = 0; i < Board.Dimension && aptValue; i++)
                {
                    RowCell = BoardTemplate[Row, i];
                    ColCell = BoardTemplate[i, Col];
                    if (RowCell == newValue && i != Col) {
                        aptValue = false;
                        //Console.WriteLine("Found number on same row");
                    }

                    else if (ColCell == newValue && i != Row) {
                        aptValue = false;
                        //Console.WriteLine("Found number on same column");
                    }
                }
            }
            /*
            if (aptValue)
                Console.WriteLine(" Passed!");
            //*/
            return aptValue;
        }

        /// <summary>
        /// Finds the Region that contains the specified coordinates
        /// </summary>
        /// <param name="Row"></param>
        /// <param name="Col"></param>
        /// <returns></returns>
        private SudokuRegion.RegionTemplate FindRegionAt(int Row, int Col)
        {
            SudokuRegion.RegionTemplate RegionOut = null;
            foreach (SudokuRegion.RegionTemplate Region in Regions)
            {
                if (Region.ContainsCoord(Row, Col))
                {
                    RegionOut = Region;
                    break;
                }
            }
            return RegionOut;
        }

        /// <summary>
        /// Finds the Tetro that contains the specified coordinates
        /// </summary>
        /// <param name="Row"></param>
        /// <param name="Col"></param>
        /// <returns></returns>
        private Tetromino.TetroTemplate FindTetroAt(int Row, int Col)
        {
            Tetromino.TetroTemplate TetroOut = null;
            foreach (Tetromino.TetroTemplate Tetro in Tetros)
            {
                if (Tetro.ContainsCoord(Row, Col))
                {
                    TetroOut = Tetro;
                    break;
                }
            }
            return TetroOut;
        }


        private int GetAvailableThreads()
        {
            int tmp_AvThreads = 0;
            lock(AvailableThreadsLocker)
            {
                tmp_AvThreads = availableThreads;
            }
            return tmp_AvThreads;
        }
        /// <summary>
        /// Alters the number of Available threads by 1 (+ or -)
        /// </summary>
        /// <param name="change"></param>
        private void ChangeAvailableThreads(int change)
        {
            lock(AvailableThreadsLocker)
            {
                availableThreads += change;
            }
        }

        /// <summary>
        /// Sets a final solution for the board
        /// </summary>
        private void SetSolution(int [,] BoardTemplate)
        {
            lock(SolutionLocker)
            {
                //Console.WriteLine("==# SUDOKU COMPLETED #==");
                Solved = true;
                Stop = true;
                Thread.Sleep(100);
                Board.Clear();
                for (int row = 0; row < Board.Dimension; row++)
                    for (int col = 0; col < Board.Dimension; col++)
                        Board.SetCellAt(row, col, BoardTemplate[row, col]);
            }
        }
    }
}
