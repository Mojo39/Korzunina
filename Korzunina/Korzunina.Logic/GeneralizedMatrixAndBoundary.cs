using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Korzunina.Logic
{
    public class GeneralizedMatrixAndBoundary
    {
        //данные из других классов
        private int N; //кол-во узлов 
        private int L; //ширина ленты 
        private int[,] adj; //матрица смежности 
        private List<double[,]> Ke; //список матриц для каждого тетраэдра


        private double[,] band; //матрица для хранения ленты

        private double[] rightPart; //вектор правой части

        public double[,] BandMatrix 
        {
            get { return band; }
        }

        public double[] RightPart 
        {
            get { return rightPart; }
        }

        public GeneralizedMatrixAndBoundary(Sheet sheet, CreateListOfKe listofKe, List<double[]> boundCond)
        {
            N = sheet.PointsCount; //получаем кол-во узлов
            L = sheet.BandWidth; //получаем ширину ленты
            adj = sheet.AdjacencyMatrix; //получаем матрицу смежности
            Ke = listofKe.ListOfMatrixKe; //получаем список матриц K^e для каждого тетраэдра

            //формируем матрицу-ленту
            CreateGeneralizedMatrix();

            //учет граничных условий
            BoundaryCondition(boundCond);
        }


        private void CreateGeneralizedMatrix() //формирование ленты
        {
            band = new double[3 * N, 2 * L - 1];
            for (int i = 0; i < 3 * N; i++)
            {
                for (int j = 0; j < 2 * L - 1; j++)
                {
                    band[i, j] = 0;
                }
            }

            //считываем матрицу K^e для каждого тетраэдра
            int count = 0;
            foreach (var n in Ke)
            {
                //заполняем матрицу-ленту
                for (int row_n = 0; row_n <= 3; row_n++)
                {
                    for (int row_k = 0; row_k <= 2; row_k++)
                    {
                        int row = 3 * row_n + row_k; //номер строки в матрице K^e для тетраэдра
                        int rowNew = 3 * adj[count, row_n] + row_k; //номер строки в матрице-ленте (совпадает с обобщ. матрицей)
                        //разбиваем строку на 4 блока под каждый номер узла i,j,k,p
                        for (int col_n = 0; col_n <= 3; col_n++)
                        {
                            for (int col_k = 0; col_k <= 2; col_k++)
                            {
                                int col = 3 * col_n + col_k; //номер столбца в матрице K^e для тетраэдра 
                                int colNew = 3 * adj[count, col_n] + col_k - rowNew + L-1; //номер столбца в матрице-ленте
                                //записываем соответствующий элемент в матрицу-ленту
                                band[rowNew, colNew] += n[row, col];
                            }
                        }
                    }
                }
                count++; //увеличиваем счетчик тетраэдров
            }
        }

        private void BoundaryCondition(List<double[]> boundCond) //учет граничных условий
        {
            rightPart = new double[3 * N]; //вектор правой части
            for (int i = 0; i < 3 * N; i++)
            {
                rightPart[i] = 0;
            }

            //считываем по порядку граничные условия из списка
            foreach (var n in boundCond)
            {
                int note = (int)n[0]; //номер узла

                //учитываем граничное условие по каждой координате x,y,z
                for (int count = 0; count <= 2; count++)
                {
                    int colNew = 3 * note + count; //номер столбца в обобщенной матрице

                    //вносим изменения в правую часть (кроме элемента с номером colNew)
                    for (int i = 0; i < 3 * N; i++)
                    {
                        if (i != colNew)
                        {
                            bool flag = true;
                            //проверяем, чтобы не попало в область i>=L && j<3N-L || i<3N-L && j>=L (в обобщенной матрице)
                            if ((i >= L && colNew < 3*N-L) || (i < 3*N-L && colNew >= L))
                            {
                                flag = false;
                            }
                            if (flag)
                            {
                                rightPart[i] -= band[i, colNew - i + L - 1] * n[count + 1];
                            }                        
                        }
                    }

                    //обнуляем столбец
                    for (int i = 0; i < 3 * N; i++)
                    {
                        bool flag = true;
                        //проверяем, чтобы не попало в область i>=L && j<3N-L || i<3N-L && j>=L (в обощенной матрице)
                        if ((i >= L && colNew < 3 * N - L) || (i < 3 * N - L && colNew >= L))
                        {
                            flag = false;
                        }
                        if (flag)
                        {
                            band[i, colNew - i + L - 1] = 0;
                        }                     
                    }

                    //заполняем значение из вектора перемещений
                    band[colNew, L-1] = n[count + 1]; 
                }
            }
        }
    }
}
