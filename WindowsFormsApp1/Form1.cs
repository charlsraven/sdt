using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public List<Point> arPoints = new List<Point>();
        private Timer moveTimer = new Timer();
        public List<Point> arOffsets = new List<Point>();
        public Color PointColor = Color.LightPink;
        public Size PointSize { get; set; } = new Size(5, 5);
        public enum LineType { None, Curve, Bezier, Polygone, FilledCurve };
        public LineType LineTypeToShow;
        public Color LineColor = Color.LightPink;
        public int lineWidth { get; set; } = 5;
        public bool bDraw = true;
        public bool bDrag = false;
        public bool bMove = false;
        public int iPointToDrag;

        public Form1()
        {
            InitializeComponent();
            Paint += new PaintEventHandler(Form1_Paint);
            MouseClick += new MouseEventHandler(Form1_MouseClick);
            MouseMove += new MouseEventHandler(Form1_MouseMove);
            MouseUp += new MouseEventHandler(Form1_MouseUp);
            MouseDown += new MouseEventHandler(Form1_MouseDown);
            KeyPreview = true;
            KeyDown += new KeyEventHandler(Form1_KeyDown);
            moveTimer.Interval = 30;
            moveTimer.Tick += new EventHandler(TimerTickHandler);
            btPoints.Click += new EventHandler(btPoints_Click);
            btParametrs.Click += new EventHandler(btParametrs_Click);
            btMove.Click += new EventHandler(btMove_Click);
            btClear.Click += new EventHandler(btClear_Click);
            btCurve.Click += new EventHandler(btCurve_Click);
            btPolygone.Click += new EventHandler(btPolygone_Click);
            btBeziers.Click += new EventHandler(btBeziers_Click);
            btFilledCurve.Click += new EventHandler(btFilledCurve_Click);
            btMove.Enabled = false;
            btClear.Enabled = false;
            btCurve.Enabled = false;
            btPolygone.Enabled = false;
            btBeziers.Enabled = false;
            btFilledCurve.Enabled = false;
        }
        void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (arPoints.Count > 0)
            {
                ShowPoints(g);
                if (LineTypeToShow != LineType.None)
                    ShowLine(g, LineTypeToShow);
            }
        }
        void ShowPoints(Graphics g)
        {
            foreach (Point p in arPoints)
                g.FillEllipse(new SolidBrush(PointColor), p.X, p.Y, PointSize.Width, PointSize.Height);
        }
        void ShowLine(Graphics g, LineType line)
        {
            SolidBrush brush = new SolidBrush(LineColor);
            Pen pen = new Pen(brush, lineWidth);
            switch (line)
            {
                case LineType.Bezier:
                    if (arPoints.Count >= 3 && (arPoints.Count - 1) % 3 == 0)
                        g.DrawBeziers(pen, arPoints.ToArray());
                    break;
                case LineType.Curve:
                    if (arPoints.Count > 2)
                        g.DrawClosedCurve(pen, arPoints.ToArray());
                    break;
                case LineType.FilledCurve:
                    g.FillClosedCurve(brush, arPoints.ToArray());
                    break;
                case LineType.Polygone:
                    if (arPoints.Count > 1)
                        g.DrawPolygon(pen, arPoints.ToArray());
                    break;
                default:
                    break;
            }
        }


        void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Point p;
            if (e.X > MinimumSize.Width)
            {
                p = e.Location;
                if (bDraw)
                {
                    arPoints.Add(p);
                    LineTypeToShow = LineType.None;
                    if (arPoints.Count != 0)
                    {
                        if (arPoints.Count > 2)
                        {
                            btBeziers.Enabled = true;
                            btCurve.Enabled = true;
                        }
                        if (arPoints.Count > 1)
                            btPolygone.Enabled = true;
                        btMove.Enabled = true;
                        btClear.Enabled = true;
                        btFilledCurve.Enabled = true;
                    }
                    Refresh();
                }
            }
        }


        void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (bDrag)
            {
                arPoints[iPointToDrag] = new Point(e.Location.X, e.Location.Y);
                Refresh();
            }
        }


        void Form1_MouseUp(object sender, MouseEventArgs e) => bDrag = false;


        void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < arPoints.Count; i++)
                if (IsOnPoint(arPoints[i], e.Location))
                {
                    bDrag = true;
                    iPointToDrag = i;
                    break;
                }
        }
        bool IsOnPoint(Point pPixel, Point pMouse)
        {
            if (pMouse.X >= pPixel.X - PointSize.Width / 2 &&
                pMouse.X <= pPixel.X + PointSize.Width / 2 &&
                pMouse.Y >= pPixel.Y - PointSize.Height / 2 &&
                pMouse.Y <= pPixel.Y + PointSize.Height / 2)
                return true;
            else
                return false;
        }


        void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    btClear_Click(sender, e);
                    bDraw = true;
                    e.Handled = true;
                    break;
                case Keys.Space:
                    btMove_Click(sender, e);
                    e.Handled = true;
                    break;
                case Keys.Oemplus:
                    if (arOffsets.Count > 0)
                    {
                        int x = 0, y = 0;
                        for (int i = 0; i < arOffsets.Count; i++)
                        {
                            if (arOffsets[i].X > 0)
                                x = 1;
                            if (arOffsets[i].X < 0)
                                x = -1;
                            if (arOffsets[i].Y > 0)
                                y = 1;
                            if (arOffsets[i].Y < 0)
                                y = -1;
                            arOffsets[i] = new Point(arOffsets[i].X + x, arOffsets[i].Y + y);
                        }
                    }
                    e.Handled = true;
                    break;
                case Keys.OemMinus:
                    if (arOffsets.Count > 0)
                    {
                        int x = 0, y = 0;
                        for (int i = 0; i < arOffsets.Count; i++)
                        {
                            if (arOffsets[i].X > 0)
                                x = -1;
                            if (arOffsets[i].X < 0)
                                x = 1;
                            if (arOffsets[i].Y > 0)
                                y = -1;
                            if (arOffsets[i].Y < 0)
                                y = 1;
                            arOffsets[i] = new Point(arOffsets[i].X + x, arOffsets[i].Y + y);
                        }
                    }
                    e.Handled = true;
                    break;
                default:
                    break;
            }
        }
        void btClear_Click(object sender, EventArgs e)
        {
            moveTimer.Stop();
            bDrag = false;
            bMove = false;
            arPoints.Clear();
            arOffsets.Clear();
            LineTypeToShow = LineType.None;
            btMove.Enabled = false;
            btClear.Enabled = false;
            btCurve.Enabled = false;
            btPolygone.Enabled = false;
            btBeziers.Enabled = false;
            btFilledCurve.Enabled = false;
            bDraw = true;
            Refresh();
        }
        void btMove_Click(object sender, EventArgs e)
        {
            bDrag = false;
            if (arPoints.Count == 0)
                bMove = false;
            else
            {
                btMove.Enabled = true;
                bMove = !bMove;
            }
            if (bMove)
            {
                int x, y;
                Random rnd = new Random((int)DateTime.Now.Ticks);
                x = rnd.Next(1, 10);
                y = rnd.Next(1, 10);
                for (int i = 0; i < arPoints.Count; i++)
                    arOffsets.Add(new Point(x, y));
                moveTimer.Start();
            }
            else
                moveTimer.Stop();
        }


        void TimerTickHandler(object sender, EventArgs e)
        {
            MovePoints();
            Refresh();
        }
        void MovePoints()
        {
            int x, y;
            if (bDraw)
                btPoints.PerformClick();
            for (int i = 0; i < arPoints.Count; i++)
            {
                x = arPoints[i].X + arOffsets[i].X;
                if (x >= ClientRectangle.Width || x <= MinimumSize.Width)
                {
                    arOffsets[i] = new Point(-arOffsets[i].X, arOffsets[i].Y);
                    x = arPoints[i].X + arOffsets[i].X;
                }
                y = arPoints[i].Y + arOffsets[i].Y;
                if (y >= ClientRectangle.Height || y <= 0)
                {
                    arOffsets[i] = new Point(arOffsets[i].X, -arOffsets[i].Y);
                    y = arPoints[i].Y + arOffsets[i].Y;
                }
                arPoints[i] = new Point(x, y);
            }
        }


        void btPoints_Click(object sender, EventArgs e)
        {
            bDraw = !bDraw;
            bDrag = false;
            bMove = false;
            Refresh();
        }


        void btParametrs_Click(object sender, EventArgs e)
        {
            bDraw = false;
            bDrag = false;
            bMove = false;
            ParamForm paramForm = new ParamForm(this);
            paramForm.Show();
        }


        void btCurve_Click(object sender, EventArgs e)
        {
            if (arPoints.Count > 0)
            {
                if (LineTypeToShow != LineType.Curve)
                    LineTypeToShow = LineType.Curve;
                else
                    LineTypeToShow = LineType.None;
                if (bDraw)
                    btPoints.PerformClick();
                Refresh();
            }
        }


        void btPolygone_Click(object sender, EventArgs e)
        {
            if (arPoints.Count > 0)
            {
                if (LineTypeToShow != LineType.Polygone)
                    LineTypeToShow = LineType.Polygone;
                else
                    LineTypeToShow = LineType.None;
                if (bDraw)
                    btPoints.PerformClick();
                Refresh();
            }
        }


        void btBeziers_Click(object sender, EventArgs e)
        {
            if (arPoints.Count > 0)
            {
                if (LineTypeToShow != LineType.Bezier)
                    LineTypeToShow = LineType.Bezier;
                else
                    LineTypeToShow = LineType.None;
                if (bDraw)
                    btPoints.PerformClick();
                Refresh();
            }
        }


        void btFilledCurve_Click(object sender, EventArgs e)
        {
            if (arPoints.Count > 0)
            {
                if (LineTypeToShow != LineType.FilledCurve)
                    LineTypeToShow = LineType.FilledCurve;
                else
                    LineTypeToShow = LineType.None;
                if (bDraw)
                    btPoints.PerformClick();
                Refresh();
            }
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Up:
                    if (!bMove)
                    {
                        for (int i = 0; i < arPoints.Count; i++)
                        {
                            if (arPoints.Min(a => a.Y) == 0)
                                break;
                            arPoints[i] = new Point(arPoints[i].X, arPoints[i].Y - 1);
                        }
                        Refresh();
                    }
                    break;
                case Keys.Down:
                    if (!bMove)
                    {
                        for (int i = 0; i < arPoints.Count; i++)
                        {
                            if (arPoints.Max(a => a.Y) == ClientRectangle.Height - lineWidth)
                                break;
                            arPoints[i] = new Point(arPoints[i].X, arPoints[i].Y + 1);
                        }
                        Refresh();
                    }
                    break;
                case Keys.Left:
                    if (!bMove)
                    {
                        for (int i = 0; i < arPoints.Count; i++)
                        {
                            if (arPoints.Min(a => a.X) == MinimumSize.Width)
                                break;
                            arPoints[i] = new Point(arPoints[i].X - 1, arPoints[i].Y);
                        }
                        Refresh();
                    }
                    break;
                case Keys.Right:
                    if (!bMove)
                    {
                        for (int i = 0; i < arPoints.Count; i++)
                        {
                            if (arPoints.Max(a => a.X) == ClientRectangle.Width - lineWidth)
                                break;
                            arPoints[i] = new Point(arPoints[i].X + 1, arPoints[i].Y);
                        }
                        Refresh();
                    }
                    break;
                default:
                    return false;
            }
            return true;
        }

        private void Form1_Load(object sender, EventArgs e) { }
    }
}