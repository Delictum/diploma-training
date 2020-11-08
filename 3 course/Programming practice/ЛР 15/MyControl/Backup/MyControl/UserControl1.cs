using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace MyControl
{
    [Description("Модифицированный компонент Button")]
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(ButtonControl), "icon.bmp")]
    [DesignerAttribute("MyControl.ButtonControlDesigner")]
    public partial class ButtonControl : Button
    {
        private bool changebutton = true;
        private Color startcolor = Color.White;
        private Color endcolor = Color.Black;
        private float size = 8.25F;
        private string fontname = "Microsoft Sans Serif";
        public LinearGradientMode mode;

        [Category("Градиент"), Description("Цвет начала заливки"), DefaultValue(typeof(Color),"Red")]
        public Color StartColor 
        {
            get { return startcolor; }
            set 
            { 
                startcolor = value; 
                onChange(); 
            }
        }

        [Category("Градиент"), Description("Цвет завершения заливки"), DefaultValue(typeof(Color), "Blue")]
        public Color EndColor 
        {
            get { return endcolor; }
            set 
            { 
                endcolor = value; 
                onChange(); 
            }
        }

        [Category("Градиент"), Description("Способ заливки"), DefaultValue(typeof(LinearGradientMode), "Horizontal")]
        public LinearGradientMode GradientMode 
        {
            get { return mode; }
            set 
            { 
                mode = value;
                onChange(); 
            }
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
             base.OnPaint(pevent);
             Color col1 = Color.FromArgb(100, startcolor);
             Color col2 = Color.FromArgb(100, endcolor);
             Brush brush = new System.Drawing.Drawing2D.LinearGradientBrush(ClientRectangle, col1, col2, mode);
             pevent.Graphics.FillRectangle(brush, ClientRectangle);
             brush.Dispose();
        }

        public void onChange() 
        {
            Invalidate();
        }

        [Category("Трансформация кнопки"), Description("Изменение размера кнопки"), DefaultValue(typeof(bool), "true")]
        public bool DynamicSize 
        {
            get { return changebutton; }
            set 
            { 
                changebutton = value; 
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            if (changebutton == true)
            {
                base.OnMouseEnter(e);
                this.Width += 20;
                this.Height += 10;
                this.Font = new System.Drawing.Font(fontname, size + 1.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                this.Location = new System.Drawing.Point(Location.X - 10, Location.Y - 5);
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            if (changebutton == true)
            {
                base.OnMouseLeave(e);
                this.Width -= 20;
                this.Height -= 10;
                this.Font = new System.Drawing.Font(fontname, size, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                this.Location = new System.Drawing.Point(Location.X + 10, Location.Y + 5);
            }
        }

        [Browsable(false)]
        public float FontSize
        {
            get { return size; }
            set 
            { 
                size = this.Font.Size; 
                onChange(); 
            }
        }

        [Browsable(false)]
        public string FontName 
        {
            get { return fontname; }
            set 
            { 
                fontname = this.Font.Name; 
                onChange(); 
            }
        }

        public ButtonControl()
        {
            InitializeComponent();
        }
    }

    class ButtonControlDesigner : ControlDesigner
    {
        protected bool mouseOver;

        protected override void OnPaintAdornments(PaintEventArgs pe)
        {
            base.OnPaintAdornments(pe);
            if (mouseOver)
            {
                Font font = new Font("Microsoft Sand Selif", 7F);
                string s = "(с)Разработал Кочнев Кирилл";
                pe.Graphics.DrawString(s, font, new SolidBrush(Color.Black), 0, this.Control.Height-(int)pe.Graphics.MeasureString(s, font).Height-3);
            }
        }

        protected override void OnMouseEnter()
        {
            mouseOver = true;
            base.OnMouseEnter();
            Control.Invalidate();
        }

        protected override void OnMouseLeave()
        {
            mouseOver = false;
            base.OnMouseLeave();
            Control.Invalidate();
        }

        protected override void PreFilterProperties(System.Collections.IDictionary properties)
        {
            base.PreFilterProperties(properties);
            properties.Remove("BackColor");
            properties.Remove("FlatAppearance");
            properties.Remove("BackgroundImage");
            properties.Remove("BackgroundImageLayout");
            properties.Remove("Image");
            properties.Remove("ImageAlign");
            properties.Remove("ImageIndex");
            properties.Remove("ImageKey");
            properties.Remove("ImageList");
            properties.Remove("MaximumSize");
            properties.Remove("MinimumSize");
            properties.Remove("RightToLeft");
            properties.Remove("TextImageRelation");
            properties.Remove("ContextMenuStrip");
        }
    }
}
