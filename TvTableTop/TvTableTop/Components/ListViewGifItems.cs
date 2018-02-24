using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TvTableTop.Components
{
    public partial class ListViewGifItems : ListView
    {
        public event EventHandler<ActiveItemChangedEventArgs> ActiveItemChanged;

        private ListViewItem m_activeItem = null;
        private GifImage m_selectedGif = null;

        public ListViewGifItems()
        {
            InitializeComponent();

            this.View = View.LargeIcon;
            this.Activation = ItemActivation.OneClick;
            this.DoubleBuffered = true;
            //this.OwnerDraw = true;

            this.ItemActivate += ListViewGifItems_ItemActivate;
            //this.DrawItem += ListViewGifItems_DrawItem;
            //this.DrawSubItem += ListViewGifItems_DrawSubItem;
            //this.DrawColumnHeader += ListViewGifItems_DrawColumnHeader;

            //InitItemsList();
        }

        public ListViewGifItems(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            this.View = View.LargeIcon;
            this.Activation = ItemActivation.OneClick;
            this.DoubleBuffered = true;
            //this.OwnerDraw = true;

            this.ItemActivate += ListViewGifItems_ItemActivate;
            //this.DrawItem += ListViewGifItems_DrawItem;
            //this.DrawSubItem += ListViewGifItems_DrawSubItem;
            //this.DrawColumnHeader += ListViewGifItems_DrawColumnHeader;

            //InitItemsList();
        }

        public ListViewItem ActiveItem
        {
            get
            {
                return m_activeItem;
            }
            private set
            {
                if (m_activeItem != value)
                {
                    m_activeItem = value;
                    if(m_activeItem != null)
                    {
                        //raise event
                        ActiveItemChanged?.Invoke(this, new ActiveItemChangedEventArgs(m_selectedGif));
                    }
                }
            }
        }

        public void InitItemsList()
        {
            Assembly ThisAssembly = Assembly.GetExecutingAssembly();
            Stream FireThumbImageStream = ThisAssembly.GetManifestResourceStream(ResourceManager.FireThumb);
            Image FireThumbImage = Image.FromStream(FireThumbImageStream);
            Stream AcidThumbImageStream = ThisAssembly.GetManifestResourceStream(ResourceManager.AcidThumb);
            Image AcidThumbImage = Image.FromStream(AcidThumbImageStream);
            Stream PlantGrowthThumbImageStream = ThisAssembly.GetManifestResourceStream(ResourceManager.PlantGrowthThumb);
            Image PlantGrowthThumbImage = Image.FromStream(PlantGrowthThumbImageStream);
            Stream IceThumbImageStream = ThisAssembly.GetManifestResourceStream(ResourceManager.IceThumb);
            Image IceThumbImage = Image.FromStream(IceThumbImageStream);
            Stream GenericThumbImageStream = ThisAssembly.GetManifestResourceStream(ResourceManager.GenericThumb);
            Image GenericThumbImage = Image.FromStream(GenericThumbImageStream);

            ImageList itemsImageList = new ImageList();
            //fire
            itemsImageList.ImageSize = new Size(96, 96);
            itemsImageList.Images.Add("fire", FireThumbImage);
            ListViewItem fireItem = new ListViewItem("fire 2x2");
            fireItem.ImageKey = "fire";
            fireItem.Tag = ResourceManager.Fire2x2;

            //acid
            itemsImageList.ImageSize = new Size(96, 96);
            itemsImageList.Images.Add("acid", AcidThumbImage);
            ListViewItem acidItem = new ListViewItem("acid 2x2");
            acidItem.ImageKey = "acid";
            acidItem.Tag = ResourceManager.Acid2x2;

            //plant growth
            itemsImageList.ImageSize = new Size(96, 96);
            itemsImageList.Images.Add("plant_growth", PlantGrowthThumbImage);
            ListViewItem plantGrowthItem = new ListViewItem("plant growth 2x2");
            plantGrowthItem.ImageKey = "plant_growth";
            plantGrowthItem.Tag = ResourceManager.PlantGrowth2x2;

            //ice
            itemsImageList.ImageSize = new Size(96, 96);
            itemsImageList.Images.Add("ice", IceThumbImage);
            ListViewItem IceItem = new ListViewItem("ice 2x2");
            IceItem.ImageKey = "ice";
            IceItem.Tag = ResourceManager.Ice2x2;

            //generic
            itemsImageList.ImageSize = new Size(96, 96);
            itemsImageList.Images.Add("generic", GenericThumbImage);
            ListViewItem genericItem = new ListViewItem("generic 2x2");
            genericItem.ImageKey = "generic";
            genericItem.Tag = ResourceManager.Generic2x2;

            this.LargeImageList = itemsImageList;

            this.Items.Add(fireItem);
            this.Items.Add(acidItem);
            this.Items.Add(plantGrowthItem);
            this.Items.Add(IceItem);
            this.Items.Add(genericItem);
        }

        public void ClearActiveItem()
        {
            m_activeItem = null;
            m_selectedGif = null;
        }

        private void ListViewGifItems_ItemActivate(object sender, EventArgs e)
        {
            if (this.SelectedItems.Count > 0)
            {
                ListViewItem item = this.SelectedItems[0];
                if (item != null)
                {
                    string imageResource = (string)item.Tag;
                    if (!string.IsNullOrEmpty(imageResource))
                    {
                        Assembly ThisAssembly = Assembly.GetExecutingAssembly();
                        Stream imageStream = ThisAssembly.GetManifestResourceStream(imageResource);
                        Image image = Image.FromStream(imageStream);

                        m_selectedGif = new GifImage(image);

                        ActiveItem = item;

                        return;
                    }
                }
            }

            m_activeItem = null;
            m_selectedGif = null;
        }

        private void ListViewGifItems_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawBackground();
            if ((e.State & ListViewItemStates.Selected) != 0)
            {
                // Draw the background and focus rectangle for a selected item.
                e.Graphics.FillRectangle(Brushes.Maroon, e.Bounds);
                e.DrawFocusRectangle();
            }
            //if (m_activeItem != null && e.Item == m_activeItem)
            //{
            //    //Draw the background and focus rectangle for a selected item.
            //    e.Graphics.FillRectangle(Brushes.Maroon, e.Bounds);
            //    e.DrawFocusRectangle();
            //}
            else
            {
                // Draw the background for an unselected item.
                using (LinearGradientBrush brush =
                    new LinearGradientBrush(e.Bounds, Color.Orange,
                    Color.Maroon, LinearGradientMode.Horizontal))
                {
                    e.Graphics.FillRectangle(brush, e.Bounds);
                }
            }

            // Draw the item text for views other than the Details view.
            if (this.View != View.Details)
            {
                e.DrawText();
            }
        }

        private void ListViewGifItems_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            TextFormatFlags flags = TextFormatFlags.Left;

            using (StringFormat sf = new StringFormat())
            {
                // Store the column text alignment, letting it default
                // to Left if it has not been set to Center or Right.
                switch (e.Header.TextAlign)
                {
                    case HorizontalAlignment.Center:
                        sf.Alignment = StringAlignment.Center;
                        flags = TextFormatFlags.HorizontalCenter;
                        break;
                    case HorizontalAlignment.Right:
                        sf.Alignment = StringAlignment.Far;
                        flags = TextFormatFlags.Right;
                        break;
                }

                // Draw the text and background for a subitem with a 
                // negative value. 
                double subItemValue;
                if (e.ColumnIndex > 0 && Double.TryParse(
                    e.SubItem.Text, NumberStyles.Currency,
                    NumberFormatInfo.CurrentInfo, out subItemValue) &&
                    subItemValue < 0)
                {
                    // Unless the item is selected, draw the standard 
                    // background to make it stand out from the gradient.
                    if ((e.ItemState & ListViewItemStates.Selected) == 0)
                    {
                        e.DrawBackground();
                    }

                    // Draw the subitem text in red to highlight it. 
                    e.Graphics.DrawString(e.SubItem.Text,
                        this.Font, Brushes.Red, e.Bounds, sf);

                    return;
                }

                // Draw normal text for a subitem with a nonnegative 
                // or nonnumerical value.
                e.DrawText(flags);
            }
        }

        private void ListViewGifItems_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            using (StringFormat sf = new StringFormat())
            {
                // Store the column text alignment, letting it default
                // to Left if it has not been set to Center or Right.
                switch (e.Header.TextAlign)
                {
                    case HorizontalAlignment.Center:
                        sf.Alignment = StringAlignment.Center;
                        break;
                    case HorizontalAlignment.Right:
                        sf.Alignment = StringAlignment.Far;
                        break;
                }

                // Draw the standard header background.
                e.DrawBackground();

                // Draw the header text.
                using (Font headerFont =
                            new Font("Helvetica", 10, FontStyle.Bold))
                {
                    e.Graphics.DrawString(e.Header.Text, headerFont,
                        Brushes.Black, e.Bounds, sf);
                }
            }
            return;
        }
    }
}
