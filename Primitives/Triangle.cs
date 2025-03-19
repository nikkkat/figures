using System;
using System.Drawing;

namespace Primitives
{
    internal class Triangle : DisplayObject
    {
        protected int x1, x2, x3, y1, y2, y3;
        private SolidBrush mybrush;
        private Pen mypen;
        public Triangle() { }
        public Triangle(int x1, int y1, int x2, int y2, int x3, int y3, int r, int g, int b, int rB, int gB, int bB, int border)
        {
            this.x1 = x1; // координаты треугольника
            this.x2 = x2;
            this.x3 = x3;
            this.y1 = y1;
            this.y2 = y2;
            this.y3 = y3;
            this.mybrush = new SolidBrush(Color.FromArgb(r, g, b));  // инициализация кистей
            this.mypen = new Pen(Color.FromArgb(rB, gB, bB), border);
            // рассчет координат точек клиентской части треугольника
            double medX, medY; // коодинаты медианы противоположной стороны от рассматриваемой точки
            double xxx, yyy; // вспомогательные коэфициенты для определения сдвига координат клиентской части фигуры 
            medX = (x1 + x2) / 2;
            medY = (y1 + y2) / 2;
            xxx = Math.Abs(x3 - medX);
            yyy = Math.Abs(y3 - medY);
            if (x3 > medX) { this.cx3 = x3 - (int)xxx * (border / 40); }
            if (x3 < medX) { this.cx3 = x3 + (int)xxx * (border / 40); }
            if (y3 > medY) { this.cy3 = y3 - (int)yyy * (border / 40); }
            if (y3 < medY) { this.cy3 = y3 + (int)yyy * (border / 40); }

            medX = (x1 + x3) / 2;
            medY = (y1 + y3) / 2;
            xxx = Math.Abs(x2 - medX);
            yyy = Math.Abs(y2 - medY);
            if (x2 > medX) { this.cx2 = x2 - (int)xxx * (border / 40); }
            if (x2 < medX) { this.cx2 = x2 + (int)xxx * (border / 40); }
            if (y2 > medY) { this.cy2 = y2 - (int)yyy * (border / 40); }
            if (y2 < medY) { this.cy2 = y2 + (int)yyy * (border / 40); }

            medX = (x3 + x2) / 2;
            medY = (y3 + y2) / 2;
            xxx = Math.Abs(x1 - medX);
            yyy = Math.Abs(y1 - medY);
            if (x1 > medX) { this.cx1 = x1 - (int)xxx * (border / 40); }
            if (x1 < medX) { this.cx1 = x1 + (int)xxx * (border / 40); }
            if (y1 > medY) { this.cy1 = y1 - (int)yyy * (border / 40); }
            if (y1 < medY) { this.cy1 = y1 + (int)yyy * (border / 40); }
        }
        public override void Draw(Form1 form, Graphics g) 
        {
            g.FillPolygon(mybrush, new Point[] {
                new Point(cx1, cy1),
                new Point(cx2, cy2),
                new Point(cx3, cy3)
            });
            g.DrawPolygon(mypen, new Point[] {
                new Point(x1, y1),
                new Point(x2, y2),
                new Point(x3, y3)
            });
        }
        public override void GetSelectionFrame()
        {
            // координаты левого верхнего угла выделяющейй рамки
            lx = Math.Min(x1, Math.Min(x2, x3)) - 2;
            ly = Math.Min(y1, Math.Min(y2, y3)) - 2;
            // координаты правого нижнего угла выделяющейй рамки
            rx = Math.Max(x1, Math.Min(x2, x3)) + 2;
            ry = Math.Max(y1, Math.Min(y2, y3)) + 2;
            // координаты точки привязки
            x = (lx + rx) / 2;
            y = (ly + ry) / 2;
        }
    }
}
