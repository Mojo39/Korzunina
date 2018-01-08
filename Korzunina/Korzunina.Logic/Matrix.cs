using System;
using System.IO;
using System.Linq;

namespace Korzunina.Logic
{
    public class Matrix
    {
        private double[,] _matr;

        public int N { get; private set; }
        public int M { get; private set; }

        public Matrix(int N, int M)
        {
            this.N = N;
            this.M = M;
            _matr = new double[N, M];
            for (int i = 0; i < N; i++)
                for (int j = 0; j < M; j++)
                    _matr[i, j] = i != j ? 0 : 1;
        }
        public Matrix(double[,] a)
        {
            N = a.GetLength(0);
            M = a.GetLength(1);
            _matr = new double[N, M];
            for (int i = 0; i < N; i++)
                for (int j = 0; j < M; j++)
                    _matr[i, j] = a[i, j];
        }
        public Matrix(string namefile)
        {
            StreamReader fs = new StreamReader(namefile);
            var modelInfo = fs.ReadToEnd().Split(new string[] { " ", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            N = Convert.ToInt32(modelInfo[0]);
            M = Convert.ToInt32(modelInfo[1]);
            _matr = new double[N, M];
            int k = 3;
            for (var i = 0; i < N; i++)
            {
                for (var j = 0; j < M; j++)
                {
                    _matr[i, j] = Convert.ToInt32(modelInfo[k++]);
                }
            }
            modelInfo.RemoveRange(0, modelInfo.Count);
        }
        public Matrix(double[,] a, int N, int M)
        {
            _matr = new double[N, M];
            this.N = N;
            this.M = M;
            for (int i = 0; i < N; i++)
                for (int j = 0; j < M; j++)
                    _matr[i, j] = a[i, j];
        }

        public void Show()
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                    Console.Write(_matr[i, j] + " ");
                Console.WriteLine();
            }
        }

        private static Matrix readFromFile(string namefile)
        {
            return new Matrix(namefile);
        }

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
    }
}
