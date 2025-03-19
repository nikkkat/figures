using System;
using System.Drawing;

namespace Primitives
{
    internal class DisplayObject
    {
        protected int R, G, B; // цвет заливки примитива   
        protected int Rb, Gb, Bb; // цвет рамки примитива        
        protected int penW; // толщина рамки примитива        
        protected int lx, ly; // координаты левого верхнего угла выделяющей рамки
        protected int rx, ry; // координаты правого нижнего угла выделяющей рамки
        protected int x, y; // координаты точки привязки
        protected int clientleftX, clientleftY, clientrightX, clientrightY; // координаты клиентской области фигуры
        protected int cx1, cx2, cx3, cy1, cy2, cy3; // координаты клиентской области треугольника
        // метод для отрисовки объектов
        public virtual void Draw(Form1 form, Graphics nG)
        {
        }
        // метод для подсчета выделяющей рамки
        public virtual void GetSelectionFrame()
        {                 
        }
        public virtual void Update()
        {
        }
    }
}
