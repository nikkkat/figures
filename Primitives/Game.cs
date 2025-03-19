using System;

namespace Primitives
{
    internal class Game : DisplayObject
    {
        public GameField gameField;
        // координаты игрового поля
        public int lX = 0, lY = 0, rX = 800, rY = 650, bor = 10;
               
        public Game()
        {            
            InitializeObjects();
        }
        // метод иниициализации объектов
        public void InitializeObjects()
        {
            gameField = new GameField(lX, lY, rX, rY, 255, 255, 255, 0, 0, 0, bor);
            gameField.Add(gameField, 1);

            Rectangle rectangle = new Rectangle(); 
            gameField.Add(rectangle, 10);

            Line line = new Line();
            gameField.Add(line, 10);

            Ellipse ellipse = new Ellipse();
            gameField.Add(ellipse, 10);

            Circle circle = new Circle();
            gameField.Add(circle, 10);

            Square square = new Square();
            gameField.Add(square, 10);

            Triangle triangle = new Triangle();
            gameField.Add(triangle, 10);            
        }
        
    }
}
