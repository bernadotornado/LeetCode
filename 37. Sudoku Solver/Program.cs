using System;
using LeetCode;

namespace _37._Sudoku_Solver
{
    class Solution
    {
        public static void SolveSudoku(char[][] board) {
        
        }
        static void Main(string[] args)
        {
            Common.Run(typeof(Solution), SolveSudoku, new char [][]
            {
                new []{'5','3','.','.','7','.','.','.','.'},
                new []{'6','.','.','1','9','5','.','.','.'},
                new []{'.','9','8','.','.','.','.','6','.'},
                new []{'8','.','.','.','6','.','.','.','3'},
                new []{'4','.','.','8','.','3','.','.','1'},
                new []{'7','.','.','.','2','.','.','.','6'},
                new []{'.','6','.','.','.','.','2','8','.'},
                new []{'.','.','.','4','1','9','.','.','5'},
                new []{'.','.','.','.','8','.','.','7','9'}
            });
        }
        
        
    }
}
