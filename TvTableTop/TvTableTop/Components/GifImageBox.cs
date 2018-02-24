using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TvTableTop.Components
{
    public partial class GifImageBox : PictureBox
    {
        private Image m_gifImage;
        private FrameDimension m_dimension;
        private int m_frameCount;
        private int m_currentFrame = 0;
        private bool m_reverse = false;
        private int m_step = 1;
        private Timer m_animationTimer;

        public GifImageBox()
        {
            InitializeComponent();

            m_animationTimer = new Timer();
            m_animationTimer.Interval = 100;
            m_animationTimer.Tick += AnimationTimer_Tick;
            m_animationTimer.Enabled = true;

            this.DoubleBuffered = true;

            this.Paint += GifImageBox_Paint;
            this.BackColor = Color.Transparent;
        }

        public GifImageBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            m_animationTimer = new Timer();
            m_animationTimer.Interval = 100;
            m_animationTimer.Tick += AnimationTimer_Tick;
            m_animationTimer.Enabled = true;

            this.DoubleBuffered = true;

            this.Paint += GifImageBox_Paint;
            this.BackColor = Color.Transparent;
        }

        public void LoadGif(string filepath)
        {
            m_gifImage = Image.FromFile(filepath);
            //initialize
            m_dimension = new FrameDimension(m_gifImage.FrameDimensionsList[0]);
            //gets the GUID
            //total frames in the animation
            m_frameCount = m_gifImage.GetFrameCount(m_dimension);

            m_animationTimer.Start();
        }

        public bool ReverseAtEnd
        {
            //whether the gif should play backwards when it reaches the end
            get { return m_reverse; }
            set { m_reverse = value; }
        }

        private void MoveToNextFrame()
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

        private Image GetFrame(int index)
        {
            m_gifImage.SelectActiveFrame(m_dimension, index);
            //find the frame
            return (Image)m_gifImage.Clone();
            //return a copy of it
        }

        private void GifImageBox_Paint(object sender, PaintEventArgs e)
        {
            if (m_gifImage != null)
            {
                e.Graphics.DrawRectangle(new Pen(Color.Transparent), new Rectangle(0, 0, Width, Height));
                Image printImage = GetFrame(m_currentFrame);
                if (printImage != null)
                    e.Graphics.DrawImage(printImage, new Point(0,0));
                printImage.Dispose();
            }
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            MoveToNextFrame();
            this.Invalidate();
        }
    }
}
