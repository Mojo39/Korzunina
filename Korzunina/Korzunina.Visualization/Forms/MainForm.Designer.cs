namespace Korzunina.Visualization
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblMaxMinValueNud = new System.Windows.Forms.Label();
            this.lbPoints = new System.Windows.Forms.ListBox();
            this.btnDelPoint = new System.Windows.Forms.Button();
            this.btnAddPoint = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.nudPoint = new System.Windows.Forms.NumericUpDown();
            this.tbZ = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnTransformation = new System.Windows.Forms.Button();
            this.tbY = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbX = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.cbR = new System.Windows.Forms.ComboBox();
            this.tbR = new System.Windows.Forms.TextBox();
            this.btnR = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPoint)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblMaxMinValueNud);
            this.groupBox1.Controls.Add(this.lbPoints);
            this.groupBox1.Controls.Add(this.btnDelPoint);
            this.groupBox1.Controls.Add(this.btnAddPoint);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.nudPoint);
            this.groupBox1.Controls.Add(this.tbZ);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.btnTransformation);
            this.groupBox1.Controls.Add(this.tbY);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.tbX);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.cbR);
            this.groupBox1.Controls.Add(this.tbR);
            this.groupBox1.Controls.Add(this.btnR);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(756, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 499);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Действия";
            // 
            // lblMaxMinValueNud
            // 
            this.lblMaxMinValueNud.AutoSize = true;
            this.lblMaxMinValueNud.Location = new System.Drawing.Point(34, 169);
            this.lblMaxMinValueNud.Name = "lblMaxMinValueNud";
            this.lblMaxMinValueNud.Size = new System.Drawing.Size(35, 13);
            this.lblMaxMinValueNud.TabIndex = 51;
            this.lblMaxMinValueNud.Text = "label3";
            // 
            // lbPoints
            // 
            this.lbPoints.FormattingEnabled = true;
            this.lbPoints.Location = new System.Drawing.Point(6, 232);
            this.lbPoints.Name = "lbPoints";
            this.lbPoints.Size = new System.Drawing.Size(110, 173);
            this.lbPoints.TabIndex = 50;
            this.lbPoints.SelectedIndexChanged += new System.EventHandler(this.lbPoints_SelectedIndexChanged);
            // 
            // btnDelPoint
            // 
            this.btnDelPoint.Location = new System.Drawing.Point(122, 261);
            this.btnDelPoint.Name = "btnDelPoint";
            this.btnDelPoint.Size = new System.Drawing.Size(71, 23);
            this.btnDelPoint.TabIndex = 49;
            this.btnDelPoint.Text = "Удалить";
            this.btnDelPoint.UseVisualStyleBackColor = true;
            this.btnDelPoint.Click += new System.EventHandler(this.btnDelPoint_Click);
            // 
            // btnAddPoint
            // 
            this.btnAddPoint.Location = new System.Drawing.Point(122, 232);
            this.btnAddPoint.Name = "btnAddPoint";
            this.btnAddPoint.Size = new System.Drawing.Size(72, 23);
            this.btnAddPoint.TabIndex = 48;
            this.btnAddPoint.Text = "Добавить";
            this.btnAddPoint.UseVisualStyleBackColor = true;
            this.btnAddPoint.Click += new System.EventHandler(this.btnAddPoint_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 47;
            this.label2.Text = "Точка:";
            // 
            // nudPoint
            // 
            this.nudPoint.Location = new System.Drawing.Point(107, 149);
            this.nudPoint.Name = "nudPoint";
            this.nudPoint.Size = new System.Drawing.Size(72, 20);
            this.nudPoint.TabIndex = 46;
            this.nudPoint.ValueChanged += new System.EventHandler(this.nudPoint_ValueChanged);
            // 
            // tbZ
            // 
            this.tbZ.Location = new System.Drawing.Point(156, 206);
            this.tbZ.Name = "tbZ";
            this.tbZ.Size = new System.Drawing.Size(32, 20);
            this.tbZ.TabIndex = 45;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(135, 209);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(15, 13);
            this.label9.TabIndex = 44;
            this.label9.Text = "z:";
            // 
            // btnTransformation
            // 
            this.btnTransformation.Location = new System.Drawing.Point(90, 419);
            this.btnTransformation.Name = "btnTransformation";
            this.btnTransformation.Size = new System.Drawing.Size(104, 23);
            this.btnTransformation.TabIndex = 43;
            this.btnTransformation.Text = "Деформировать";
            this.btnTransformation.UseVisualStyleBackColor = true;
            this.btnTransformation.Click += new System.EventHandler(this.btnTransformation_Click);
            // 
            // tbY
            // 
            this.tbY.Location = new System.Drawing.Point(90, 206);
            this.tbY.Name = "tbY";
            this.tbY.Size = new System.Drawing.Size(32, 20);
            this.tbY.TabIndex = 42;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(77, 209);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 13);
            this.label7.TabIndex = 41;
            this.label7.Text = "y:";
            // 
            // tbX
            // 
            this.tbX.Location = new System.Drawing.Point(37, 206);
            this.tbX.Name = "tbX";
            this.tbX.Size = new System.Drawing.Size(32, 20);
            this.tbX.TabIndex = 40;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 209);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 13);
            this.label6.TabIndex = 38;
            this.label6.Text = "x:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(86, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 13);
            this.label5.TabIndex = 39;
            this.label5.Text = "Перенос на вектор:";
            // 
            // btnReset
            // 
            this.btnReset.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnReset.Location = new System.Drawing.Point(3, 473);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(194, 23);
            this.btnReset.TabIndex = 36;
            this.btnReset.Text = "Сброс";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // cbR
            // 
            this.cbR.FormattingEnabled = true;
            this.cbR.Items.AddRange(new object[] {
            "Оси абсцисс",
            "Оси ординат",
            "Оси аппликат"});
            this.cbR.Location = new System.Drawing.Point(73, 41);
            this.cbR.Name = "cbR";
            this.cbR.Size = new System.Drawing.Size(121, 21);
            this.cbR.TabIndex = 35;
            // 
            // tbR
            // 
            this.tbR.Location = new System.Drawing.Point(62, 71);
            this.tbR.Name = "tbR";
            this.tbR.Size = new System.Drawing.Size(54, 20);
            this.tbR.TabIndex = 34;
            // 
            // btnR
            // 
            this.btnR.Location = new System.Drawing.Point(122, 68);
            this.btnR.Name = "btnR";
            this.btnR.Size = new System.Drawing.Size(75, 23);
            this.btnR.TabIndex = 32;
            this.btnR.Text = "Повернуть";
            this.btnR.UseVisualStyleBackColor = true;
            this.btnR.Click += new System.EventHandler(this.btnR_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(104, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Поворот вокруг:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 499);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Деформирование упругого прямоугольного листа";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPoint)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbR;
        private System.Windows.Forms.TextBox tbR;
        private System.Windows.Forms.Button btnR;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TextBox tbZ;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnTransformation;
        private System.Windows.Forms.TextBox tbY;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbX;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAddPoint;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudPoint;
        private System.Windows.Forms.Button btnDelPoint;
        private System.Windows.Forms.ListBox lbPoints;
        private System.Windows.Forms.Label lblMaxMinValueNud;
    }
}

