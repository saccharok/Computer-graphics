namespace cg_lr2
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
            this.buttonLoad = new System.Windows.Forms.Button();
            this.picture = new System.Windows.Forms.PictureBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonWarnok = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(550, 12);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(238, 49);
            this.buttonLoad.TabIndex = 0;
            this.buttonLoad.Text = "Загрузка объекта";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // picture
            // 
            this.picture.Location = new System.Drawing.Point(12, 27);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(500, 500);
            this.picture.TabIndex = 1;
            this.picture.TabStop = false;
            this.picture.Paint += new System.Windows.Forms.PaintEventHandler(this.picture_Paint);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(672, 67);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(116, 49);
            this.buttonClear.TabIndex = 3;
            this.buttonClear.Text = "Очистка экрана";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonWarnok
            // 
            this.buttonWarnok.Location = new System.Drawing.Point(550, 67);
            this.buttonWarnok.Name = "buttonWarnok";
            this.buttonWarnok.Size = new System.Drawing.Size(116, 49);
            this.buttonWarnok.TabIndex = 4;
            this.buttonWarnok.Text = "Алгоритм Варнока";
            this.buttonWarnok.UseVisualStyleBackColor = true;
            this.buttonWarnok.Click += new System.EventHandler(this.buttonWarnok_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 539);
            this.Controls.Add(this.buttonWarnok);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.picture);
            this.Controls.Add(this.buttonLoad);
            this.Name = "Form1";
            this.Text = "Удаление невидимых линий";
            ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.PictureBox picture;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonWarnok;
    }
}

