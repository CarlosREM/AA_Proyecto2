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
        public static string SaveSudoku(string strSudoku)
        {
            string fileName = "KillerSudoku_" + DateTime.Now.ToString("dd-MM-yyyy_hh-mm-ss") + ".txt",
                   filePath = Path.Combine(Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\")), @"saves");
            Console.WriteLine(filePath);

            File.WriteAllLines(Path.Combine(filePath, fileName), strSudoku.Split('\n'));
            return fileName;
        }

        public static Sudoku LoadSudoku()
        {
            Sudoku NewBoard = null;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Path.Combine(Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\")), @"saves");
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                string filePath;
                string[] fileContent;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    fileContent = File.ReadAllLines(filePath);
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
                                    foreach(string token in sudokuRow)
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
                    catch (Exception e){
                        throw new Exception("El archivo no tiene el formato adecuado.");
                    }
                }
            }
            return NewBoard;
        }
    }
}
