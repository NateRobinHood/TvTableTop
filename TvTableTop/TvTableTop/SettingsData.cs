using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TvTableTop
{
    public class SettingsData
    {
        public SettingsData()
        {

        }

        public SettingsData(SettingsData copy)
        {
            this.ScaleFactor = copy.ScaleFactor;
        }

        public float ScaleFactor { get; set; }
        public string CurrentFileName { get; set; }
    }
}
