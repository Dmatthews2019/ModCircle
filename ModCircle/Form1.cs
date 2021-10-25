using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModCircle
{
    public partial class Form1 : Form
    {

        Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
        public Point centre;
        List<Point> CirclePoints = new List<Point>();
        const float degToRad = 0.0174533f;
        int modNumber = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pen.Color = Color.Blue;
            centre = new Point(panel1.Width / 2, panel1.Height / 2);
            CirclePoints = InstantiatePoints(360, panel1.Height / 3);
            panel1.Refresh();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            DrawLines(e);
            Text = "ModCircle";
        }

        private List<Point> InstantiatePoints(int ammount, float magnitude) {
            List<Point> tempPoints = new List<Point>();
            for (int i = 0; i < ammount; i++)
            {
                float degree = (float)i * degToRad;
                int x = (int)(centre.X + ((float)Math.Sin(degree) * magnitude));
                int y = (int)(centre.Y + ((float)Math.Cos(degree) * magnitude));
                Point tempPoint = new Point(x, y);
                tempPoints.Add(tempPoint);
            }
            return tempPoints;
        }

        private void DrawLines( PaintEventArgs e) {
            for (int i = 0; i < CirclePoints.Count; i++)
            {
                int modPoint = (i * modNumber) % CirclePoints.Count;
                e.Graphics.DrawLine(pen, CirclePoints[i], CirclePoints[modPoint]);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel1.Refresh();
            modNumber ++;
            modNumber = modNumber % CirclePoints.Count;
            
        }
    }
}
