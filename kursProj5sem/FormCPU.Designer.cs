namespace kursProj5sem
{
    partial class FormCPU
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
            this.labelTotal = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Location = new System.Drawing.Point(12, 23);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(41, 15);
            this.labelTotal.TabIndex = 0;
            this.labelTotal.Text = "Всего:";
            // 
            // FormCPU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1293, 101);
            this.Controls.Add(this.labelTotal);
            this.Name = "FormCPU";
            this.Text = "FormCPU";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTotal;
    }
}