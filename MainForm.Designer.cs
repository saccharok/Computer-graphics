namespace kg_lab1
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.buttonDeffaultPosition = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.MoveTextBox = new System.Windows.Forms.TextBox();
            this.MovePlusX = new System.Windows.Forms.Button();
            this.MovePlusY = new System.Windows.Forms.Button();
            this.MovePlusZ = new System.Windows.Forms.Button();
            this.MoveMinusZ = new System.Windows.Forms.Button();
            this.MoveMinusY = new System.Windows.Forms.Button();
            this.MoveMinusX = new System.Windows.Forms.Button();
            this.RotateTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.RotateLeftZ = new System.Windows.Forms.Button();
            this.RotateLeftY = new System.Windows.Forms.Button();
            this.RotateLeftX = new System.Windows.Forms.Button();
            this.RotateRightZ = new System.Windows.Forms.Button();
            this.RotateRightY = new System.Windows.Forms.Button();
            this.RotateRightX = new System.Windows.Forms.Button();
            this.MirrorXY = new System.Windows.Forms.Button();
            this.MirrorXZ = new System.Windows.Forms.Button();
            this.MirrorYZ = new System.Windows.Forms.Button();
            this.Stretch = new System.Windows.Forms.Button();
            this.Clench = new System.Windows.Forms.Button();
            this.taskOX = new System.Windows.Forms.Button();
            this.taskOY = new System.Windows.Forms.Button();
            this.taskOZ = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonDeffaultPosition
            // 
            this.buttonDeffaultPosition.Location = new System.Drawing.Point(13, 12);
            this.buttonDeffaultPosition.Name = "buttonDeffaultPosition";
            this.buttonDeffaultPosition.Size = new System.Drawing.Size(183, 30);
            this.buttonDeffaultPosition.TabIndex = 0;
            this.buttonDeffaultPosition.Text = "Начльная позиция";
            this.buttonDeffaultPosition.UseVisualStyleBackColor = true;
            this.buttonDeffaultPosition.Click += new System.EventHandler(this.buttonDeffaultPosition_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Перемещение";
            // 
            // MoveTextBox
            // 
            this.MoveTextBox.Location = new System.Drawing.Point(118, 45);
            this.MoveTextBox.Name = "MoveTextBox";
            this.MoveTextBox.Size = new System.Drawing.Size(78, 22);
            this.MoveTextBox.TabIndex = 2;
            this.MoveTextBox.Text = "10";
            // 
            // MovePlusX
            // 
            this.MovePlusX.Location = new System.Drawing.Point(16, 73);
            this.MovePlusX.Name = "MovePlusX";
            this.MovePlusX.Size = new System.Drawing.Size(50, 30);
            this.MovePlusX.TabIndex = 3;
            this.MovePlusX.Text = "X+";
            this.MovePlusX.UseVisualStyleBackColor = true;
            this.MovePlusX.Click += new System.EventHandler(this.MovePlusX_Click);
            // 
            // MovePlusY
            // 
            this.MovePlusY.Location = new System.Drawing.Point(81, 73);
            this.MovePlusY.Name = "MovePlusY";
            this.MovePlusY.Size = new System.Drawing.Size(50, 30);
            this.MovePlusY.TabIndex = 4;
            this.MovePlusY.Text = "Y+";
            this.MovePlusY.UseVisualStyleBackColor = true;
            this.MovePlusY.Click += new System.EventHandler(this.MovePlusY_Click);
            // 
            // MovePlusZ
            // 
            this.MovePlusZ.Location = new System.Drawing.Point(146, 73);
            this.MovePlusZ.Name = "MovePlusZ";
            this.MovePlusZ.Size = new System.Drawing.Size(50, 30);
            this.MovePlusZ.TabIndex = 5;
            this.MovePlusZ.Text = "Z+";
            this.MovePlusZ.UseVisualStyleBackColor = true;
            this.MovePlusZ.Click += new System.EventHandler(this.MovePlusZ_Click);
            // 
            // MoveMinusZ
            // 
            this.MoveMinusZ.Location = new System.Drawing.Point(146, 109);
            this.MoveMinusZ.Name = "MoveMinusZ";
            this.MoveMinusZ.Size = new System.Drawing.Size(50, 30);
            this.MoveMinusZ.TabIndex = 8;
            this.MoveMinusZ.Text = "Z-";
            this.MoveMinusZ.UseVisualStyleBackColor = true;
            this.MoveMinusZ.Click += new System.EventHandler(this.MoveMinusZ_Click);
            // 
            // MoveMinusY
            // 
            this.MoveMinusY.Location = new System.Drawing.Point(81, 109);
            this.MoveMinusY.Name = "MoveMinusY";
            this.MoveMinusY.Size = new System.Drawing.Size(50, 30);
            this.MoveMinusY.TabIndex = 7;
            this.MoveMinusY.Text = "Y-";
            this.MoveMinusY.UseVisualStyleBackColor = true;
            this.MoveMinusY.Click += new System.EventHandler(this.MoveMinusY_Click);
            // 
            // MoveMinusX
            // 
            this.MoveMinusX.Location = new System.Drawing.Point(16, 109);
            this.MoveMinusX.Name = "MoveMinusX";
            this.MoveMinusX.Size = new System.Drawing.Size(50, 30);
            this.MoveMinusX.TabIndex = 6;
            this.MoveMinusX.Text = "X-";
            this.MoveMinusX.UseVisualStyleBackColor = true;
            this.MoveMinusX.Click += new System.EventHandler(this.MoveMinusX_Click);
            // 
            // RotateTextBox
            // 
            this.RotateTextBox.Location = new System.Drawing.Point(118, 145);
            this.RotateTextBox.Name = "RotateTextBox";
            this.RotateTextBox.Size = new System.Drawing.Size(78, 22);
            this.RotateTextBox.TabIndex = 10;
            this.RotateTextBox.Text = "45";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Вращение";
            // 
            // RotateLeftZ
            // 
            this.RotateLeftZ.Location = new System.Drawing.Point(146, 212);
            this.RotateLeftZ.Name = "RotateLeftZ";
            this.RotateLeftZ.Size = new System.Drawing.Size(50, 30);
            this.RotateLeftZ.TabIndex = 16;
            this.RotateLeftZ.Text = "Z-l";
            this.RotateLeftZ.UseVisualStyleBackColor = true;
            this.RotateLeftZ.Click += new System.EventHandler(this.RotateLeftZ_Click);
            // 
            // RotateLeftY
            // 
            this.RotateLeftY.Location = new System.Drawing.Point(81, 212);
            this.RotateLeftY.Name = "RotateLeftY";
            this.RotateLeftY.Size = new System.Drawing.Size(50, 30);
            this.RotateLeftY.TabIndex = 15;
            this.RotateLeftY.Text = "Y-l";
            this.RotateLeftY.UseVisualStyleBackColor = true;
            this.RotateLeftY.Click += new System.EventHandler(this.RotateLeftY_Click);
            // 
            // RotateLeftX
            // 
            this.RotateLeftX.Location = new System.Drawing.Point(16, 212);
            this.RotateLeftX.Name = "RotateLeftX";
            this.RotateLeftX.Size = new System.Drawing.Size(50, 30);
            this.RotateLeftX.TabIndex = 14;
            this.RotateLeftX.Text = "X-l";
            this.RotateLeftX.UseVisualStyleBackColor = true;
            this.RotateLeftX.Click += new System.EventHandler(this.RotateLeftX_Click);
            // 
            // RotateRightZ
            // 
            this.RotateRightZ.Location = new System.Drawing.Point(146, 176);
            this.RotateRightZ.Name = "RotateRightZ";
            this.RotateRightZ.Size = new System.Drawing.Size(50, 30);
            this.RotateRightZ.TabIndex = 13;
            this.RotateRightZ.Text = "Z-r";
            this.RotateRightZ.UseVisualStyleBackColor = true;
            this.RotateRightZ.Click += new System.EventHandler(this.RotateRightZ_Click);
            // 
            // RotateRightY
            // 
            this.RotateRightY.Location = new System.Drawing.Point(81, 176);
            this.RotateRightY.Name = "RotateRightY";
            this.RotateRightY.Size = new System.Drawing.Size(50, 30);
            this.RotateRightY.TabIndex = 12;
            this.RotateRightY.Text = "Y-r";
            this.RotateRightY.UseVisualStyleBackColor = true;
            this.RotateRightY.Click += new System.EventHandler(this.RotateRightY_Click);
            // 
            // RotateRightX
            // 
            this.RotateRightX.Location = new System.Drawing.Point(16, 176);
            this.RotateRightX.Name = "RotateRightX";
            this.RotateRightX.Size = new System.Drawing.Size(50, 30);
            this.RotateRightX.TabIndex = 11;
            this.RotateRightX.Text = "X-r";
            this.RotateRightX.UseVisualStyleBackColor = true;
            this.RotateRightX.Click += new System.EventHandler(this.RotateRightX_Click);
            // 
            // MirrorXY
            // 
            this.MirrorXY.Location = new System.Drawing.Point(16, 248);
            this.MirrorXY.Name = "MirrorXY";
            this.MirrorXY.Size = new System.Drawing.Size(183, 30);
            this.MirrorXY.TabIndex = 17;
            this.MirrorXY.Text = "Отражение OXY";
            this.MirrorXY.UseVisualStyleBackColor = true;
            this.MirrorXY.Click += new System.EventHandler(this.MirrorXY_Click);
            // 
            // MirrorXZ
            // 
            this.MirrorXZ.Location = new System.Drawing.Point(16, 284);
            this.MirrorXZ.Name = "MirrorXZ";
            this.MirrorXZ.Size = new System.Drawing.Size(183, 30);
            this.MirrorXZ.TabIndex = 18;
            this.MirrorXZ.Text = "Отражение OXZ";
            this.MirrorXZ.UseVisualStyleBackColor = true;
            this.MirrorXZ.Click += new System.EventHandler(this.MirrorXZ_Click);
            // 
            // MirrorYZ
            // 
            this.MirrorYZ.Location = new System.Drawing.Point(16, 320);
            this.MirrorYZ.Name = "MirrorYZ";
            this.MirrorYZ.Size = new System.Drawing.Size(183, 30);
            this.MirrorYZ.TabIndex = 19;
            this.MirrorYZ.Text = "Отражение OYZ";
            this.MirrorYZ.UseVisualStyleBackColor = true;
            this.MirrorYZ.Click += new System.EventHandler(this.MirrorYZ_Click);
            // 
            // Stretch
            // 
            this.Stretch.Location = new System.Drawing.Point(16, 356);
            this.Stretch.Name = "Stretch";
            this.Stretch.Size = new System.Drawing.Size(183, 30);
            this.Stretch.TabIndex = 20;
            this.Stretch.Text = "Растяжение";
            this.Stretch.UseVisualStyleBackColor = true;
            this.Stretch.Click += new System.EventHandler(this.Stretch_Click);
            // 
            // Clench
            // 
            this.Clench.Location = new System.Drawing.Point(16, 392);
            this.Clench.Name = "Clench";
            this.Clench.Size = new System.Drawing.Size(183, 30);
            this.Clench.TabIndex = 21;
            this.Clench.Text = "Сжатие";
            this.Clench.UseVisualStyleBackColor = true;
            this.Clench.Click += new System.EventHandler(this.Clench_Click);
            // 
            // taskOX
            // 
            this.taskOX.Location = new System.Drawing.Point(16, 428);
            this.taskOX.Name = "taskOX";
            this.taskOX.Size = new System.Drawing.Size(183, 30);
            this.taskOX.TabIndex = 22;
            this.taskOX.Text = "По спирали OX";
            this.taskOX.UseVisualStyleBackColor = true;
            this.taskOX.Click += new System.EventHandler(this.taskOX_Click);
            // 
            // taskOY
            // 
            this.taskOY.Location = new System.Drawing.Point(16, 464);
            this.taskOY.Name = "taskOY";
            this.taskOY.Size = new System.Drawing.Size(183, 30);
            this.taskOY.TabIndex = 23;
            this.taskOY.Text = "По спирали OY";
            this.taskOY.UseVisualStyleBackColor = true;
            this.taskOY.Click += new System.EventHandler(this.taskOY_Click);
            // 
            // taskOZ
            // 
            this.taskOZ.Location = new System.Drawing.Point(16, 500);
            this.taskOZ.Name = "taskOZ";
            this.taskOZ.Size = new System.Drawing.Size(183, 30);
            this.taskOZ.TabIndex = 24;
            this.taskOZ.Text = "По спирали OZ";
            this.taskOZ.UseVisualStyleBackColor = true;
            this.taskOZ.Click += new System.EventHandler(this.taskOZ_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 572);
            this.Controls.Add(this.taskOZ);
            this.Controls.Add(this.taskOY);
            this.Controls.Add(this.taskOX);
            this.Controls.Add(this.Clench);
            this.Controls.Add(this.Stretch);
            this.Controls.Add(this.MirrorYZ);
            this.Controls.Add(this.MirrorXZ);
            this.Controls.Add(this.MirrorXY);
            this.Controls.Add(this.RotateLeftZ);
            this.Controls.Add(this.RotateLeftY);
            this.Controls.Add(this.RotateLeftX);
            this.Controls.Add(this.RotateRightZ);
            this.Controls.Add(this.RotateRightY);
            this.Controls.Add(this.RotateRightX);
            this.Controls.Add(this.RotateTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MoveMinusZ);
            this.Controls.Add(this.MoveMinusY);
            this.Controls.Add(this.MoveMinusX);
            this.Controls.Add(this.MovePlusZ);
            this.Controls.Add(this.MovePlusY);
            this.Controls.Add(this.MovePlusX);
            this.Controls.Add(this.MoveTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonDeffaultPosition);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Афинные преобразования";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonDeffaultPosition;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox MoveTextBox;
        private System.Windows.Forms.Button MovePlusX;
        private System.Windows.Forms.Button MovePlusY;
        private System.Windows.Forms.Button MovePlusZ;
        private System.Windows.Forms.Button MoveMinusZ;
        private System.Windows.Forms.Button MoveMinusY;
        private System.Windows.Forms.Button MoveMinusX;
        private System.Windows.Forms.TextBox RotateTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button RotateLeftZ;
        private System.Windows.Forms.Button RotateLeftY;
        private System.Windows.Forms.Button RotateLeftX;
        private System.Windows.Forms.Button RotateRightZ;
        private System.Windows.Forms.Button RotateRightY;
        private System.Windows.Forms.Button RotateRightX;
        private System.Windows.Forms.Button MirrorXY;
        private System.Windows.Forms.Button MirrorXZ;
        private System.Windows.Forms.Button MirrorYZ;
        private System.Windows.Forms.Button Stretch;
        private System.Windows.Forms.Button Clench;
        private System.Windows.Forms.Button taskOX;
        private System.Windows.Forms.Button taskOY;
        private System.Windows.Forms.Button taskOZ;
    }
}

