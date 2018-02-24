using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TvTableTop
{
    public class GifImage
    {
        private Image m_gifImage;
        private FrameDimension m_dimension;
        private int m_frameCount;
        private int m_currentFrame = 0;
        private bool m_reverse = false;
        private int m_step = 1;
        private int m_dpiSize;
        private const int m_dpi = 96; //active dpi scaling happens in the DiplayBox control, this should alwasy be 96 dpi

        public GifImage(string filepath, int dpiSize = 2)
        {
            m_dpiSize = dpiSize;
            m_gifImage = Image.FromFile(filepath);
            //initialize
            m_dimension = new FrameDimension(m_gifImage.FrameDimensionsList[0]);
            //gets the GUID
            //total frames in the animation
            m_frameCount = m_gifImage.GetFrameCount(m_dimension);
        }

        public GifImage(Image image, int dpiSize = 2)
        {
            m_dpiSize = dpiSize;
            m_gifImage = image;
            //initialize
            m_dimension = new FrameDimension(m_gifImage.FrameDimensionsList[0]);
            //gets the GUID
            //total frames in the animation
            m_frameCount = m_gifImage.GetFrameCount(m_dimension);
        }

        public bool ReverseAtEnd
        {
            //whether the gif should play backwards when it reaches the end
            get { return m_reverse; }
            set { m_reverse = value; }
        }

        public int DpiSize
        {
            get
            {
                return m_dpiSize;
            }
            set
            {
                m_dpiSize = value;
            }
        }

        public void MoveToNextFrame()
        {

            m_currentFrame += m_step;

            //if the animation reaches a boundary...
            if (m_currentFrame >= m_frameCount || m_currentFrame < 1)
            {
                if (m_reverse)
                {
                    m_step *= -1;
                    //...reverse the count
                    //apply it
                    m_currentFrame += m_step;
                }
                else
                {
                    m_currentFrame = 0;
                    //...or start over
                }
            }
        }

        public Image GetNextFrame()
        {

            m_currentFrame += m_step;

            //if the animation reaches a boundary...
            if (m_currentFrame >= m_frameCount || m_currentFrame < 1)
            {
                if (m_reverse)
                {
                    m_step *= -1;
                    //...reverse the count
                    //apply it
                    m_currentFrame += m_step;
                }
                else
                {
                    m_currentFrame = 0;
                    //...or start over
                }
            }
            return GetFrame(m_currentFrame);
        }

        public Image GetFrame(int index)
        {
            m_gifImage.SelectActiveFrame(m_dimension, index);
            Image sizedImage = new Bitmap(m_gifImage, new Size(m_dpiSize * m_dpi, m_dpiSize * m_dpi));
            return sizedImage;
            //find the frame
            //return (Image)m_gifImage.Clone();
            //return a copy of it
        }

        public Image GetFrame()
        {
            m_gifImage.SelectActiveFrame(m_dimension, m_currentFrame);
            Image sizedImage = new Bitmap(m_gifImage, new Size(m_dpiSize * m_dpi, m_dpiSize * m_dpi));
            return sizedImage;
            //find the frame
            //return (Image)m_gifImage.Clone();
            //return a copy of it
        }

        public void Dispose()
        {
            if (m_gifImage != null)
            {
                m_gifImage.Dispose();
                this.Dispose();
            }
        }
    }
}
