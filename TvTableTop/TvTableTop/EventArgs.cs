using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TvTableTop
{
    public class CellSelectedEventArgs
    {
        private Tuple<int, int> m_cell;

        public CellSelectedEventArgs(Tuple<int, int> cell)
        {
            m_cell = cell;
        }

        public Tuple<int, int> SelectedCell
        {
            get
            {
                return m_cell;
            }
        }
    }

    public class ActiveItemChangedEventArgs
    {
        private GifImage m_image;

        public ActiveItemChangedEventArgs(GifImage image)
        {
            m_image = image;
        }

        public GifImage SelectedGifImage
        {
            get
            {
                return m_image;
            }
        }
    }
}
