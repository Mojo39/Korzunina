using Korzunina.Logic;
using System;

namespace Korzunina.Visualization.DrawLogic
{
    class AffineTransformation
    {
        /// <summary>
        /// Перенос на вектор
        /// </summary>
        private static Matrix Ta(double x, double y, double z)
        {
            Matrix c = new Matrix(4, 4);
            c[0, 3] = x;
            c[1, 3] = y;
            c[2, 3] = z;
            return c;
        }
        private static Matrix S(double kx, double ky, double kz)
        {
            Matrix c = new Matrix(4, 4);
            c[0, 0] = kx;
            c[1, 1] = ky;
            c[2, 2] = kz;
            return c;
        }
        private static Matrix M(int mx, int my, int mz)
        {
            Matrix c = new Matrix(4, 4);
            c[0, 0] = mx;
            c[1, 1] = my;
            c[2, 2] = mz;
            return c;
        }
        //flag = 0 - вокруг оси у, 1 - вокруг оси z, 2 - вокруг оси x
        private static Matrix R(double Phi, int flag)
        {
            double cos = Math.Cos(Phi / 180 * Math.PI);
            double sin = Math.Sin(Phi / 180 * Math.PI);
            Matrix r = new Matrix(4, 4);
            switch (flag)
            {
                case 0:
                    r = new Matrix(new double[,] {{ cos, 0, sin, 0 },
                                                  {  0 , 1,  1 , 0 },
                                                  {-sin, 0, cos, 0 },
                                                  {  0 , 0,  0 , 1 }});
                    break;

                case 1:
                    r = new Matrix(new double[,] {{ 1,  0 ,  0 , 0 },
                                                  { 0, cos,-sin, 0 },
                                                  { 0, sin, cos, 0 },
                                                  { 0,  0 ,  0 , 1 }});
                    break;

                case 2:
                    r = new Matrix(new double[,] {{ 1,  0 ,  0 , 0 },
                                                  { 0, cos,-sin, 0 },
                                                  { 0, sin, cos, 0 },
                                                  { 0,  0 ,  0 , 1 }});
                    break;
                default:
                    break;
            }
            return r;
        }

        public static Matrix doTa(double x, double y, double z, Matrix U) => Ta(x, y, z) * U;

        // flag = 0 - вокруг оси у, 1 - вокруг оси z, 2 - вокруг оси x
        public static Matrix doR(double Phi, int flag, Matrix U) => R(Phi, flag) * U;

        public static Matrix doS(double kx, double ky, double kz, Matrix U) => S(kx, ky, kz) * U;

        public static Matrix doM(int mx, int my, int mz, Matrix U) => M(mx, my, mz) * U;
    }
}
