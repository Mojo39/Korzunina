﻿using Korzunina.Logic;
using System;

namespace Korzunina.Visualization.DrawLogic
{
    class Camera
    {
        private Matrix transform;

        private double[] _Ov = new double[3];     // координаты точки экранной плоскости, расположенной напротив наблюдателя
        private double[] _N  = new double[3];     // вектор нормали к экранной плоскости
        private double[] _T  = new double[3];     // вектор, задающий вертикальное направление для наблюдателя
                           
        private double[] _iv = new double[3];      //видовые координаты
        private double[] _jv = new double[3];
        private double[] _kv = new double[3];

        public double D;                          // расстояние от наблюдателя до экрана

        public Camera(double[] a, double[] b, double[] c, double d) 
        {
            Update(a, b, c, d);
        }

        public Camera()
        {
            Update(new double[] { 4, 4, 0 }, new double[] { 1, -1, 1 }, new double[] { 0, 0, 1 }, 100);
        }

        public void UpdateD(double k)
        {
                D *= k;
                if (D < 5) D = 5;
                transform = MatrixTransformViewToProjec() * TransformWorldToView();
        }
        public void Update(double[] a, double[] b, double[] c, double d)
        {
            for (int i = 0; i < 3; i++)
            {
                _Ov[i] = a[i];
                _N[i] = b[i];
                _T[i] = c[i];
            }
            D = d;
            transform = MatrixTransformViewToProjec() * TransformWorldToView();
        }   

        private void CreatView() 
        {
            double[] mult = VectorWork.VectorMultiply(_T, _N);
            for (int i = 0; i < 3; i++)
            {
                _kv[i] = _N[i] / VectorWork.Norma(_N);
                _iv[i] =  mult[i] / VectorWork.Norma(mult);
            }
            _jv = VectorWork.VectorMultiply(_kv, _iv);
        }

        private Matrix TransformWorldToView()
        {
            CreatView();
            return new Matrix( new double[,] {
                                              { _iv[0], _iv[1], _iv[2], -(_Ov[0]*_iv[0]+_Ov[1]*_iv[1]+_Ov[2]*_iv[2]) },
                                              { _jv[0], _jv[1], _jv[2], -(_Ov[0]*_jv[0]+_Ov[1]*_jv[1]+_Ov[2]*_jv[2]) },
                                              { _kv[0], _kv[1], _kv[2], -(_Ov[0]*_kv[0]+_Ov[1]*_kv[1]+_Ov[2]*_kv[2]) },
                                              {     0,     0,     0,                        1                        }});
        }

        private Matrix MatrixTransformViewToProjec() 
        {
            Matrix TransformMatrix = new Matrix(3, 4);
            TransformMatrix[2, 3] = 1;
            TransformMatrix[2, 2] = -1 / D;
            return TransformMatrix;
        }

        public Matrix CreatProjectMatrix(Matrix U) 
        {
            return transform * U;
        }
    }
}
