using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TvTableTop.Components;
using TvTableTop.UserControls;

namespace TvTableTop
{
    public partial class TvTableTopForm : Form
    {
        private SettingsData m_Settings = new SettingsData();
        private ControlPanelUserControl m_ControlPanel = new ControlPanelUserControl();
        private Form m_ControlPanelForm;
        private ColumnStyle m_DockColumn;
        private GifImage m_ItemToBeDropped = null;
        private Mask m_NewMask = null;
        private bool m_droppingItem = false;
        private bool m_removingItem = false;
        private bool m_addingMask = false;
        private int m_selectedItemSize = 1;

        public TvTableTopForm()
        {
            InitializeComponent();

            InitControlPanel();

            m_Settings.ScaleFactor = 1;
        }

        //Private Methods
        private void InitControlPanel()
        {
            m_ControlPanel = new ControlPanelUserControl();
            m_ControlPanel.OnLoad += cmdLoad_Click;
            m_ControlPanel.OnClose += cmdClose_Click;
            m_ControlPanel.OnSettings += cmdSettings_Click;
            m_ControlPanel.OnMinMax += cmdMinMax_Click;
            m_ControlPanel.OnRemoveItem += cmdRemoveItem_Click;
            m_ControlPanel.OnStartMask += cmdStartMask_Click;
            m_ControlPanel.OnEndMask += cmdEndMask_Click;
            m_ControlPanel.OnDock += ControlPanel_OnDock;
            m_ControlPanel.ListViewItems.ActiveItemChanged += listViewItems_ActiveItemChanged;
            m_ControlPanel.ItemSizeControl.ValueChanged += ItemSizeControl_ValueChanged;

            MainLayoutPanel.Controls.Add(m_ControlPanel, 1, 0);
            m_ControlPanel.Dock = DockStyle.Fill;
        }

        private void InitMainContentWindow()
        {
            MainLayoutPanel.Controls.Remove(MainContentWindow);
            MainContentWindow.CellSelected -= MainContentWindow_CellSelected;
            MainContentWindow.Dispose();

            MainContentWindow = new Components.DisplayBox(this.components);
            this.MainContentWindow.Cursor = Cursors.Hand;
            this.MainContentWindow.Dock = DockStyle.Fill;
            this.MainContentWindow.Location = new Point(0, 0);
            this.MainContentWindow.Margin = new Padding(0);
            this.MainContentWindow.Name = "MainContentWindow";
            this.MainContentWindow.Size = new Size(956, 654);
            this.MainContentWindow.TabIndex = 0;
            this.MainContentWindow.TabStop = false;
            this.MainContentWindow.CellSelected += MainContentWindow_CellSelected;

            MainLayoutPanel.Controls.Add(MainContentWindow, 0, 0);
        }

        //Event Handlers
        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdLoad_Click(object sender, EventArgs e)
        {
            //is image currently open
            //if (MainContentWindow.Image != null && 
            //    !string.IsNullOrEmpty(MainContentWindow.ImageLocation))
            //{
            //    Properties.Settings.Default[MainContentWindow.ImageLocation] = new SavedData(MainContentWindow.ImageSnapPoint, MainContentWindow.ScaleFactor);
            //}

            using (OpenFileDialog OFD = new OpenFileDialog())
            {
                OFD.Filter = "image files (*.jpg; *.png)|*.jpg; *.png";
                if (OFD.ShowDialog() == DialogResult.OK)
                {
                    string imageFile = OFD.FileName;

                    InitMainContentWindow();

                    //MainContentWindow.ImageLocation = imageFile;
                    MainContentWindow.Load(imageFile);
                    MainContentWindow.SizeMode = PictureBoxSizeMode.CenterImage;
                    MainContentWindow.ScaleFactor = m_Settings.ScaleFactor;
                    MainContentWindow.UpdateBrackground = true;
                }
            }
        }

        private void cmdSettings_Click(object sender, EventArgs e)
        {
            using (SettingsForm SF = new SettingsForm(m_Settings))
            {
                SF.StartPosition = FormStartPosition.CenterParent;
                if (SF.ShowDialog() == DialogResult.OK)
                {
                    m_Settings.ScaleFactor = SF.Settings.ScaleFactor;
                    MainContentWindow.ScaleFactor = m_Settings.ScaleFactor;

                    MainContentWindow.CenterImage();
                }
            }
        }

        private void cmdMinMax_Click(object sender, EventArgs e)
        {
            if (this.FormBorderStyle == FormBorderStyle.None)
            {
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void listViewItems_ActiveItemChanged(object sender, ActiveItemChangedEventArgs e)
        {
            m_ItemToBeDropped = e.SelectedGifImage;
            m_ItemToBeDropped.DpiSize = m_selectedItemSize;
            MainContentWindow.IsCellSelectionOn = true;
            MainContentWindow.CellSelectionSize = new Size(m_selectedItemSize, m_selectedItemSize);
            m_droppingItem = true;
        }

        private void MainContentWindow_CellSelected(object sender, CellSelectedEventArgs e)
        {
            if (m_droppingItem)
            {
                MainContentWindow.AddItem(m_ItemToBeDropped, e.SelectedCell);
                m_ItemToBeDropped = null;
                m_ControlPanel.ListViewItems.ClearActiveItem();
                m_droppingItem = false;
            }
            else if (m_removingItem)
            {
                MainContentWindow.RemoveItem(e.SelectedCell);
                m_removingItem = false;
            }
            else if (m_addingMask)
            {
                m_NewMask.AddCellToMask(e.SelectedCell);
                m_ControlPanel.MaskedCells.Text = m_NewMask.MaskText;
                MainContentWindow.IsCellSelectionOn = true;
                MainContentWindow.Invalidate();
            }
        }

        private void cmdRemoveItem_Click(object sender, EventArgs e)
        {
            MainContentWindow.IsCellSelectionOn = true;
            m_removingItem = true;
        }

        private void ItemSizeControl_ValueChanged(object sender, EventArgs e)
        {
            m_selectedItemSize = Convert.ToInt32(m_ControlPanel.ItemSizeControl.Value);
        }

        private void cmdStartMask_Click(object sender, EventArgs e)
        {
            m_NewMask = new Mask();
            MainContentWindow.Masks.Add(m_NewMask);
            MainContentWindow.IsCellSelectionOn = true;
            m_addingMask = true;
            //cmdStartMask.Enabled = false;
            //cmdEndMask.Enabled = true;
            m_ControlPanel.ToggleStartEndMask();
        }

        private void cmdEndMask_Click(object sender, EventArgs e)
        {
            m_NewMask.FillBrush = new SolidBrush(Color.FromArgb(250, Color.DarkGray));
            m_NewMask = null;
            m_ControlPanel.MaskedCells.Text = string.Empty;
            MainContentWindow.IsCellSelectionOn = false;
            MainContentWindow.Invalidate();
            m_addingMask = false;
            //cmdStartMask.Enabled = true;
            //cmdEndMask.Enabled = false;
            m_ControlPanel.ToggleStartEndMask();
        }

        private void ControlPanel_OnDock(object sender, EventArgs e)
        {
            if (m_ControlPanelForm == null)
            {
                m_ControlPanelForm = new Form();
                m_ControlPanelForm.Text = "Control Panel";
                m_ControlPanelForm.Size = new Size(310, 566);

                MainLayoutPanel.Controls.Remove(m_ControlPanel);
                m_DockColumn = MainLayoutPanel.ColumnStyles[1];
                MainLayoutPanel.ColumnStyles.Remove(m_DockColumn);

                m_ControlPanelForm.Controls.Add(m_ControlPanel);
                m_ControlPanel.Dock = DockStyle.Fill;

                m_ControlPanelForm.Show();
            }
            else
            {
                if(m_DockColumn != null)
                    MainLayoutPanel.ColumnStyles.Add(m_DockColumn);

                m_ControlPanelForm.Controls.Remove(m_ControlPanel);
                MainLayoutPanel.Controls.Add(m_ControlPanel, 1, 0);
                m_ControlPanel.Dock = DockStyle.Fill;

                m_ControlPanelForm.Close();
                m_ControlPanelForm = null;
            }
        }
    }
}
