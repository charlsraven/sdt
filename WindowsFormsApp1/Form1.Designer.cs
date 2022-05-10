namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btPoints = new System.Windows.Forms.Button();
            this.btParametrs = new System.Windows.Forms.Button();
            this.btMove = new System.Windows.Forms.Button();
            this.btClear = new System.Windows.Forms.Button();
            this.btCurve = new System.Windows.Forms.Button();
            this.btPolygone = new System.Windows.Forms.Button();
            this.btBeziers = new System.Windows.Forms.Button();
            this.btFilledCurve = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btPoints
            // 
            this.btPoints.Location = new System.Drawing.Point(19, 19);
            this.btPoints.Name = "btPoints";
            this.btPoints.Size = new System.Drawing.Size(141, 45);
            this.btPoints.TabIndex = 0;
            this.btPoints.Text = "Точки";
            this.btPoints.UseVisualStyleBackColor = true;
            // 
            // btParametrs
            // 
            this.btParametrs.Location = new System.Drawing.Point(19, 70);
            this.btParametrs.Name = "btParametrs";
            this.btParametrs.Size = new System.Drawing.Size(141, 45);
            this.btParametrs.TabIndex = 1;
            this.btParametrs.Text = "Параметры";
            this.btParametrs.UseVisualStyleBackColor = true;
            // 
            // btMove
            // 
            this.btMove.Location = new System.Drawing.Point(19, 121);
            this.btMove.Name = "btMove";
            this.btMove.Size = new System.Drawing.Size(141, 45);
            this.btMove.TabIndex = 2;
            this.btMove.Text = "Движение";
            this.btMove.UseVisualStyleBackColor = true;
            // 
            // btClear
            // 
            this.btClear.Location = new System.Drawing.Point(19, 172);
            this.btClear.Name = "btClear";
            this.btClear.Size = new System.Drawing.Size(141, 45);
            this.btClear.TabIndex = 3;
            this.btClear.Text = "Очистить";
            this.btClear.UseVisualStyleBackColor = true;
            // 
            // btCurve
            // 
            this.btCurve.Location = new System.Drawing.Point(19, 223);
            this.btCurve.Name = "btCurve";
            this.btCurve.Size = new System.Drawing.Size(141, 45);
            this.btCurve.TabIndex = 4;
            this.btCurve.Text = "Кривая";
            this.btCurve.UseVisualStyleBackColor = true;
            // 
            // btPolygone
            // 
            this.btPolygone.Location = new System.Drawing.Point(19, 274);
            this.btPolygone.Name = "btPolygone";
            this.btPolygone.Size = new System.Drawing.Size(141, 45);
            this.btPolygone.TabIndex = 5;
            this.btPolygone.Text = "Ломанная";
            this.btPolygone.UseVisualStyleBackColor = true;
            // 
            // btBeziers
            // 
            this.btBeziers.Location = new System.Drawing.Point(19, 325);
            this.btBeziers.Name = "btBeziers";
            this.btBeziers.Size = new System.Drawing.Size(141, 45);
            this.btBeziers.TabIndex = 6;
            this.btBeziers.Text = "Безье";
            this.btBeziers.UseVisualStyleBackColor = true;
            // 
            // btFilledCurve
            // 
            this.btFilledCurve.Location = new System.Drawing.Point(19, 376);
            this.btFilledCurve.Name = "btFilledCurve";
            this.btFilledCurve.Size = new System.Drawing.Size(141, 45);
            this.btFilledCurve.TabIndex = 7;
            this.btFilledCurve.Text = "Закрашенная";
            this.btFilledCurve.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 470);
            this.Controls.Add(this.btFilledCurve);
            this.Controls.Add(this.btBeziers);
            this.Controls.Add(this.btPolygone);
            this.Controls.Add(this.btCurve);
            this.Controls.Add(this.btClear);
            this.Controls.Add(this.btMove);
            this.Controls.Add(this.btParametrs);
            this.Controls.Add(this.btPoints);
            this.MinimumSize = new System.Drawing.Size(200, 470);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btPoints;
        private System.Windows.Forms.Button btParametrs;
        private System.Windows.Forms.Button btMove;
        private System.Windows.Forms.Button btClear;
        private System.Windows.Forms.Button btCurve;
        private System.Windows.Forms.Button btPolygone;
        private System.Windows.Forms.Button btBeziers;
        private System.Windows.Forms.Button btFilledCurve;
    }
}

