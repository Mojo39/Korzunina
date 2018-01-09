using System;
using System.Collections.Generic;
using System.Text;

namespace Korzunina.Logic
{
    public class Point
    {
        private double _x, _y, _z;

        public Point(double x, double y, double z)
        {
            this._x = x;
            this._y = y;
            this._z = z;
        }

        public double X
        {
            get { return _x; }
        }

        public double Y
        {
            get { return _y; }
        }

        public double Z
        {
            get { return _z; }
        }

        public static List<Point> ParseArray(double [] arr)
        {
            List<Point> points = new List<Point>();

            for(int i = 0; i + 2 < arr.Length; i+=3)
            {
                points.Add(new Point(arr[i], arr[i + 1], arr[i + 2]));
            }

            return points;
        }
    }
}
