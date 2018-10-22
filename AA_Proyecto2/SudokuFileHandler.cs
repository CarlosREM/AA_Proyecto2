using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AA_Proyecto2
{
    public class SudokuFileHandler
    {
        public static string SaveSudoku(string strSudoku, int Size)
        {
            string sudokuSize = Size.ToString() + "x" + Size.ToString(),
                   fileName = "KillerSudoku-"+sudokuSize+"_" + DateTime.Now.ToString("dd-MM-yyyy_hh-mm-ss") + ".txt",
                   filePath = Path.Combine(Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\")), @"saves");
            Console.WriteLine(filePath);

            File.WriteAllLines(Path.Combine(filePath, fileName), strSudoku.Split('\n'));
            return fileName;
        }

        public static Sudoku LoadSudoku()
        {
            Sudoku NewBoard = null;
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                InitialDirectory = Path.Combine(Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\")), @"saves"),
                Filter = "Sudoku Save Files (*.txt)|*.txt"
            };
            string[] fileContent;
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                NewBoard = null;
                fileContent = File.ReadAllLines(fileDialog.FileName);
                try
                {
                    int section = 0,
                        row = 0,
                        column = 0;
                    string[] sudokuRow;
                    foreach (string line in fileContent)
                    {
                        if (line == "-") {
                            section++;
                            continue;
                        }
                        switch (section)
                        {
                            case (0): //Dimension
                                NewBoard = new Sudoku(int.Parse(line));
                                break;
                            case (1): //Sudoku
                                sudokuRow = line.Split(',');
                                column = 0;
                                foreach (string token in sudokuRow)
                                {
                                    NewBoard.SetCellAt(row, column, int.Parse(token));
                                    column++;
                                }
                                row++;
                                break;
                            case (2): //Tetrominos
                                NewBoard.Tetrominos.Add(new Tetromino(NewBoard, line));
                                break;
                        }
                    }
                }
                catch (Exception e) {
                    e.ToString();
                    NewBoard = null;
                    throw new Exception("El archivo no tiene el formato adecuado.");
                }
            }
            return NewBoard;
        }
    }
}
