using System;

namespace OS4
{
    class Program
    {
       public static int[,] Matrix = {{0, 1, 1, 1, 0,1,1},
                                      {1, 0, 1, 0, 1,0,1},
                                      {0, 0, 0, 0, 1,1,0},
                                      { 1, 1, 0, 0, 0,1,0},
                                      { 0, 1, 0, 1, 0,1,0},
                                      { 1, 0, 0, 1, 0,0,1},
                                      { 0, 1, 1, 1, 0,0,0}};

        public static void ShowMatrix(int[,] matrix)
        {
            for(int i = 0; i< matrix.GetLength(0); i++)
            {
                for(int j = 0; j< matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        public static void ChangeRows(int[,] matrix, int n, int m)
        {
            int temp;
            for(int j = 0; j< matrix.GetLength(0); j++)
            {
               temp = matrix[n, j];

                matrix[n, j] = matrix[m, j];

                matrix[m, j] = temp;
            }
        }

        public static void ChangeCols(int[,] matrix, int n, int m)
        {
            int temp;
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                temp = matrix[j,n];

                matrix[j,n] = matrix[j,m];

                matrix[j,m] = temp;
            }
        }

        public static int FindMinRow(int[,] matrix, int ptr)
        {
            int minEl = matrix.GetLength(1);
            int minRowNumb = -1;
            int sum = 0;
            for(int i = ptr; i< matrix.GetLength(1); i++)
            {
                sum += matrix[i, ptr];
                if (sum < minEl) {
                    sum = minEl;
                    minRowNumb = i;
                }

            }
            return minRowNumb;
        }

        public static int FindMinCol(int[,] matrix, int ptr)
        {
            int minEl = matrix.GetLength(0);
            int minColNumb = -1;
            int sum = 0;
            for (int i = ptr; i < matrix.GetLength(0); i++)
            {
                if(matrix[ptr, i] == 1)
                {
                    sum += matrix[ptr, i];
                    if (sum < minEl)
                    {
                        sum = minEl;
                        minColNumb = i;
                    }
                }



            }
            return minColNumb;
        }

        public static void Algorithm(int[,] matrix)
        {
            int temp = 0;
            int[,] solutionMatrix = new int[matrix.GetLength(0), 2];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    solutionMatrix[i, j] = i;
                }
            }
            for (int i = 0; i< matrix.GetLength(0); i++)
            { 
                int rowPtr = FindMinRow(matrix, i);
                if (rowPtr == -1) continue;
                ChangeRows(matrix, rowPtr, i);
                temp = solutionMatrix[i,0];
                solutionMatrix[i, 0] = solutionMatrix[rowPtr,0];
                solutionMatrix[rowPtr, 0] = temp;

                int colPtr = FindMinCol(matrix, i);
                if (colPtr == -1) continue;
                ChangeCols(matrix, i, colPtr);
                temp = solutionMatrix[i,1];
                solutionMatrix[i, 1] = solutionMatrix[colPtr,1];
                solutionMatrix[colPtr, 1] = temp;
                Console.WriteLine($"Послан запрос " + solutionMatrix[i, 1] + " к ресурсу " + solutionMatrix[i, 0]);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Базовая матрица: ");

            ShowMatrix(Matrix);
            Console.WriteLine();
            Algorithm(Matrix);
          
        }
    }
}
