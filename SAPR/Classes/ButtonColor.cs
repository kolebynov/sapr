using System.Windows.Forms;
using System.Drawing;
using System;

namespace SAPR.Classes
{
    public partial class ButtonColor : Button
    {
        public event EventHandler ColorChanged;

        public Color Color
        {
            get { return m_color; }
            set
            {
                if (m_color != value)
                {
                    Bitmap bitmap = Image as Bitmap;
                    for (int y = 0; y < bitmap.Height; y++)
                        for (int x = 0; x < bitmap.Width; x++)
                            bitmap.SetPixel(x, y, value);

                    m_color = value;
                }
            }
        }

        public ButtonColor()
        {
            Click += (sender, e) =>
            {
                m_colorDialog.Color = Color;
                m_colorDialog.ShowDialog();
                Color = m_colorDialog.Color;

                if (ColorChanged != null)
                    ColorChanged(this, new EventArgs());
            };

            Image = new Bitmap(Size.Width, Size.Height);
            Color = m_colorDialog.Color;

            Resize += (sender, e) =>
            {
                Image.Dispose();
                Image = null;
                Image = new Bitmap(Size.Width, Size.Height);
            };
        }

        private Color m_color;

        private static ColorDialog m_colorDialog = new ColorDialog();
    }
}
