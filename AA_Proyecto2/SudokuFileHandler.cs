using System;
using System.IO;
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
                   filePath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\"));
            filePath = Path.Combine(filePath, @"saves");
            Console.WriteLine(filePath);

            File.WriteAllLines(Path.Combine(filePath, fileName), strSudoku.Split('\n'));
            return fileName;
        }

        /*public static Sudoku LoadSudoku(string filePath)
        {

        }*/
    }
}
