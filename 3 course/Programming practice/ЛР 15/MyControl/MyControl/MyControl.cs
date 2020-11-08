using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace MyControl
{
    public partial class MyControl : Component
    {
        public MyControl()
        {
            InitializeComponent();

            InstanceID = NextInstanceID++;
            ClassInstanceCount++;                                       
        }        

        public MyControl(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        ~MyControl()
        {
            ClassInstanceCount--;
        }

        public readonly int InstanceID;
        private static int NextInstanceID = 0;
        private static long ClassInstanceCount = 0;

        public static long InstanceCount
        {
            get
            {
                return ClassInstanceCount;
            }
        }        
    }

    [Description("Модифицированный компонент PictureBox")]
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(PictureBoxControl), "icon.bmp")]
    [DesignerAttribute("MyControl.PictureBoxControlDesigner")]
    [DefaultBindingPropertyAttribute("Image")]
    [DockingAttribute(DockingBehavior.Ask)]
    public partial class PictureBoxControl : PictureBox
    {
        private bool changebutton = true;
        private Color startcolor = Color.White;
        private Color endcolor = Color.Black;
        private float size = 8.25F;
        private string fontname = "Microsoft Sans Serif";

        //Конструктор
        public PictureBoxControl()
        {
            
        }

        public PictureBoxControl(IContainer container)
        {
            container.Add(this);            
        }

        //Заливка из начала
        [Category("Градиент"), Description("Цвет начала заливки"), DefaultValue(typeof(Color), "Red")]
        public Color StartColor
        {
            get { return startcolor; }
            set
            {
                startcolor = value;
                onChange();
            }
        }

        //Заливка в конец
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

        //Перерисовка
        public void onChange()
        {
            Invalidate();
        }

        public string onEnableStatmentVoid()
        {
            return "8986838.jpeg";            
        }

        //Изменение размера
        [Category("Трансформация"), Description("Изменение размера"), DefaultValue(typeof(bool), "true")]
        public bool DynamicSize
        {
            get { return changebutton; }
            set
            {
                changebutton = value;
            }
        }

        //При нажатии 
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

        //При отпуске
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
    }
}
