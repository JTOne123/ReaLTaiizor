﻿#region Imports

using System.Drawing;
using System.Windows.Forms;

#endregion

namespace ReaLTaiizor
{
    #region RoyalEllipseButton

    public class RoyalEllipseButton : RoyalButton
    {
        public RoyalEllipseButton() : base()
        {
            Size = new Size(120, 120);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Color foreColor = ForeColor;
            Color backColor = BackColor;
            Color borderColor = BackColor;

            if (HotTracked && !Pressed)
            {
                backColor = HotTrackColor;
                borderColor = backColor;
            }
            else if (Pressed)
            {
                foreColor = PressedForeColor;
                backColor = PressedColor;
                borderColor = backColor;
            }

            if (DrawBorder)
                borderColor = BorderColor;

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.FillEllipse(new SolidBrush(backColor), new Rectangle(2, 2, Width - (BorderThickness + 1), Height - (BorderThickness + 1)));
            e.Graphics.DrawEllipse(new Pen(BorderColor, BorderThickness), new Rectangle(1, 1, Width - BorderThickness, Height - BorderThickness));

            if (Image != null)
            {
                if (LayoutFlags == RoyalLayoutFlags.ImageOnly)
                    e.Graphics.DrawImage(Image, new Point((Width - Image.Width) / 2, (Height - Image.Height) / 2));
            }
            else
                TextRenderer.DrawText(e.Graphics, Text, Font, e.ClipRectangle, foreColor,
                    Color.Transparent, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

            //base.OnPaint(e);
        }
    }

    #endregion
}