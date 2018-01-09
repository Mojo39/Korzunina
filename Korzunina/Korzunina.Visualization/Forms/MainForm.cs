using Korzunina.Logic;
using Korzunina.Visualization.DrawLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Korzunina.Visualization
{
    public partial class Form1 : Form
    {
        private Draw _draw = new Draw();
        private Camera _camera = new Camera();
        private Matrix map = new Matrix("..\\..\\map.txt");               // начальная карта вершин
        //private Matrix edges = new Matrix("..\\..\\edges.txt");         
        private Matrix edges;                                             // карта ребер
        private Matrix verges = new Matrix("..\\..\\verges.txt");         // карта граней
        private bool _move = false;
        public Form1()
        {
            InitializeComponent();
            Buf();
        }

        private void Buf()
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            _move = true;
            _draw.X_Pos = e.X;
            _draw.Y_Pos = e.Y;
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_move)
            {
                _draw.Move(e);
                Invalidate();
            }
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            _move = false;
            this.Invalidate();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            _draw.W = ClientSize.Width;
            _draw.H = ClientSize.Height;
            _draw.SetResolution();
            this.Invalidate();
        }
    }
}
