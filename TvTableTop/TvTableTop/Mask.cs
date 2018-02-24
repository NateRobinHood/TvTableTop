using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TvTableTop
{
    public class Mask
    {
        private List<Tuple<int, int>> m_MaskedCells = new List<Tuple<int, int>>();
        private Brush m_FillBrush = new SolidBrush(Color.FromArgb(100, Color.Yellow));

        public Mask()
        {

        }

        public List<Tuple<int, int>> MaskedCells
        {
            get
            {
                return m_MaskedCells;
            }
        }

        public Brush FillBrush
        {
            get
            {
                return m_FillBrush;
            }
            set
            {
                m_FillBrush = value;
            }
        }

        public string MaskText
        {
            get
            {
                if (m_MaskedCells.Count > 0)
                    return m_MaskedCells.Select(c => string.Format("({0},{1})", c.Item1, c.Item2)).Aggregate((c1, c2) => c1 + "," + c2);
                else
                    return "";
            }
        }

        public void AddCellToMask(Tuple<int, int> cell)
        {
            Tuple<int, int> existingCell = m_MaskedCells.Where(c => c.Equals(cell)).FirstOrDefault();
            if (existingCell != null)
            {
                m_MaskedCells.Remove(existingCell);
            }
            else
            {
                m_MaskedCells.Add(cell);
            }
        }
    }
}
