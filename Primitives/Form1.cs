using System;
using System.Drawing;
using System.Windows.Forms;

namespace Primitives
{
    public partial class Form1 : Form
    {
        Game game = new Game();
        // метод для обновления отрисовки поля при изменении размеров формы
        private void Form1_Resize(object sender, EventArgs e)
        {
            Refresh();
        }
        public Form1()
        {
            InitializeComponent();
            // корректировка размеров формы после создания игрового поля
            this.ClientSize = new Size(game.gameField.width + game.gameField.leftX + 20, game.gameField.height + game.gameField.leftY + 20);
            // минимальные размеры формы
            this.MinimumSize = new Size(game.gameField.width + game.gameField.leftX + 20, game.gameField.height + game.gameField.leftY + 45);
            this.Paint += Form1_Paint;
        }        
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = CreateGraphics();
            // перерисовка игрового поля
            g.TranslateTransform(ClientSize.Width + game.lX, ClientSize.Height + game.lY);
            g.RotateTransform(180);
            g.Clear(Color.White);
            game.gameField.DrawObjects(this, g);
            g.ResetTransform();
        }      
    }
}
