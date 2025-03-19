using System;
using System.Drawing;

namespace Primitives
{
    internal class Rectangle : DisplayObject
    {
        public int width, height;
        public int leftX, leftY;        
        protected SolidBrush mybrush;
        protected Pen mypen;
        public Rectangle() { }
        public Rectangle(int leftX, int leftY, int rightX, int rightY, int r, int g, int b, int rB, int gB, int bB, int border)
        {
            this.width = Math.Abs(rightX-leftX);
            this.height = Math.Abs(rightY - leftY);
            this.leftX = leftX;  // координаты верхнего левого угла прямоугольника
            this.leftY = leftY;
            this.mybrush = new SolidBrush(Color.FromArgb(r, g, b)); // инициализация кистей
            this.mypen = new Pen(Color.FromArgb(rB, gB, bB), border);
            // координаты клиентской части прямоугольника
            this.clientleftX = leftX + border/2;
            this.clientleftY = leftY + border/2;
            this.clientrightX = rightX - border/2;
            this.clientrightY = rightY - border/2;

            
        }
        public override void Draw(Form1 form, Graphics g)  
        {          
            g.FillRectangle(mybrush, clientleftX, clientleftY, clientrightX-clientleftX, clientrightY-clientleftY);           
            g.DrawRectangle(mypen, leftX, leftY, width, height);
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
