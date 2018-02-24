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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TvTableTopForm));
            this.MainLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.MainContentWindow = new TvTableTop.Components.DisplayBox(this.components);
            this.RollupBar = new System.Windows.Forms.TabControl();
            this.ExplorerTab = new System.Windows.Forms.TabPage();
            this.gbMasks = new System.Windows.Forms.GroupBox();
            this.txtMaskedCells = new System.Windows.Forms.TextBox();
            this.cmdEndMask = new System.Windows.Forms.Button();
            this.cmdStartMask = new System.Windows.Forms.Button();
            this.gbItems = new System.Windows.Forms.GroupBox();
            this.ItemSizeControl = new System.Windows.Forms.NumericUpDown();
            this.lblItemSize = new System.Windows.Forms.Label();
            this.cmdRemoveItem = new System.Windows.Forms.Button();
            this.ToolStripExplorer = new System.Windows.Forms.ToolStrip();
            this.cmdClose = new System.Windows.Forms.ToolStripButton();
            this.cmdLoad = new System.Windows.Forms.ToolStripButton();
            this.cmdSettings = new System.Windows.Forms.ToolStripButton();
            this.cmdMinMax = new System.Windows.Forms.ToolStripButton();
            this.ItemsTab = new System.Windows.Forms.TabPage();
            this.listViewItems = new TvTableTop.Components.ListViewGifItems(this.components);
            this.MainLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainContentWindow)).BeginInit();
            this.RollupBar.SuspendLayout();
            this.ExplorerTab.SuspendLayout();
            this.gbMasks.SuspendLayout();
            this.gbItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ItemSizeControl)).BeginInit();
            this.ToolStripExplorer.SuspendLayout();
            this.ItemsTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainLayoutPanel
            // 
            this.MainLayoutPanel.ColumnCount = 2;
            this.MainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.MainLayoutPanel.Controls.Add(this.MainContentWindow, 0, 0);
            this.MainLayoutPanel.Controls.Add(this.RollupBar, 1, 0);
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
            // RollupBar
            // 
            this.RollupBar.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.RollupBar.Controls.Add(this.ExplorerTab);
            this.RollupBar.Controls.Add(this.ItemsTab);
            this.RollupBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RollupBar.Location = new System.Drawing.Point(959, 3);
            this.RollupBar.Name = "RollupBar";
            this.RollupBar.SelectedIndex = 0;
            this.RollupBar.Size = new System.Drawing.Size(294, 648);
            this.RollupBar.TabIndex = 1;
            // 
            // ExplorerTab
            // 
            this.ExplorerTab.Controls.Add(this.gbMasks);
            this.ExplorerTab.Controls.Add(this.gbItems);
            this.ExplorerTab.Controls.Add(this.ToolStripExplorer);
            this.ExplorerTab.Location = new System.Drawing.Point(4, 4);
            this.ExplorerTab.Margin = new System.Windows.Forms.Padding(0);
            this.ExplorerTab.Name = "ExplorerTab";
            this.ExplorerTab.Size = new System.Drawing.Size(286, 622);
            this.ExplorerTab.TabIndex = 0;
            this.ExplorerTab.Text = "Explorer";
            this.ExplorerTab.UseVisualStyleBackColor = true;
            // 
            // gbMasks
            // 
            this.gbMasks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbMasks.Controls.Add(this.txtMaskedCells);
            this.gbMasks.Controls.Add(this.cmdEndMask);
            this.gbMasks.Controls.Add(this.cmdStartMask);
            this.gbMasks.Location = new System.Drawing.Point(3, 175);
            this.gbMasks.Name = "gbMasks";
            this.gbMasks.Size = new System.Drawing.Size(278, 144);
            this.gbMasks.TabIndex = 2;
            this.gbMasks.TabStop = false;
            this.gbMasks.Text = "Masks";
            // 
            // txtMaskedCells
            // 
            this.txtMaskedCells.Location = new System.Drawing.Point(6, 48);
            this.txtMaskedCells.Name = "txtMaskedCells";
            this.txtMaskedCells.Size = new System.Drawing.Size(266, 20);
            this.txtMaskedCells.TabIndex = 2;
            // 
            // cmdEndMask
            // 
            this.cmdEndMask.Enabled = false;
            this.cmdEndMask.Location = new System.Drawing.Point(87, 19);
            this.cmdEndMask.Name = "cmdEndMask";
            this.cmdEndMask.Size = new System.Drawing.Size(75, 23);
            this.cmdEndMask.TabIndex = 1;
            this.cmdEndMask.Text = "End Mask";
            this.cmdEndMask.UseVisualStyleBackColor = true;
            this.cmdEndMask.Click += new System.EventHandler(this.cmdEndMask_Click);
            // 
            // cmdStartMask
            // 
            this.cmdStartMask.Location = new System.Drawing.Point(6, 19);
            this.cmdStartMask.Name = "cmdStartMask";
            this.cmdStartMask.Size = new System.Drawing.Size(75, 23);
            this.cmdStartMask.TabIndex = 0;
            this.cmdStartMask.Text = "Start Mask";
            this.cmdStartMask.UseVisualStyleBackColor = true;
            this.cmdStartMask.Click += new System.EventHandler(this.cmdStartMask_Click);
            // 
            // gbItems
            // 
            this.gbItems.Controls.Add(this.ItemSizeControl);
            this.gbItems.Controls.Add(this.lblItemSize);
            this.gbItems.Controls.Add(this.cmdRemoveItem);
            this.gbItems.Location = new System.Drawing.Point(3, 28);
            this.gbItems.Name = "gbItems";
            this.gbItems.Size = new System.Drawing.Size(278, 141);
            this.gbItems.TabIndex = 1;
            this.gbItems.TabStop = false;
            this.gbItems.Text = "Items";
            // 
            // ItemSizeControl
            // 
            this.ItemSizeControl.Location = new System.Drawing.Point(201, 22);
            this.ItemSizeControl.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.ItemSizeControl.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ItemSizeControl.Name = "ItemSizeControl";
            this.ItemSizeControl.Size = new System.Drawing.Size(71, 20);
            this.ItemSizeControl.TabIndex = 2;
            this.ItemSizeControl.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ItemSizeControl.ValueChanged += new System.EventHandler(this.ItemSizeControl_ValueChanged);
            // 
            // lblItemSize
            // 
            this.lblItemSize.AutoSize = true;
            this.lblItemSize.Location = new System.Drawing.Point(145, 24);
            this.lblItemSize.Name = "lblItemSize";
            this.lblItemSize.Size = new System.Drawing.Size(50, 13);
            this.lblItemSize.TabIndex = 1;
            this.lblItemSize.Text = "Item Size";
            // 
            // cmdRemoveItem
            // 
            this.cmdRemoveItem.Location = new System.Drawing.Point(6, 19);
            this.cmdRemoveItem.Name = "cmdRemoveItem";
            this.cmdRemoveItem.Size = new System.Drawing.Size(75, 23);
            this.cmdRemoveItem.TabIndex = 0;
            this.cmdRemoveItem.Text = "Remove";
            this.cmdRemoveItem.UseVisualStyleBackColor = true;
            this.cmdRemoveItem.Click += new System.EventHandler(this.cmdRemoveItem_Click);
            // 
            // ToolStripExplorer
            // 
            this.ToolStripExplorer.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStripExplorer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdClose,
            this.cmdLoad,
            this.cmdSettings,
            this.cmdMinMax});
            this.ToolStripExplorer.Location = new System.Drawing.Point(0, 0);
            this.ToolStripExplorer.Name = "ToolStripExplorer";
            this.ToolStripExplorer.Size = new System.Drawing.Size(286, 25);
            this.ToolStripExplorer.TabIndex = 0;
            this.ToolStripExplorer.Text = "toolStrip1";
            // 
            // cmdClose
            // 
            this.cmdClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cmdClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(40, 22);
            this.cmdClose.Text = "Close";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdLoad
            // 
            this.cmdLoad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmdLoad.Image = ((System.Drawing.Image)(resources.GetObject("cmdLoad.Image")));
            this.cmdLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdLoad.Name = "cmdLoad";
            this.cmdLoad.Size = new System.Drawing.Size(37, 22);
            this.cmdLoad.Text = "Load";
            this.cmdLoad.Click += new System.EventHandler(this.cmdLoad_Click);
            // 
            // cmdSettings
            // 
            this.cmdSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmdSettings.Image = ((System.Drawing.Image)(resources.GetObject("cmdSettings.Image")));
            this.cmdSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdSettings.Name = "cmdSettings";
            this.cmdSettings.Size = new System.Drawing.Size(53, 22);
            this.cmdSettings.Text = "Settings";
            this.cmdSettings.Click += new System.EventHandler(this.cmdSettings_Click);
            // 
            // cmdMinMax
            // 
            this.cmdMinMax.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cmdMinMax.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmdMinMax.Image = ((System.Drawing.Image)(resources.GetObject("cmdMinMax.Image")));
            this.cmdMinMax.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdMinMax.Name = "cmdMinMax";
            this.cmdMinMax.Size = new System.Drawing.Size(59, 22);
            this.cmdMinMax.Text = "Min/Max";
            this.cmdMinMax.Click += new System.EventHandler(this.cmdMinMax_Click);
            // 
            // ItemsTab
            // 
            this.ItemsTab.Controls.Add(this.listViewItems);
            this.ItemsTab.Location = new System.Drawing.Point(4, 4);
            this.ItemsTab.Margin = new System.Windows.Forms.Padding(0);
            this.ItemsTab.Name = "ItemsTab";
            this.ItemsTab.Size = new System.Drawing.Size(286, 622);
            this.ItemsTab.TabIndex = 1;
            this.ItemsTab.Text = "Items";
            this.ItemsTab.UseVisualStyleBackColor = true;
            // 
            // listViewItems
            // 
            this.listViewItems.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listViewItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewItems.Location = new System.Drawing.Point(0, 0);
            this.listViewItems.Margin = new System.Windows.Forms.Padding(0);
            this.listViewItems.Name = "listViewItems";
            this.listViewItems.Size = new System.Drawing.Size(286, 622);
            this.listViewItems.TabIndex = 0;
            this.listViewItems.UseCompatibleStateImageBehavior = false;
            this.listViewItems.ActiveItemChanged += new System.EventHandler<TvTableTop.ActiveItemChangedEventArgs>(this.listViewItems_ActiveItemChanged);
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
            this.RollupBar.ResumeLayout(false);
            this.ExplorerTab.ResumeLayout(false);
            this.ExplorerTab.PerformLayout();
            this.gbMasks.ResumeLayout(false);
            this.gbMasks.PerformLayout();
            this.gbItems.ResumeLayout(false);
            this.gbItems.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ItemSizeControl)).EndInit();
            this.ToolStripExplorer.ResumeLayout(false);
            this.ToolStripExplorer.PerformLayout();
            this.ItemsTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainLayoutPanel;
        private Components.DisplayBox MainContentWindow;
        private System.Windows.Forms.TabControl RollupBar;
        private System.Windows.Forms.TabPage ExplorerTab;
        private System.Windows.Forms.TabPage ItemsTab;
        private System.Windows.Forms.ToolStrip ToolStripExplorer;
        private System.Windows.Forms.ToolStripButton cmdClose;
        private System.Windows.Forms.ToolStripButton cmdLoad;
        private System.Windows.Forms.ToolStripButton cmdSettings;
        private System.Windows.Forms.ToolStripButton cmdMinMax;
        private Components.ListViewGifItems listViewItems;
        private System.Windows.Forms.GroupBox gbItems;
        private System.Windows.Forms.Button cmdRemoveItem;
        private System.Windows.Forms.NumericUpDown ItemSizeControl;
        private System.Windows.Forms.Label lblItemSize;
        private System.Windows.Forms.GroupBox gbMasks;
        private System.Windows.Forms.Button cmdEndMask;
        private System.Windows.Forms.Button cmdStartMask;
        private System.Windows.Forms.TextBox txtMaskedCells;
    }
}

