using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TvTableTop.Components
{
    public partial class DisplayBox : PictureBox
    {
        public event EventHandler<CellSelectedEventArgs> CellSelected;

        private Point m_startingPoint = Point.Empty;
        private Point m_movingPoint = Point.Empty;
        private bool m_isPanning = false;
        private float m_scaleFactor = 1;
        private float m_scaleDpi = 96;
        private Dictionary<GifImage, Tuple<int, int>> m_items = new Dictionary<GifImage, Tuple<int, int>>();
        private List<Mask> m_masks = new List<Mask>();
        private Timer m_animationTimer;
        private bool m_cellSelection = false;
        private Size m_cellSelectionSize = new Size(1, 1);
        private Point m_cellMousePoint = Point.Empty;

        //paint variables
        public bool UpdateVariables = true;
        public bool UpdateBrackground = true;
        public bool UpdatePanning = true;
        public bool UpdateGifs = true;
        public bool UpdateMasks = true;
        private Image m_scaledBackgroundImage = null;
        private Point m_backgroundImagePoint = Point.Empty;

        public DisplayBox()
        {
            InitializeComponent();

            m_animationTimer = new Timer();
            m_animationTimer.Interval = 100;
            m_animationTimer.Enabled = true;
            m_animationTimer.Tick += AnimationTimer_Tick;
            m_animationTimer.Start();

            this.Cursor = Cursors.Hand;
            this.DoubleBuffered = true;

            this.MouseDown += DisplayBox_MouseDown;
            this.MouseUp += DisplayBox_MouseUp;
            this.MouseMove += DisplayBox_MouseMove;
            this.Paint += DisplayBox_Paint;

            m_scaleDpi = this.CreateGraphics().DpiX;
            m_scaleFactor = m_scaleDpi / 96f;

            this.LoadCompleted += delegate(object sender, AsyncCompletedEventArgs e) { UpdateBrackground = true; };
        }

        public DisplayBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            m_animationTimer = new Timer();
            m_animationTimer.Interval = 100;
            m_animationTimer.Enabled = true;
            m_animationTimer.Tick += AnimationTimer_Tick;
            m_animationTimer.Start();

            this.Cursor = Cursors.Hand;
            this.DoubleBuffered = true;

            this.MouseDown += DisplayBox_MouseDown;
            this.MouseUp += DisplayBox_MouseUp;
            this.MouseMove += DisplayBox_MouseMove;
            this.Paint += DisplayBox_Paint;

            m_scaleDpi = this.CreateGraphics().DpiX;
            m_scaleFactor = m_scaleDpi / 96f;
        }

        public float ScaleFactor
        {
            get
            {
                return m_scaleFactor;
            }
            set
            {
                if (m_scaleFactor != value)
                {
                    m_scaleFactor = value;
                    m_scaleDpi = 96f * m_scaleFactor;
                    UpdateBrackground = true;
                    this.Invalidate();
                }
            }
        }

        public Point ImageSnapPoint
        {
            get
            {
                return m_movingPoint;
            }
        }

        public bool IsCellSelectionOn
        {
            get
            {
                return m_cellSelection;
            }
            set
            {
                m_cellSelection = value;
            }
        }

        public Size CellSelectionSize
        {
            get
            {
                return m_cellSelectionSize;
            }
            set
            {
                m_cellSelectionSize = value;
            }
        }

        public bool HasMasks
        {
            get
            {
                return m_masks.Count > 0;
            }
        }

        public List<Mask> Masks
        {
            get
            {
                return m_masks;
            }
        }

        public void AddItem(GifImage image, Tuple<int, int> cell)
        {
            m_items.Add(image, cell);
        }

        public void RemoveItem(Tuple<int, int> cell)
        {
            var remItems = m_items.Where(c => c.Value.Item1 == cell.Item1 && c.Value.Item2 == cell.Item2).ToList();
            foreach (var item in remItems)
            {
                m_items.Remove(item.Key);
            }
            this.Invalidate();
        }

        public void ClearItems()
        {
            m_items.Clear();
            this.Invalidate();
        }

        public void CenterImage()
        {
            if (this.Image != null)
            {
                Size displaySize = this.Size;
                Size imageSize = ScaleImage(this.Image).Size;

                if (displaySize.Width > imageSize.Width &&
                    displaySize.Height > imageSize.Height)
                {
                    int widthDelta = (displaySize.Width - imageSize.Width) / 2;
                    int heightDelta = (displaySize.Height - imageSize.Height) / 2;

                    m_movingPoint = new Point(widthDelta, heightDelta);
                }
                else
                {
                    m_movingPoint = Point.Empty;
                }
            }
        }

        private void DisplayBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (m_cellSelection)
            {
                m_cellSelection = false;

                Point topLeft = SnapToScaledGrid(m_movingPoint);
                Point cell = SnapToScaledGrid(m_cellMousePoint);

                int cellX = Convert.ToInt32((cell.X - topLeft.X) / m_scaleDpi);
                int cellY = Convert.ToInt32((cell.Y - topLeft.Y) / m_scaleDpi);

                Tuple<int, int> selectedCell = new Tuple<int, int>(cellX, cellY);

                CellSelected?.Invoke(this, new CellSelectedEventArgs(selectedCell));
            }
            else
            {
                m_isPanning = true;
                m_startingPoint = new Point(e.Location.X - m_movingPoint.X,
                                e.Location.Y - m_movingPoint.Y);

                this.Cursor = Cursors.SizeAll;
            }
        }

        private void DisplayBox_MouseUp(object sender, MouseEventArgs e)
        {
            m_isPanning = false;
            this.Cursor = Cursors.Hand;
        }

        private void DisplayBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (m_isPanning)
            {
                m_movingPoint = new Point(e.Location.X - m_startingPoint.X,
                                        e.Location.Y - m_startingPoint.Y);
                UpdatePanning = true;
                this.Invalidate();
            }
            else if(m_cellSelection)
            {
                m_cellMousePoint = new Point(e.X, e.Y);
                this.Invalidate();
            }
        }

        private void VariablesUpdate()
        {
            if ((UpdateVariables || UpdateBrackground) && Image != null)
            {
                if (m_scaledBackgroundImage != null)
                    m_scaledBackgroundImage.Dispose();
                m_scaledBackgroundImage = ScaleImage(Image);
            }
            if (UpdateVariables || UpdatePanning)
            {
                m_backgroundImagePoint = SnapToScaledGrid(m_movingPoint);
            }

            UpdateVariables = false;
            UpdateBrackground = false;
            UpdatePanning = false;
        }

        private void DisplayBox_Paint(object sender, PaintEventArgs e)
        {
            VariablesUpdate();
            if (Image != null)
            {
                //Paint the background
                e.Graphics.Clear(Color.Black);
                //Image printImage = ScaleImage(Image);
                //if(printImage != null)
                //    e.Graphics.DrawImage(printImage, SnapToScaledGrid(m_movingPoint));

                //printImage.Dispose();
                e.Graphics.DrawImage(m_scaledBackgroundImage, m_backgroundImagePoint);

                //paint dropped items
                foreach (GifImage image in m_items.Keys)
                {
                    Image itemImage = ScaleImage(image.GetFrame());
                    if (itemImage != null)
                        e.Graphics.DrawImage(itemImage, SnapToScaledGrid(m_items[image]));
                    itemImage.Dispose();
                }

                if (HasMasks)
                {
                    foreach (Mask mask in m_masks)
                    {
                        System.Drawing.Region maskRegion = new Region(Rectangle.Empty);
                        foreach (Tuple<int, int> cell in mask.MaskedCells)
                        {
                            Rectangle cellRec = new Rectangle(SnapToScaledGrid(cell), new Size(Convert.ToInt32(m_scaleDpi), Convert.ToInt32(m_scaleDpi)));
                            maskRegion.Union(cellRec);
                        }

                        e.Graphics.FillRegion(mask.FillBrush, maskRegion);
                    }
                }

                if(m_cellSelection)
                {
                    using (Brush highlight = new SolidBrush(Color.FromArgb(100, Color.Yellow)))
                    {
                        Rectangle highlightRec = new Rectangle(SnapToScaledGrid(m_cellMousePoint), new Size(Convert.ToInt32(m_scaleDpi) * m_cellSelectionSize.Width, Convert.ToInt32(m_scaleDpi) * m_cellSelectionSize.Height));
                        e.Graphics.FillRectangle(highlight, highlightRec);
                    }
                }
            }
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            foreach (GifImage image in m_items.Keys)
            {
                image.MoveToNextFrame();
            }
            if(m_items.Count > 0)
                this.Invalidate();
        }

        private Image ScaleImage(Image image)
        {
            Size scaledSize = new Size((int)(image.Width * m_scaleFactor), (int)(image.Height * m_scaleFactor));
            return new Bitmap(image, scaledSize);
        }

        private Point SnapToScaledGrid(Point point)
        {
            double x = Math.Round((double)point.X / m_scaleDpi) * m_scaleDpi;
            double y = Math.Round((double)point.Y / m_scaleDpi) * m_scaleDpi;
            return new Point((int)x, (int)y);
        }

        private Point SnapToScaledGrid(Tuple<int, int> cell)
        {
            Point topLeft = SnapToScaledGrid(m_movingPoint);
            int cellX = Convert.ToInt32(topLeft.X + (cell.Item1 * m_scaleDpi));
            int cellY = Convert.ToInt32(topLeft.Y + (cell.Item2 * m_scaleDpi));

            return new Point(cellX, cellY);
        }
    }
}
