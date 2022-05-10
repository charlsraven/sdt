namespace WindowsFormsApp1
{
    partial class ParamForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.ptSizeUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.lineSizeUpDown = new System.Windows.Forms.NumericUpDown();
            this.btSave = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ptSizeUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineSizeUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Радиус точки";
            // 
            // ptSizeUpDown
            // 
            this.ptSizeUpDown.Location = new System.Drawing.Point(51, 32);
            this.ptSizeUpDown.Name = "ptSizeUpDown";
            this.ptSizeUpDown.Size = new System.Drawing.Size(140, 26);
            this.ptSizeUpDown.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Толщина линии";
            // 
            // lineSizeUpDown
            // 
            this.lineSizeUpDown.Location = new System.Drawing.Point(51, 95);
            this.lineSizeUpDown.Name = "lineSizeUpDown";
            this.lineSizeUpDown.Size = new System.Drawing.Size(140, 26);
            this.lineSizeUpDown.TabIndex = 3;
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(250, 12);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(186, 46);
            this.btSave.TabIndex = 4;
            this.btSave.Text = "Сохранить";
            this.btSave.UseVisualStyleBackColor = true;
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(250, 73);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(186, 48);
            this.btCancel.TabIndex = 5;
            this.btCancel.Text = "Сбросить";
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // ParamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 144);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.lineSizeUpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ptSizeUpDown);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(480, 200);
            this.Name = "ParamForm";
            this.Text = "ParamForm";
            this.Load += new System.EventHandler(this.ParamForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ptSizeUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineSizeUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown ptSizeUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown lineSizeUpDown;
        public System.Windows.Forms.Button btSave;
        public System.Windows.Forms.Button btCancel;
    }
}