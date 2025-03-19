using System;
using System.Drawing;
using System.Windows.Forms;

namespace Primitives
{
    internal class Square : Rectangle
    {        
        protected int sideLength;
        public Square() { }
        public Square(int leftX, int leftY, int rightX, int rightY, int r, int g, int b, int rB, int gB, int bB, int border) : base(leftX, leftY, rightX, rightY, r, g, b, rB, gB, bB, border)
        {
            this.sideLength = Math.Min(rightX - leftX, rightY - leftY);
            this.leftX = leftX;  // координаты верхнего левого угла квадрата
            this.leftY = leftY;
            this.mybrush = new SolidBrush(Color.FromArgb(r, g, b));  // инициализация кистей
            this.mypen = new Pen(Color.FromArgb(rB, gB, bB), border);
            // координаты клиентской части квадрата
            this.clientleftX = leftX + border / 2; 
            this.clientleftY = leftY + border / 2;
            this.clientrightX = rightX - border / 2;
            this.clientrightY = rightY - border / 2;            
        }
        public override void Draw(Form1 form, Graphics g)
        {
            g.FillRectangle(mybrush, clientleftX, clientleftY, sideLength-(clientleftX-leftX), sideLength - (clientleftX - leftX));            
            g.DrawRectangle(mypen, leftX, leftY, sideLength, sideLength);                        
        }
        public override void GetSelectionFrame() 
        {
            // координаты левого верхнего угла выделяющейй рамки
            lx = leftX - 2;
            ly = leftY - 2;
            // координаты правого нижнего угла выделяющейй рамки
            rx = leftX + sideLength + 2;
            ry = leftY + sideLength + 2;
            // координаты точки привязки
            x = leftX + sideLength / 2;
            y = leftY + sideLength / 2;
        }
    }
}
