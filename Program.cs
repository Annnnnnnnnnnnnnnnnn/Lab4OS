using System;

namespace Lab4OS
{
    class Program
    {
        static int[][] Matrix;
   

        public static void PrintMatr(int[][] matrix)
        {
            int rows = matrix.Length;
            int cols = matrix[0].Length;
            Console.WriteLine("Matrix: ");
            for(int i =0; i< rows; i++)
            {
                for(int j = 0; j< cols; j++)
                {
                    Console.Write(matrix[i][j]);
                }
                Console.WriteLine();
            }
        }

        public static void ChangeRow(int[][] matrix, int rows)
        {
            int[] tempMass;
            int temp;
            for(int i = 1; i< rows; i++)
            {
                if(matrix[i][i] == 0)
                {
                    for(int j = 0; j< rows; j++)
                    {
                        if(matrix[j][i] == 1)
                        {
                            tempMass = matrix[i];
                            matrix[i] = matrix[j];
                            matrix[j] = tempMass;
                        }

                    }
                }
            }
            for(int i = 1; i< rows; i++)
            {
                if (matrix[i][i] == 0)
                {
                    for (int j = i + 1; j < rows; j++)
                    {
                        if (matrix[i][j] == 1)
                        {
                            for (int k = 0; i < rows; k++)
                            {
                                temp = matrix[k][i];
                                matrix[k][i] = matrix[k][j];
                                matrix[k][j] = temp;
                            }
                        }
                    }
                }
            }

        }

        public static void ChangeCol(int[][] matrix, int cols)
        {
            for (int k = 1; k < cols - 1; k++)
            {
                int[] vectmin = new int[cols + 1];

                int[] tempMass;
                int temp;
                int min = 0;
                int imin = 0;
                for (int i = k; i < cols; i++)
                {
                    vectmin[i] = 0;
                    for (int j = k; j < cols; j++)
                    {
                        vectmin[i] += matrix[i][j];
                    }
                }
                min = vectmin[k];
                imin = k;
                for (int i = k; i < cols; i++)
                {
                    if (min > vectmin[i])
                    {
                        imin = i;
                        min = vectmin[i];
                    }
                }
                tempMass = matrix[imin];
                matrix[imin] = matrix[k];
                matrix[k] = tempMass;
                PrintMatr(matrix);
                vectmin = new int[cols];
                for (int i = k; i < cols; i++)
                {
                    vectmin[i] = 0;
                    for (int j = k; j < cols; j++)
                    {
                        vectmin[i] += matrix[j][i];
                    }
                }

                bool b = false;
                for (int i = k; i < cols; i++)
                {
                    if (matrix[k][i] == 1)
                    {
                        imin = i;
                        min = vectmin[i];
                        b = true;
                        break;
                    }
                }
                if (b)
                {
                    for (int i = k; i < cols; i++)
                    {
                        if ((matrix[k][i] > min) && (vectmin[i] > min))
                        {
                            imin = i;
                            min = vectmin[i];
                           
                        }
                    }
                    for (int i = 0; i < cols; i++)
                    {
                        temp = matrix[i][imin];
                        matrix[i][imin] = matrix[i][k];
                        matrix[i][k] = temp;
                    }
                }
                
            }
            Console.WriteLine("Перетворена матриця");
            PrintMatr(Matrix);
        }
        static void Main(string[] args)
        {
            Random rand = new Random();
            Matrix = new int[5][];
            Matrix[0] = new int[7];
            for(int  i = 0; i< 5; i++)
            {
                Matrix[0][i] = i;
            }
            for (int i = 1; i < 5; i++)
            {
                Matrix[i] = new int[7];
                Matrix[i][0] = i;
                for (int j = 1; j < 7; j++)
                {
                    int r = rand.Next(4);
                    if (r == 0) Matrix[i][j] = 0;
                    else Matrix[i][j] = 1;
                }
            }
            Console.WriteLine("Початкова матриця");
            PrintMatr(Matrix);
            Console.WriteLine();
            ChangeCol(Matrix, 5);
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
