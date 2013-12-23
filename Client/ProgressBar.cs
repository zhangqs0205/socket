using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class ProgressBar : UserControl
    {
        private Timer timer = new Timer();
        Rectangle[] Rectangles = new Rectangle[5];
        int offsetFast = 35;
        int offsetSlow = 12;
        private Color _EllipseColor = Color.BlueViolet;
        public Color EllipseColor
        {
            get
            {
                return _EllipseColor;
            }
            set
            {
                _EllipseColor = value;
            }
        }
        public ProgressBar()
        {
            InitializeComponent();
            Init();
        }
        private void Init()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint |
                                ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();
            InitRect();
            timer.Interval = 100;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Enabled = true;
        }
        void timer_Tick(object sender, EventArgs e)
        {
            if (Rectangles[4].Location.X > this.Width)
            {
                InitRect();
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    Point tmp = Rectangles[i].Location;
                    if (Rectangles[i].X >= this.Width / 3 && Rectangles[i].X < this.Width / 3 * 2)
                    {
                        Rectangles[i] = new Rectangle(new Point(tmp.X + offsetSlow, tmp.Y), new Size(Height - 4, Height - 4));
                    }
                    else
                    {
                        Rectangles[i] = new Rectangle(new Point(tmp.X + offsetFast, tmp.Y), new Size(Height - 4, Height - 4));
                    }
                }
            }
            this.Invalidate();
        }
        private void InitRect()
        {
            int baseX = -20;
            for (int i = 0; i < 5; i++)
            {
                Rectangles[i] = new Rectangle(new Point(baseX - i * 100, 2), new Size(Height - 4, Height - 4));
            }
        }
        private void Draw(Graphics g)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            for (int i = 1; i < 5; i++)
            {
                g.FillEllipse(new SolidBrush(EllipseColor), Rectangles[i]);
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Draw(e.Graphics);
        }
    }
}
