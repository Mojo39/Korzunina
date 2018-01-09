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
        private Matrix _map = TestData.RealMapDots;
        private Dictionary<int, List<int>> _adjacentPointsDic = TestData.AdjacentPointsDic;

        private bool _move = false;
        public Form1()
        {
            InitializeComponent();
            Buf();

            _draw.W = ClientSize.Width;
            _draw.H = ClientSize.Height;
            _draw.setPixelH();

            MouseWheel += Form1_MouseWheel;
        }

        private void Buf()
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            _draw.W = ClientSize.Width;
            _draw.H = ClientSize.Height;
            _draw.drawAxis(sender, e, _camera);
            _draw.drawModel(sender, e, _camera.CreatProjectMatrix(_map), _adjacentPointsDic);
        }

        #region Перетаскивание рабочего поля

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            _move = true;
            _draw.X_Pos = e.X;
            _draw.Y_Pos = e.Y;
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_move)
                return;

            _draw.Move(e);
            Invalidate();

        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            _move = false;
            this.Invalidate();
        }

        #endregion

        private void Form1_Resize(object sender, EventArgs e)
        {
            _draw.W = ClientSize.Width;
            _draw.H = ClientSize.Height;
            _draw.SetResolution();
            this.Invalidate();
        }

        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0) _camera.UpdateD(0.9);
            else _camera.UpdateD(1.1);
            Invalidate();
        }
    }
}
