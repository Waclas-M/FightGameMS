using FightGameMS.Classes;
using FightGameMS.Classes.Enums;
using FightGameMS.Classes.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;

namespace FightGameMS.Forms
{
    public partial class GameWindow : Form
    {
        private readonly System.Windows.Forms.Timer _timer = new();
        private DateTime _lastTick;



        private bool _p1Left, _p1Right;
        private bool _p2Left, _p2Right;

        private GameSession Game {  get; set; }

        public GameWindow(GameSession game)
        {
            Game = game; 
            InitializeComponent();
            SetUp();
        }

        private void SetUp()
        {
            this.BackgroundImage = Image.FromFile("C:\\Users\\wecla\\source\\repos\\FightGameMS\\FightGameMS\\infrastructure\\Data\\parallax-forest-back-trees.png");
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.DoubleBuffered = true;

            _timer.Interval = 16; // ~60 FPS
            _timer.Tick += GameTick;
            _lastTick = DateTime.Now;
            _timer.Start();

        }
        private void GameTick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            double dtMs = (now - _lastTick).TotalMilliseconds;
            _lastTick = now;

           

            Game.Update(dtMs);
            EndGame();
            // Odświerzanie rysnuka // Wywołanie GameWindow_Paint
            Invalidate();
        }


        private void GameWindow_KeyDown(object sender, KeyEventArgs e)
        {

            // Player 1 Attack
            if (e.KeyCode == Keys.Space) { Game.Action(ActionType.Attack, 1, null); }
            //Player 1 controls
            if (e.KeyCode == Keys.Left) { Game.Action(ActionType.Move, 2, -1); }
            if (e.KeyCode == Keys.Right) { Game.Action(ActionType.Move, 2, 1); }

            // Player 2 controls
            if (e.KeyCode == Keys.A) { Game.Action(ActionType.Move, 1, -1); }
            if (e.KeyCode == Keys.D) { Game.Action(ActionType.Move, 1, 1); }
        }

        private void GameWindow_KeyUp(object sender, KeyEventArgs e)
        {
            //Player 1 controls
            if (e.KeyCode == Keys.Left) { Game.Action(ActionType.Move, 2, 0); }
            if (e.KeyCode == Keys.Right) { Game.Action(ActionType.Move, 2, 0); }

            // Player 2 controls
            if (e.KeyCode == Keys.A) { Game.Action(ActionType.Move, 1, 0); }
            if (e.KeyCode == Keys.D) { Game.Action(ActionType.Move, 1, 0); }
        }

        private void GameWindow_Click(object sender, EventArgs e)
        {
            // Player 2 Attack
            Game.Action(ActionType.Attack, 2, null);
        }

        private void GameWindow_Paint(object sender, PaintEventArgs e)
        {
            // Rysowanie na ekranie.
            // Kiedy HeroCurrentImage się zmienia zmienia się animacja.
           
            e.Graphics.DrawImage(Game.Hero_P1.HeroCurrentImage, Game.Hero_P1.X, Game.Hero_P1.Y, 420,420);
            e.Graphics.DrawImage(Game.Hero_P2.HeroCurrentImage, Game.Hero_P2.X, Game.Hero_P2.Y, 420,420);

            DrawHealthBars(e);
            

            // Debug Setup

            if (Game.Debug)
            {
                
                e.Graphics.DrawRectangle(new Pen(Color.Green), HtiBoxHelper.GetBodyBox(Game.Hero_P1));
                e.Graphics.DrawRectangle(new Pen(Color.Green), HtiBoxHelper.GetBodyBox(Game.Hero_P2));

                e.Graphics.DrawRectangle(new Pen(Color.Red), HtiBoxHelper.GetAttackBox(Game.Hero_P1));
                e.Graphics.DrawRectangle(new Pen(Color.Red), HtiBoxHelper.GetAttackBox(Game.Hero_P2));

            }

            
        }

        private void DrawHealthBars(PaintEventArgs e)
        {

            SolidBrush gray = new SolidBrush(Color.Gray);
            SolidBrush black = new SolidBrush(Color.Black);
            SolidBrush green = new SolidBrush(Color.Green);
            FontFamily fontFamily = FontFamily.GenericSansSerif;
            Font font = new Font("Arail", 16, FontStyle.Bold);
          
            
               // Pozycja Y na ekranie
            int width = 200; // Maksymalna szerokość paska (gdy 100% życia)
            int height = 20; // Wysokość paska
            int margin = 15;
            int y = 25;
            int x = margin + 45;   // Pozycja X na ekranie dla P1
            int h2_x = this.ClientSize.Width - margin - width; // Pozycja dla P2


            float h1_Procentage = (float)Game.Hero_P1.Hp.CurrentHealth / Game.Hero_P1.Hp.MaxHeath;
            float h2_Procentage = (float)Game.Hero_P2.Hp.CurrentHealth / Game.Hero_P2.Hp.MaxHeath;

            int h1_CurrentWidth = (int)(width * h1_Procentage);
            int h2_CurrentWidth = (int)(width * h2_Procentage);

            //Debug.WriteLine($"\nMoje zdrowie {Game.Hero_P2.Hp.CurrentHealth} | Moje maksymalne {Game.Hero_P2.Hp.MaxHeath}\n Procent {h2_Procentage} | width {h2_CurrentWidth} \n");

            e.Graphics.DrawString("P1: ", font, new SolidBrush(Color.Black),margin , y  - 3);
            e.Graphics.FillRectangle(gray, x ,y, width, height);
            e.Graphics.FillRectangle(green, x ,y, h1_CurrentWidth, height);

            e.Graphics.DrawString("P2: ",font,new SolidBrush(Color.Black), h2_x - 30 - margin ,y - 3);
            e.Graphics.FillRectangle(gray, h2_x, y, width, height);
            e.Graphics.FillRectangle(green, h2_x, y, h2_CurrentWidth, height);


        }

        private void EndGame()
        {
            if(Game.GameStatus == Status.Ended)
            {
                this.Close();
            }
        }

        private void GameWindow_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void GameWindow_Load(object sender, EventArgs e)
        {

        }
    }
}
