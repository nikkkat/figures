using System;
using System.Drawing;

namespace Primitives
{
    internal class Ellipse : DisplayObject
    {
        protected int width, height;
        protected int leftX, leftY;
        protected SolidBrush mybrush;
        protected Pen mypen;
        public Ellipse() { }
        public Ellipse(int x, int y, int width, int height, int r, int g, int b, int rB, int gB, int bB, int border)
        {
            this.width = width;
            this.height = height;
            this.leftX = x; // координаты левого верхнего угла прямоугольника, внутри которого строится эллипс
            this.leftY = y;
            this.mybrush = new SolidBrush(Color.FromArgb(r, g, b));  // инициализация кистей
            this.mypen = new Pen(Color.FromArgb(rB, gB, bB), border);
            // координаты клиентской части прямоугольника, внутри которого строится эллипс
            this.clientleftX = leftX + border / 2;
            this.clientleftY = leftY + border / 2;
            this.clientrightX = leftX + width - border / 2;
            this.clientrightY = leftY + height - border / 2;
        }        
        public override void Draw(Form1 form, Graphics g) 
        {           
            g.FillEllipse(mybrush, clientleftX, clientleftY, clientrightX - clientleftX, clientrightY - clientleftY);          
            g.DrawEllipse(mypen, leftX, leftY, width, height);
        }
        public override void GetSelectionFrame()
        {
            // координаты левого верхнего угла выделяющейй рамки
            lx = leftX - 2;
            ly = leftY - 2;
            // координаты правого нижнего угла выделяющейй рамки
            rx = leftX + width + 2;
            ry = leftY + height + 2;
            // координаты точки привязки
            x = leftX + width / 2;
            y = leftY + height / 2;
        }
    }    
}
