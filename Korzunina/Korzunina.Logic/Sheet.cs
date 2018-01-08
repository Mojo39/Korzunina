using System;
using System.Collections.Generic;

namespace Korzunina.Logic
{
    public class Sheet
    {
        private const int tetrahedronCount = 6;

        private double hx, hy, hz;
        private int Nx, Ny, Nz;
        private int ZYPointsCount;

        public int pointsCount { get; private set; }
        public int BlocksCount { get; private set; }

        private List<Point> coords;
        
        public int BandWidth { get; private set; }
        public double Volume { get; private set; }

        public List<Point> Coordinates
        {
            get { return coords; }           
        }

        //Матрица смежности
        public int[,] AdjacencyMatrix { get; private set; }

        //Соседние узлы каждой точки
        public Dictionary<int, List<int>> AdjacentPoints { get; private set; }
        
        public Sheet(double hx, double hy, double hz, int Nx, int Ny, int Nz)
        {
            this.hx = hx;
            this.hy = hy;
            this.hz = hz;
            this.Nx = Nx;
            this.Ny = Ny;
            this.Nz = Nz;

            pointsCount = (Nx + 1) * (Ny + 1) * (Nz + 1);
            BlocksCount = Nx * Ny * Nz;
            ZYPointsCount = (Ny + 1) * (Nz + 1);
            Volume = hx * hy * hz * BlocksCount;

            coords = new List<Point>();
            AdjacencyMatrix = new int[BlocksCount * tetrahedronCount, 4];
            AdjacentPoints = new Dictionary<int, List<int>>(pointsCount);

            CalculatePointsAndAdjacencyMatrix();
            CalculateBandWidth();
        }      

        private void CalculatePointsAndAdjacencyMatrix()
        {
            int pointNumber = 0;
            int blockNumber = 0;

            for (int xIter = 0; xIter <= Nx; xIter++)
            {
                for (int yIter = 0; yIter <= Ny; yIter++)
                {
                    for (int zIter = 0; zIter <= Nz; zIter++)
                    {
                        coords.Add(new Point(hx * xIter, hy * yIter, hz * zIter));

                        if (zIter != Nz && yIter != Ny && xIter != Nx)
                        {
                            AddBlockToAdjacencyMatrix(pointNumber, blockNumber);
                            blockNumber++;
                        }

                        pointNumber++;
                    }
                }
            }
        }

        private void AddBlockToAdjacencyMatrix(int pointNumber, int blockNumber)
        {
            int i, j, l, k, p, q, s, r;

            p = pointNumber;    q = ZYPointsCount + p;
            i = p + 1;          j = ZYPointsCount + i;
            s = p + (Nz + 1);   r = ZYPointsCount + s;
            l = s + 1;          k = ZYPointsCount + l;

            int row = blockNumber * tetrahedronCount;

            AdjacencyMatrix[row, 0] = j; AdjacencyMatrix[row, 1] = l; AdjacencyMatrix[row, 2] = k; AdjacencyMatrix[row, 3] = q; ++row;
            AdjacencyMatrix[row, 0] = s; AdjacencyMatrix[row, 1] = r; AdjacencyMatrix[row, 2] = k; AdjacencyMatrix[row, 3] = q; ++row;
            AdjacencyMatrix[row, 0] = s; AdjacencyMatrix[row, 1] = k; AdjacencyMatrix[row, 2] = l; AdjacencyMatrix[row, 3] = q; ++row;
            AdjacencyMatrix[row, 0] = i; AdjacencyMatrix[row, 1] = l; AdjacencyMatrix[row, 2] = j; AdjacencyMatrix[row, 3] = p; ++row;
            AdjacencyMatrix[row, 0] = q; AdjacencyMatrix[row, 1] = j; AdjacencyMatrix[row, 2] = l; AdjacencyMatrix[row, 3] = p; ++row;
            AdjacencyMatrix[row, 0] = q; AdjacencyMatrix[row, 1] = l; AdjacencyMatrix[row, 2] = s; AdjacencyMatrix[row, 3] = p;

            AddAdjecentPoints(i, j, l, k, p, q, s, r);
        }

        private void AddAdjecentPoints(int i, int j, int l, int k, int p, int q, int s, int r)
        {
            ConnectPoints(p, new int[] { q, s, i });
            ConnectPoints(i, new int[] { l, j });
            ConnectPoints(s, new int[] { l, r });
            ConnectPoints(r, new int[] { q, k });
            ConnectPoints(l, new int[] { k });
            ConnectPoints(j, new int[] { k });
        }

        private void ConnectPoints(int point, int[] adjecentPoints)
        {
            List<int> points = new List<int>(6);
            if (AdjacentPoints.ContainsKey(point))
                AdjacentPoints.TryGetValue(point, out points);
            else AdjacentPoints.Add(point, null);

            for (int i = 0; i < adjecentPoints.Length; i++)
            {
                if (!points.Contains(adjecentPoints[i]))
                    points.Add(adjecentPoints[i]);
            }         

            points.TrimExcess();
            AdjacentPoints[point] = points;
        }

        private void CalculateBandWidth()
        {
            int maxDifferenceInMatrix = 0;

            for (int i = 0; i < AdjacencyMatrix.GetLength(0); i++)
            {
                int maxDifferenceInRow = 0;

                for (int j = 0; j < AdjacencyMatrix.GetLength(1); j++)
                {                   
                    for (int k = j+1; k < AdjacencyMatrix.GetLength(1); k++)
                    {
                        if (Math.Abs(AdjacencyMatrix[i, j] - AdjacencyMatrix[i, k]) > maxDifferenceInRow)
                        {
                            maxDifferenceInRow = Math.Abs(AdjacencyMatrix[i, j] - AdjacencyMatrix[i, k]);
                        }
                    }
                }

                if (maxDifferenceInRow > maxDifferenceInMatrix)
                {
                    maxDifferenceInMatrix = maxDifferenceInRow;
                }
            }

            BandWidth = maxDifferenceInMatrix;
        }
    }
}
