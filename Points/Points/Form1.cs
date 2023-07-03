namespace Points
{
    public partial class Form1 : Form
    {
        private Point pointA;
        private Point pointB;
        private Point pointC;
        private Point pointD;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pointA = Point.Empty;
            pointB = Point.Empty;
            pointC = Point.Empty;
            pointD = Point.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pointA = Point.Empty;
            pointB = Point.Empty;
            pointC = Point.Empty;
            pointD = Point.Empty;

            Refresh();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (pointA.IsEmpty)
            {
                pointA = e.Location;
            }
            else if (pointB.IsEmpty)
            {
                pointB = e.Location;
            }
            else if (pointC.IsEmpty)
            {
                pointC = e.Location;
            }
            else if (pointD.IsEmpty)
            {
                pointD = e.Location;
            }
            else
            {
                pointA = Point.Empty;
                pointB = Point.Empty;
                pointC = Point.Empty;
                pointD = Point.Empty;
            }

            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            if (!pointA.IsEmpty)
            {
                DrawCircle(graphics, Brushes.Black, pointA, 5);
            }
            if (!pointB.IsEmpty)
            {
                DrawCircle(graphics, Brushes.Black, pointB, 5);
            }
            if (!pointC.IsEmpty)
            {
                DrawCircle(graphics, Brushes.Black, pointC, 5);
            }
            if (!pointD.IsEmpty)
            {
                DrawCircle(graphics, Brushes.Black, pointD, 5);
            }

            if (!pointA.IsEmpty && !pointB.IsEmpty)
            {
                int radiusAB = (int)Distance(pointA, pointB);
                DrawCircle(graphics, Brushes.Blue, pointA, radiusAB);
            }

            if (!pointC.IsEmpty && !pointD.IsEmpty)
            {
                int radiusCD = (int)Distance(pointC, pointD);
                DrawCircle(graphics, Brushes.Yellow, pointC, radiusCD);
            }

            using (Font font = new Font("Arial", 12))
            {
                if (!pointA.IsEmpty)
                {
                    graphics.DrawString($"Point A: ({pointA.X}, {pointA.Y})", font, Brushes.Black, 10, 20);
                }
                if (!pointB.IsEmpty)
                {
                    graphics.DrawString($"Point B: ({pointB.X}, {pointB.Y})", font, Brushes.Black, 10, 40);
                }
                if (!pointC.IsEmpty)
                {
                    graphics.DrawString($"Point C: ({pointC.X}, {pointC.Y})", font, Brushes.Black, 10, 60);
                }
                if (!pointD.IsEmpty)
                {
                    graphics.DrawString($"Point D: ({pointD.X}, {pointD.Y})", font, Brushes.Black, 10, 80);
                }
                if (!pointA.IsEmpty && !pointB.IsEmpty && !pointC.IsEmpty && !pointD.IsEmpty)
                {
                    Point intersection = FindCircleIntersection(pointA, pointB, pointC, pointD);
                    graphics.DrawString($"Intersection: ({intersection.X}, {intersection.Y})", font, Brushes.Black, 10, 100);
                }
            }
        }
        private void DrawCircle(Graphics graphics, Brush brush, Point center, int radius)
        {
            int diameter = radius * 2;
            int x = center.X - radius;
            int y = center.Y - radius;
            graphics.FillEllipse(brush, x, y, diameter, diameter);
        }

        private double Distance(Point point1, Point point2)
        {
            int dx = point2.X - point1.X;
            int dy = point2.Y - point1.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        private Point FindCircleIntersection(Point center1, Point point1, Point center2, Point point2)
        {
            double d1 = Distance(point1, center1);
            double d2 = Distance(point2, center2);

            double ratio = d1 / (d1 + d2);

            int dx = center2.X - center1.X;
            int dy = center2.Y - center1.Y;

            int x = center1.X + (int)(dx * ratio);
            int y = center1.Y + (int)(dy * ratio);

            return new Point(x, y);
        }
    }
}