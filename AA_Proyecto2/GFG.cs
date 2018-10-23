using System;
using System.Collections.Generic;
using System.Text;

namespace GFG
{
    /* A Backtracking program in  
    Java to solve Sudoku problem */
    class GFG
    {
        public static bool isSafe(int[][] board,
                             int row, int col,
                             int num)
            
        {
            
            // row has the unique (row-clash) 
            for (int d = 0; d < board.Length; d++)
            {
                // if the number we are trying to  
                // place is already present in  
                // that row, return false; 
                if (board[row][d] == num)
                {

                    return false;
                }
            }

            // column has the unique numbers (column-clash) 
            for (int r = 0; r < board.Length; r++)
            {
                // if the number we are trying to 
                // place is already present in 
                // that column, return false; 

                if (board[r][col] == num)
                {
                    return false;
                }
            }

            // corresponding square has 
            // unique number (box-clash) 
            int sqrt = (int)Math.Sqrt(board.Length);
            int boxRowStart = row - row % sqrt;
            int boxColStart = col - col % sqrt;

            for (int r = boxRowStart;
                     r < boxRowStart ; r++)
            {
                for (int d = boxColStart;
                         d < boxColStart ; d++)
                {
                    if (board[r][d] == num)
                    {
                        return false;
                    }
                }
            }

            // if there is no clash, it's safe 
            return true;
        }

        public static bool solveSudoku(int[][] board, int n)
        {
            int row = -1;
            int col = -1;
            bool isEmpty = true;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (board[i][j] == 0)
                    {
                        row = i;
                        col = j;

                        // we still have some remaining 
                        // missing values in Sudoku 
                        isEmpty = false;
                        break;
                    }
                }
                if (!isEmpty)
                {
                    break;
                }
            }

            // no empty space left 
            if (isEmpty)
            {
                return true;
            }

            // else for each-row backtrack 
            for (int num = 1; num <= n; num++)
            {
                if (isSafe(board, row, col, num))
                {
                    board[row][col] = num;
                    if (solveSudoku(board, n))
                    {
                        // print(board, n); 
                        return true;
                    }
                    else
                    {
                        board[row][col] = 0; // replace it 
                    }
                }
            }
            return false;
        }

        public static void print(int[][] board, int N)
        {
            // we got the answer, just print it 
            for (int r = 0; r < N; r++)
            {
                for (int d = 0; d < N; d++)
                {
                    Console.WriteLine(board[r][d]);
                    //Console.WriteLine(" ");
                }
                Console.WriteLine("\t");

                if ((r + 1) % (int)Math.Sqrt(N) == 0)
                {
                    Console.WriteLine("");
                }
            }
        }
    }
}
