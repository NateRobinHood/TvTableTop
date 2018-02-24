using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TvTableTop.Components;

namespace TvTableTop.UserControls
{
    public partial class ControlPanelUserControl : UserControl
    {
        public event EventHandler OnLoad;
        public event EventHandler OnClose;
        public event EventHandler OnSettings;
        public event EventHandler OnMinMax;
        public event EventHandler OnRemoveItem;
        public event EventHandler OnRemoveAllItems;
        public event EventHandler OnStartMask;
        public event EventHandler OnEndMask;
        public event EventHandler OnDock;

        public ControlPanelUserControl()
        {
            InitializeComponent();

            listViewItems.InitItemsList();
        }

        //Public Properties
        public ListViewGifItems ListViewItems
        {
            get
            {
                return listViewItems;
            }
        }

        public NumericUpDown ItemSizeControl
        {
            get
            {
                return itemSizeControl;
            }
        }

        public TextBox MaskedCells
        {
            get
            {
                return txtMaskedCells;
            }
        }

        //Public Methods
        public void ToggleStartEndMask()
        {
            cmdStartMask.Enabled = !cmdStartMask.Enabled;
            cmdEndMask.Enabled = !cmdEndMask.Enabled;
        }

        //Event Handlers
        private void cmdLoad_Click(object sender, EventArgs e)
        {
            OnLoad?.Invoke(this, EventArgs.Empty);
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            OnClose?.Invoke(this, EventArgs.Empty);
        }

        private void cmdSettings_Click(object sender, EventArgs e)
        {
            OnSettings?.Invoke(this, EventArgs.Empty);
        }

        private void cmdMinMax_Click(object sender, EventArgs e)
        {
            OnMinMax?.Invoke(this, EventArgs.Empty);
        }

        private void cmdRemoveItem_Click(object sender, EventArgs e)
        {
            OnRemoveItem?.Invoke(this, EventArgs.Empty);
        }

        private void cmdStartMask_Click(object sender, EventArgs e)
        {
            OnStartMask?.Invoke(this, EventArgs.Empty);
        }

        private void cmdEndMask_Click(object sender, EventArgs e)
        {
            OnEndMask?.Invoke(this, EventArgs.Empty);
        }

        private void cmdDock_Click(object sender, EventArgs e)
        {
            OnDock?.Invoke(this, EventArgs.Empty);
        }

        private void cmdRemoveAll_Click(object sender, EventArgs e)
        {
            OnRemoveAllItems?.Invoke(this, EventArgs.Empty);
        }
    }
}
