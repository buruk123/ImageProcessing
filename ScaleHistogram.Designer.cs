namespace ImageProcessing
{
    partial class ScaleHistogram
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.aValue = new System.Windows.Forms.NumericUpDown();
            this.bValue = new System.Windows.Forms.NumericUpDown();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cValue = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.dValue = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.aValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dValue)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose values between 0 and 255";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "a:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(12, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "b:";
            // 
            // aValue
            // 
            this.aValue.Location = new System.Drawing.Point(68, 44);
            this.aValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.aValue.Name = "aValue";
            this.aValue.Size = new System.Drawing.Size(120, 20);
            this.aValue.TabIndex = 3;
            // 
            // bValue
            // 
            this.bValue.Location = new System.Drawing.Point(68, 81);
            this.bValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.bValue.Name = "bValue";
            this.bValue.Size = new System.Drawing.Size(120, 20);
            this.bValue.TabIndex = 4;
            this.bValue.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(32, 202);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(113, 202);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(12, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "c:";
            // 
            // cValue
            // 
            this.cValue.Location = new System.Drawing.Point(68, 121);
            this.cValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.cValue.Name = "cValue";
            this.cValue.Size = new System.Drawing.Size(120, 20);
            this.cValue.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(13, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "d:";
            // 
            // dValue
            // 
            this.dValue.Location = new System.Drawing.Point(68, 158);
            this.dValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.dValue.Name = "dValue";
            this.dValue.Size = new System.Drawing.Size(120, 20);
            this.dValue.TabIndex = 10;
            this.dValue.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // ScaleHistogram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(217, 237);
            this.Controls.Add(this.dValue);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cValue);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.bValue);
            this.Controls.Add(this.aValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ScaleHistogram";
            this.Text = "ScaleHistogram";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.aValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown aValue;
        private System.Windows.Forms.NumericUpDown bValue;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown cValue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown dValue;
    }
}