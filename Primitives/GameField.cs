using System;
using System.Drawing;
using System.Windows.Forms;

namespace Primitives
{
    internal class GameField : Rectangle 
    {
        public DisplayObject[] objects = new DisplayObject[61];// массив объектов DisplayObject
        public int rightX, rightY, bor;
        Random random = new Random();
        public GameField(int leftX, int leftY, int rightX, int rightY, int r, int g, int b, int rB, int gB, int bB, int border) :base(leftX, leftY, rightX, rightY, r, g, b, rB, gB, bB, border)
        {     
            this.width = Math.Abs(rightX - leftX); // ширина поля
            this.height = Math.Abs(rightY - leftY);
            
            // проверка координат поля, чтоб было в границах экрана
            if (leftX < border / 2) { this.leftX = border / 2; }
            if (leftY < border / 2) { this.leftY = border / 2; }
            if (leftX + width > 1900) { this.rightX = 1900; }
            else { this.rightX = leftX + width; }
            if (leftY + height > 1020) { this.rightY = 1000; }
            else { this.rightY = leftY + height; }
            this.bor = border;
            this.mybrush = new SolidBrush(Color.FromArgb(r, g, b)); // инициализация кистей
            this.mypen = new Pen(Color.FromArgb(rB, gB, bB), border);
            this.clientleftX = leftX + border / 2; // координаты клиентской части прямоугольника
            this.clientleftY = leftY + border / 2;
            this.clientrightX = rightX - border / 2;
            this.clientrightY = rightY - border / 2;

            
        }
        public override void Draw(Form1 form, Graphics g)   
        {
            g.FillRectangle(mybrush, clientleftX, clientleftY, clientrightX - clientleftX, clientrightY - clientleftY);
            g.DrawRectangle(mypen, leftX, leftY, width, height);            
        }
        // метод, вызывающий отрисовку всех объектов массива
        public void DrawObjects(Form1 form, Graphics g)
        {
            if (objects != null)
            {
                for (int i =0; i<61; i++)
                {
                    objects[i]?.Draw(form, g);
                }
            }
        }
        // метод для создания и добавления объектов в массив
        public void Add(DisplayObject obj, int num)
        {
            int startX, startY, endX, endY;
            // нахождение первого пустого слота в массиве и добавление объекта
            for (int i = 0; i < objects.Length; i++)
            {
                R = random.Next(255);
                G = random.Next(255);
                B = random.Next(255);
                Rb = random.Next(255);
                Gb = random.Next(255);
                Bb = random.Next(255);
                penW = random.Next(1, 10);
                if (obj is GameField && objects[i] == null && num > 0)
                {                    
                    // создание объекта игрового поля
                    GameField gamef = new GameField(leftX, leftY, rightX, rightY, R, G, B, Rb, Gb, Bb, bor);
                    objects[i] = gamef;
                    num--;
                    break;
                }
                if (obj is Rectangle && objects[i] == null && num > 0)
                {
                    // генерация координат прямоугольника
                    startX = random.Next(leftX + 20, rightX - 20);
                    startY = random.Next(leftY + 20, rightY - 20);
                    endX = random.Next(startX, rightX - 20);
                    endY = random.Next(startY, rightY - 20);
                    
                    // создание объекта прямоугольника
                    Rectangle rectangle = new Rectangle(startX, startY, endX, endY, R, G, B, Rb, Gb, Bb, penW);
                    objects[i] = rectangle;
                    num--;
                    continue;
                }
                if (obj is Line && objects[i] == null && num > 0)
                {
                    // генерация координат линии
                    startX = random.Next(leftX + 20, rightX - 20);
                    startY = random.Next(leftY + 20, rightY - 20);
                    endX = random.Next(leftX + 20, rightX - 20);
                    endY = random.Next(leftY + 20, rightY - 20);
                    // создание объекта линии
                    Line line = new Line(startX, startY, endX, endY, R, G, B, penW);
                    objects[i] = line;
                    num--;
                    continue;
                }
                if (obj is Ellipse && objects[i] == null && num > 0)
                {
                    // генерация координат прямоугольника, в котором будет находиться эллипс
                    startX = random.Next(leftX + 20, rightX - 20);
                    startY = random.Next(leftY + 20, rightY - 20);
                    endX = random.Next(startX, rightX - 20);
                    endY = random.Next(startY, rightY - 20);
                    // создание объекта эллипса
                    Ellipse ellipse = new Ellipse(startX, startY, Math.Abs(startX - endX), Math.Abs(startY - endY), R, G, B, Rb, Gb, Bb, penW);
                    objects[i] = ellipse;
                    num--;
                    continue;
                }
                if (obj is Circle && objects[i] == null && num > 0)
                {
                    // генерация параметров круга
                    startX = random.Next(leftX + 20, rightX - 20);
                    startY = random.Next(leftY + 20, rightY - 20);
                    int maxDiameter = Math.Min(rightX - startX, rightY - startY) - 20;
                    int diameter = random.Next(maxDiameter);
                    // создание объекта круга
                    Circle circle = new Circle(startX, startY, diameter, R, G, B, Rb, Gb, Bb, penW);
                    objects[i] = circle;
                    num--;
                    continue;
                }
                if (obj is Square && objects[i] == null && num > 0)
                {
                    // генерация координат квадрата
                    startX = random.Next(leftX + 20, rightX - 20);
                    startY = random.Next(leftY + 20, rightY - 20);
                    endX = Math.Min(rightX - 20, startX + random.Next(20, rightX - startX));
                    endY = Math.Min(rightY - 20, startY + random.Next(20, rightY - startY));
                    // создание объекта квадрата
                    Square square = new Square(startX, startY, endX, endY, R, G, B, Rb, Gb, Bb, penW);
                    objects[i] = square;
                    num--;
                    continue;
                }
                if (obj is Triangle && objects[i] == null && num > 0)
                {
                    // генерация координат треугольника
                    int x1 = random.Next(leftX + 50, rightX - 30);
                    int y1 = random.Next(leftY + 35, rightY - 35);
                    int x2 = random.Next(leftX + 50, rightX - 30);
                    int y2 = random.Next(leftY + 35, rightY - 35);
                    int x3 = random.Next(leftX + 50, rightX - 30);
                    int y3 = random.Next(leftY + 35, rightY - 35);
                    // создание объекта треугольника
                    Triangle triangle = new Triangle(x1, y1, x2, y2, x3, y3, R, G, B, Rb, Gb, Bb, penW);
                    objects[i] = triangle;
                    num--;
                    continue;
                }
            }
        }
        // метод для удаления объекта из массива
        public void Delete(DisplayObject obj)
        {
            for (int i = 0; i < objects.Length; i++)
            {
                if (objects[i] != null)
                {
                    if (objects[i].Equals(obj))
                    {
                        objects[i] = null;
                        break;
                    }
                }
            }
        }
        public override void GetSelectionFrame()    
        {
            // координаты левого верхнего угла выделяющей рамки
            lx = leftX - 2; 
            ly = leftY - 2;
            // координаты правого нижнего угла выделяющей рамки
            rx = leftX + width + 2;
            ry = leftY + height + 2;
            // координаты точки привязки
            x = leftX + width / 2;
            y = leftY + height / 2;
        }
    }
}
