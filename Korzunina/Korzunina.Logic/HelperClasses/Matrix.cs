using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Korzunina.Logic
{
    public class Matrix
    {
        private double[,] _matr;

        /// <summary>
        /// Количество строк
        /// </summary>
        public int N { get; private set; }
        /// <summary>
        /// количество столбцов
        /// </summary>
        public int M { get; private set; }

        public double Det
        {
            get
            {
                if (M == 1 && N == 1)
                {
                    return this[0, 0];
                }
                else
                {
                    double det = 0;

                    for (int i = 0; i < N; i++)
                    {
                        det += Math.Pow(-1, i) * this[0, i] * Cofactor(0, i);
                    }

                    return det;
                }

            }
        }

        public Matrix InverseMatrix
        {
            get
            {
                double inverseDet = 1 / Det;
                Matrix transposeMatrix = TransposeMatrix;
                Matrix A = new Matrix(N, M);

                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < M; j++)
                    {
                        A[i, j] = transposeMatrix.Cofactor(i, j) * Math.Pow(-1, i + j);
                    }
                }

                return inverseDet * A;
            }
        }

        /// <summary>
        /// Алгебраическое дополнение
        /// </summary>
        private double Cofactor(int indexI, int indexJ)
        {
            Matrix matrix = new Matrix(N - 1, M - 1);

            for (int i = 0; i < M; i++)
            {
                if (i != indexI)
                    for (int j = 0; j < M; j++)
                    {
                        if (j != indexJ)
                        {
                            int indI = (i > indexI) ? i - 1 : i,
                                indJ = (j > indexJ) ? j - 1 : j;
                            matrix[indI, indJ] = this[i, j];
                        }
                    }
            }

            return matrix.Det;
        }

        public Matrix TransposeMatrix
        {
            get
            {
                Matrix transpose = new Matrix(M, N);

                for (int i = 0; i < N; i++)
                    for (int j = 0; j < M; j++)
                        transpose[i, j] = this[j, i];

                return transpose;
            }
        }

        public Matrix(int N, int M)
        {
            this.N = N;
            this.M = M;
            _matr = new double[N, M];
            for (int i = 0; i < N; i++)
                for (int j = 0; j < M; j++)
                    this[i, j] = i != j ? 0 : 1;
        }
        public Matrix(double[,] a)
            : this(a.GetLength(0), a.GetLength(1))
        {
            for (int i = 0; i < N; i++)
                for (int j = 0; j < M; j++)
                    this[i, j] = a[i, j];
        }
        public Matrix(double[,] a, int N, int M)
            :this(N, M)
        {
            for (int i = 0; i < N; i++)
                for (int j = 0; j < M; j++)
                    this[i, j] = a[i, j];
        }
        public Matrix(List<Point> points)
            :this(4, points.Count)
        {
            for (int i = 0; i < points.Count; i++)
            {
                this[0, i] = points[i].X;
                this[1, i] = points[i].Y;
                this[2, i] = points[i].Z;
                this[3, i] = 1;
            }
        }

        public void ShowToConsole()
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                    Console.Write(_matr[i, j] + " ");
                Console.WriteLine();
            }
        }

        #region Перегрузки операторов

        public static Matrix operator *(Matrix a, Matrix b)
        {
            Matrix c = new Matrix(a.N, b.M);
            for (int i = 0; i < a.N; i++)
            {

                for (int j = 0; j < b.M; j++)
                {
                    double v = 0;
                    for (int k = 0; k < a.M; k++)
                    {
                        v += a[i, k] * b[k, j];
                    }
                    c[i, j] = v;
                }
            }
            return c;
        }
        public static Matrix operator *(double b, Matrix a)
        {
            Matrix c = new Matrix(a.N, a.M);
            for (int i = 0; i < a.N; i++)
            {
                for (int j = 0; j < a.M; j++)
                {
                    c[i, j] = a[i, j] * b;
                }
            }
            return c;
        }
        public static double[] operator *(Matrix a, double[] b)
        {
            double[] c = new double[a.N];
            for (int i = 0; i < a.N; i++)
            {
                for (int j = 0; j < a.M; j++)
                {
                    c[i] += a[i, j] * b[j];
                }
            }
            return c;
        }
        public static Matrix operator +(Matrix a, Matrix b)
        {
            Matrix c = new Matrix(a.M, a.N);
            for (int i = 0; i < a.M; i++)
            {
                for (int j = 0; j < a.N; j++)
                {
                    c[i, j] = a[i, j] + b[i, j];
                }
            }
            return c;
        }
        public static Matrix operator -(Matrix a, Matrix b)
        {
            Matrix c = new Matrix(a.M, a.N);
            for (int i = 0; i < a.M; i++)
            {
                for (int j = 0; j < a.N; j++)
                {
                    c[i, j] = a[i, j] - b[i, j];
                }
            }
            return c;
        }
        public double this[int i, int j]
        {
            get
            {
                return _matr[i, j];
            }
            set
            {
                _matr[i, j] = value;
            }
        }

        #endregion
    }
}
