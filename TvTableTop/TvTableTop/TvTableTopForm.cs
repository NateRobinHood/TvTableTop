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

namespace TvTableTop
{
    public partial class TvTableTopForm : Form
    {
        private SettingsData m_Settings = new SettingsData();
        private GifImage m_ItemToBeDropped = null;
        private Mask m_NewMask = null;
        private bool m_droppingItem = false;
        private bool m_removingItem = false;
        private bool m_addingMask = false;
        private int m_selectedItemSize = 1;

        public TvTableTopForm()
        {
            InitializeComponent();

            m_Settings.ScaleFactor = 1;

            listViewItems.InitItemsList();
        }

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
            m_droppingItem = true;
        }

        private void MainContentWindow_CellSelected(object sender, CellSelectedEventArgs e)
        {
            if (m_droppingItem)
            {
                MainContentWindow.AddItem(m_ItemToBeDropped, e.SelectedCell);
                m_ItemToBeDropped = null;
                listViewItems.ClearActiveItem();
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
                txtMaskedCells.Text = m_NewMask.MaskText;
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
            m_selectedItemSize = Convert.ToInt32(ItemSizeControl.Value);
        }

        private void cmdStartMask_Click(object sender, EventArgs e)
        {
            m_NewMask = new Mask();
            MainContentWindow.Masks.Add(m_NewMask);
            MainContentWindow.IsCellSelectionOn = true;
            m_addingMask = true;
            cmdStartMask.Enabled = false;
            cmdEndMask.Enabled = true;
        }

        private void cmdEndMask_Click(object sender, EventArgs e)
        {
            m_NewMask.FillBrush = new SolidBrush(Color.FromArgb(250, Color.DarkGray));
            m_NewMask = null;
            txtMaskedCells.Text = string.Empty;
            MainContentWindow.IsCellSelectionOn = false;
            MainContentWindow.Invalidate();
            m_addingMask = false;
            cmdStartMask.Enabled = true;
            cmdEndMask.Enabled = false;
        }
    }
}
