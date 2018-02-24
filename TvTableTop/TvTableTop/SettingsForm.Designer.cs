namespace TvTableTop
{
    partial class SettingsForm
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
            this.gbGraphics = new System.Windows.Forms.GroupBox();
            this.lblScaleFactor = new System.Windows.Forms.Label();
            this.controlScaleFactor = new System.Windows.Forms.NumericUpDown();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdApply = new System.Windows.Forms.Button();
            this.gbGraphics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.controlScaleFactor)).BeginInit();
            this.SuspendLayout();
            // 
            // gbGraphics
            // 
            this.gbGraphics.Controls.Add(this.controlScaleFactor);
            this.gbGraphics.Controls.Add(this.lblScaleFactor);
            this.gbGraphics.Location = new System.Drawing.Point(12, 12);
            this.gbGraphics.Name = "gbGraphics";
            this.gbGraphics.Size = new System.Drawing.Size(181, 59);
            this.gbGraphics.TabIndex = 0;
            this.gbGraphics.TabStop = false;
            this.gbGraphics.Text = "Graphics";
            // 
            // lblScaleFactor
            // 
            this.lblScaleFactor.AutoSize = true;
            this.lblScaleFactor.Location = new System.Drawing.Point(7, 20);
            this.lblScaleFactor.Name = "lblScaleFactor";
            this.lblScaleFactor.Size = new System.Drawing.Size(67, 13);
            this.lblScaleFactor.TabIndex = 0;
            this.lblScaleFactor.Text = "Scale Factor";
            // 
            // controlScaleFactor
            // 
            this.controlScaleFactor.DecimalPlaces = 2;
            this.controlScaleFactor.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.controlScaleFactor.Location = new System.Drawing.Point(80, 18);
            this.controlScaleFactor.Name = "controlScaleFactor";
            this.controlScaleFactor.Size = new System.Drawing.Size(84, 20);
            this.controlScaleFactor.TabIndex = 1;
            this.controlScaleFactor.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.controlScaleFactor.ValueChanged += new System.EventHandler(this.controlScaleFactor_ValueChanged);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(311, 179);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 1;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdApply
            // 
            this.cmdApply.Location = new System.Drawing.Point(230, 179);
            this.cmdApply.Name = "cmdApply";
            this.cmdApply.Size = new System.Drawing.Size(75, 23);
            this.cmdApply.TabIndex = 2;
            this.cmdApply.Text = "Apply";
            this.cmdApply.UseVisualStyleBackColor = true;
            this.cmdApply.Click += new System.EventHandler(this.cmdApply_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 214);
            this.Controls.Add(this.cmdApply);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.gbGraphics);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.gbGraphics.ResumeLayout(false);
            this.gbGraphics.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.controlScaleFactor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbGraphics;
        private System.Windows.Forms.Label lblScaleFactor;
        private System.Windows.Forms.NumericUpDown controlScaleFactor;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdApply;
    }
}