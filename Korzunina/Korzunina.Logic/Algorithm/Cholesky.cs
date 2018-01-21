using System;
namespace Korzunina.Logic
{
    public class Cholesky
    {
        private static int L, N;
        private static double[,] b, c;

        // статический метод решения сисеты линейных уравнений, матрица которой имеет ленту matrix, c правой частью rightPart
        public static double[] Solve(double[,] matrix, double[] rightPart)
        {
            L = matrix.GetLength(1) / 2 + 1;
            N = matrix.GetLength(0);

            b = new double[N, L];
            c = new double[N, L];

            for (int j = 0; j < N; j++)
            {
                for (int i = j; i < Math.Min(j + L, N); i++)
                {
                    double sum = 0;
                    for (int k = k0(i); k <= j - 1; k++)
                    {
                        sum += getElem(b, i, k) * getUpperElem(c, k, j);
                    }
                    double val = getElem(matrix, i, j) - sum;
                    setElem(b, i, j, val);
                }

                for (int i = j; i < Math.Min(j + L, N); i++)
                {
                    double sum = 0;
                    for (int k = k0(i); k <= j - 1; k++)
                    {
                        sum += getElem(b, j, k) * getUpperElem(c, k, i);
                    }
                    double val = (getElem(matrix, j, i) - sum) / getElem(b, j, j);
                    setUpperElem(c, j, i, val);
                }
            }

            double[] y = new double[N];
            double[] x = new double[N];

            for (int i = 0; i < N; i++)
            {
                double sum = 0;
                for (int k = k0(i); k <= i - 1; k++)
                {
                    sum += getElem(b, i, k) * y[k];
                }
                y[i] = (rightPart[i] - sum) / getElem(b, i, i);
            }

            for (int i = N - 1; i >= 0; i--)
            {
                double sum = 0;
                for (int k = i + 1; k <= kN(i); k++)
                {
                    sum += getUpperElem(c, i, k) * x[k];
                }
                x[i] = y[i] - sum;
            }

            return x;
        }

        //функции, использующиеся в индексах сумм, для икслючения нулевых слагаемых
        private static int k0(int i)
        {
            return i < L ? 0 : i - L + 1;
        }

        private static int kN(int i)
        {
            return i < N - L ? i + L - 1 : N - 1;
        }


        //методы для получения и задания элемента в ленте
        private static double getElem(double[,] matrix, int i, int j)
        {
            return matrix[i, j - i + L - 1];
        }

        private static void setElem(double[,] matrix, int i, int j, double val)
        {
            matrix[i, j - i + L - 1] = val;
        }


        //методы для получения и задания элемента в ленте, если лента содержит только верхнюю половину матрицы
        private static double getUpperElem(double[,] matrix, int i, int j)
        {
            return matrix[i, j - i];
        }

        private static void setUpperElem(double[,] matrix, int i, int j, double val)
        {
            matrix[i, j - i] = val;
        }
    }
}
