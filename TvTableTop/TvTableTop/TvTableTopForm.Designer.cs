namespace TvTableTop
{
    partial class TvTableTopForm
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
            this.components = new System.ComponentModel.Container();
            this.MainLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.MainContentWindow = new TvTableTop.Components.DisplayBox(this.components);
            this.MainLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainContentWindow)).BeginInit();
            this.SuspendLayout();
            // 
            // MainLayoutPanel
            // 
            this.MainLayoutPanel.ColumnCount = 2;
            this.MainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.MainLayoutPanel.Controls.Add(this.MainContentWindow, 0, 0);
            this.MainLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.MainLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.MainLayoutPanel.Name = "MainLayoutPanel";
            this.MainLayoutPanel.RowCount = 1;
            this.MainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainLayoutPanel.Size = new System.Drawing.Size(1256, 654);
            this.MainLayoutPanel.TabIndex = 0;
            // 
            // MainContentWindow
            // 
            this.MainContentWindow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MainContentWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainContentWindow.IsCellSelectionOn = false;
            this.MainContentWindow.Location = new System.Drawing.Point(0, 0);
            this.MainContentWindow.Margin = new System.Windows.Forms.Padding(0);
            this.MainContentWindow.Name = "MainContentWindow";
            this.MainContentWindow.ScaleFactor = 1F;
            this.MainContentWindow.Size = new System.Drawing.Size(956, 654);
            this.MainContentWindow.TabIndex = 0;
            this.MainContentWindow.TabStop = false;
            // 
            // TvTableTopForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1256, 654);
            this.Controls.Add(this.MainLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TvTableTopForm";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.MainLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainContentWindow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainLayoutPanel;
        private Components.DisplayBox MainContentWindow;
    }
}

