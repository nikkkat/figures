using System;
using System.Drawing;

namespace Primitives
{
    internal class Line : DisplayObject
    {
        private int startX, endX;
        private int startY, endY;
        private Pen mypen;
        public Line() { }
        public Line(int startX, int startY, int endX, int endY, int r, int g, int b, int border)
        {           
            this.startX = startX; // начальная точка линии
            this.startY = startY;
            this.endX = endX; // конечная точка линии
            this.endY = endY;
            this.mypen = new Pen(Color.FromArgb(r, g, b), border); // инициализация кисти
        }
        public override void Draw(Form1 form, Graphics g) 
        {
            g.DrawLine(mypen, startX, startY, endX, endY);            
        }
        public override void GetSelectionFrame()  
        {
            // координаты левого верхнего угла выделяющейй рамки
            lx = Math.Min(startX, endX) - 2;
            ly = Math.Min(startY, endY) - 2;
            // координаты правого нижнего угла выделяющейй рамки
            rx = Math.Max(startX, endX) + 2;
            ry = Math.Max(startY, endY) + 2;
            // координаты точки привязки
            x = (rx + lx)/2;
            y = (ry + ly)/2;            
        }
    }
}
