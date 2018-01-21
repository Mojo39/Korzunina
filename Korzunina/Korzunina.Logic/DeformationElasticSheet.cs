using System.Collections.Generic;

namespace Korzunina.Logic
{
    public static class DeformationElasticSheet
    {
        public static Matrix Deformation(Sheet sheet, List<double[]> boundCond)
        {
            CreateListOfKe cloke = new CreateListOfKe(sheet);

            List<double[,]> KeList = cloke.ListOfMatrixKe;

            GeneralizedMatrixAndBoundary gmab = new GeneralizedMatrixAndBoundary(sheet, cloke, boundCond);

            int rowLength = gmab.GeneralMatrix.GetLength(0);
            int colLength = gmab.GeneralMatrix.GetLength(1);
            double[] solution = Cholesky.Solve(gmab.BandMatrix, gmab.RightPart);

            for (int i = 0; i < solution.Length; i++)
            {
                if (i == 0)
                {
                    solution[i] = sheet.Coordinates[0].X + solution[i];
                }
                else if (i % 3 == 0)
                {
                    int pointnumber = i / 3;
                    solution[i] = sheet.Coordinates[pointnumber].X + solution[i];
                }
                else if (i % 3 == 1)
                {
                    int pointnumber = i / 3;
                    solution[i] = sheet.Coordinates[pointnumber].Y + solution[i];
                }
                else
                {
                    int pointnumber = i / 3;
                    solution[i] = sheet.Coordinates[pointnumber].Z + solution[i];
                }
            }

            List<Point> points = Point.ParseArray(solution);

            return new Matrix(points);
        }

    }
}
