using System;
using System.Drawing;

namespace Primitives
{
    internal class Circle : Ellipse
    {
        protected int diameter;
        public Circle() { }
        public Circle(int x, int y, int diameter, int r, int g, int b, int rB, int gB, int bB, int border) : base(x, y, diameter, diameter, r, g, b, rB, gB, bB, border)
        {      
            this.diameter = diameter;
            this.mybrush = new SolidBrush(Color.FromArgb(r, g, b));  // инициализация кистей
            this.mypen = new Pen(Color.FromArgb(rB, gB, bB), border);
            this.leftX = x; // координаты верхнего левого угла квадрата, внутри которого строится круг
            this.leftY = y;
            // координаты клиентской части квадрата, внутри которого строится круг
            this.clientleftX = x + border / 2; 
            this.clientleftY = y + border / 2;
            this.clientrightX = x + diameter - border / 2;
            this.clientrightY = y + diameter - border / 2;
        }
        public override void Draw(Form1 form, Graphics g) 
        {
            g.FillEllipse(mybrush, clientleftX, clientleftY, clientrightX - clientleftX, clientrightY - clientleftY);            
            g.DrawEllipse(mypen, leftX, leftY, diameter, diameter);          
        }
        public override void GetSelectionFrame() 
        {
            // координаты левого верхнего угла выделяющейй рамки
            lx = leftX - 2;
            ly = leftY - 2;
            // координаты правого нижнего угла выделяющейй рамки
            rx = leftX + diameter + 2;
            ry = leftY + diameter + 2;
            // координаты точки привязки
            x = leftX + diameter / 2;
            y = leftY + diameter / 2;
        }
    }
}
