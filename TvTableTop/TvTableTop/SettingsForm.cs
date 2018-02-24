using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TvTableTop
{
    public partial class SettingsForm : Form
    {
        private SettingsData m_Settings;

        public SettingsForm(SettingsData settings)
        {
            InitializeComponent();

            m_Settings = new SettingsData(settings);

            controlScaleFactor.Value = Convert.ToDecimal(settings.ScaleFactor);
        }

        public SettingsData Settings
        {
            get
            {
                return m_Settings;
            }
        }

        private void controlScaleFactor_ValueChanged(object sender, EventArgs e)
        {
            m_Settings.ScaleFactor = (float)controlScaleFactor.Value;
        }

        private void cmdApply_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
