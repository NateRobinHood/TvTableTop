using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TvTableTop
{
    public class SavedData
    {
        private Point m_Location;
        private float m_DpiScaleFactor;

        public SavedData(Point location, float dpi)
        {
            m_Location = location;
            m_DpiScaleFactor = dpi;
        }

        public Point Location
        {
            get
            {
                return m_Location;
            }
        }

        public float Dpi
        {
            get
            {
                return m_DpiScaleFactor;
            }
        }
    }
}
