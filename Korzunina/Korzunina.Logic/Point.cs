tusing System;
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
    }
}
