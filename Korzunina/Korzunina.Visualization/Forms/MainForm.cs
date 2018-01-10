using Korzunina.Logic;
using Korzunina.Visualization.DrawLogic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Korzunina.Visualization
{
    public partial class Form1 : Form
    {
        private Draw _draw = new Draw();
        private Camera _camera = new Camera();

        private Matrix _A = new Matrix(4, 4);
        private Matrix _map = TestData.MapDots;
        private Dictionary<int, List<int>> _adjacentPointsDic = TestData.AdjacentPointsDic;

        private Dictionary<int, double[]> _deformationPoints = new Dictionary<int, double[]>();

        private bool _move = false;

        public Form1()
        {
            InitializeComponent();
            Buf();
            InitializeDrawParameters();
            InitilizeObject();

            nudPoint.Maximum = _map.M - 1;
            lblMaxMinValueNud.Text = string.Format("Индексы точек от {0} до {1}", nudPoint.Minimum, nudPoint.Maximum);

            MouseWheel += Form1_MouseWheel;
        }

        private void Buf()
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();
        }

        #region События

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            InitializeDrawParameters();
            _draw.drawAxis(sender, e, _camera);
            _draw.drawModel(sender, e, _camera.CreatProjectMatrix(_A * _map), _adjacentPointsDic);
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

        private void btnR_Click(object sender, EventArgs e)
        {
            double phi;

            if (!double.TryParse(tbR.Text.Trim(), out phi))
            {
                ShowMessage("Ошибка ввода значения угла поворота", icon: MessageBoxIcon.Warning);
                return;
            }

            if (cbR.SelectedIndex < 0)
            {
                ShowMessage("Выберите ось, относительно которой необходимо повернуть предмет", icon: MessageBoxIcon.Warning);
                return;
            }

            _A = AffineTransformation.doR(phi, cbR.SelectedIndex, _A);
            this.Invalidate();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            _A = new Matrix(4, 4);
            this.Invalidate();

            lbPoints.Items.Clear();
        }

        private void btnAddPoint_Click(object sender, EventArgs e)
        {
            int numberPoint = (int)nudPoint.Value;
            double[] vector = new double[4];
            vector[0] = numberPoint;

            if (!double.TryParse(tbX.Text, out vector[1]) || !double.TryParse(tbY.Text, out vector[2]) ||
                !double.TryParse(tbZ.Text, out vector[3]))
            {
                ShowMessage("Ошибка ввода значений коэффициентов вектора смещения", icon: MessageBoxIcon.Error);
                return;
            }

            List<double[]> a = new List<double[]>();

            if (_deformationPoints.ContainsKey(numberPoint))
                _deformationPoints[numberPoint] = vector;
            else
                _deformationPoints.Add(numberPoint, vector);

            lbPoints.DataSource = _deformationPoints.Values
                .Select(t => string.Format("{0}: ({1}, {2}, {3})", t[0], t[1], t[2], t[3]))
                .ToList();
        }

        private void btnDelPoint_Click(object sender, EventArgs e)
        {
            if (lbPoints.SelectedValue == null)
                return;

            string vectorStr = (string)lbPoints.SelectedValue;
            int numberPoint = int.Parse(vectorStr.Trim().Split(':')[0]);
            _deformationPoints.Remove(numberPoint);

            lbPoints.DataSource = _deformationPoints.Values
                .Select(t => string.Format("{0}: ({1},{2},{3})", t[0], t[1], t[2], t[3]))
                .ToList();
        }

        private void btnTransformation_Click(object sender, EventArgs e)
        {
            // Код, отвечаюзий за изменение листа
        }
        
        #endregion

        private void InitializeDrawParameters()
        {
            _draw.W = ClientSize.Width;
            _draw.H = ClientSize.Height;
            _draw.setPixelH();
        }

        private DialogResult ShowMessage(string text, MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.Information)
        {
            return MessageBox.Show(text, string.Empty, buttons, icon);
        }

        private void InitilizeObject()
        {
            Sheet sheet = new Sheet(1, 1, 1, 5, 5, 5);
            _adjacentPointsDic = sheet.AdjacentPoints;
            _map = new Matrix(sheet.Coordinates);
        }
    }
}
