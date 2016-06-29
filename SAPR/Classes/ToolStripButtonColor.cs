using System;
using System.Windows.Forms;
using System.Drawing;

namespace SAPR.Classes
{
    public class ToolStripButtonColor : ToolStripButton
    {
        public Color Color
        {
            get { return m_color; }
            set
            {
                if (m_color != value)
                {
                    if (Image.Size != Size)
                    {
                        Image.Dispose();
                        Image = new Bitmap(Size.Width, Size.Height);
                    }

                    Bitmap bitmap = Image as Bitmap;
                    for (int y = 0; y < bitmap.Height; y++)
                        for (int x = 0; x < bitmap.Width; x++)
                            bitmap.SetPixel(x, y, value);

                    m_color = value;
                }
            }
        }

        public ToolStripButtonColor()
        {
            Click += (sender, e) =>
            {
                m_colorDialog.Color = Color;
                m_colorDialog.ShowDialog();
                Color = m_colorDialog.Color;
            };

            Image = new Bitmap(Size.Width, Size.Height);
            Color = m_colorDialog.Color;
        }

        private Color m_color;

        private static ColorDialog m_colorDialog = new ColorDialog();
    }
}
