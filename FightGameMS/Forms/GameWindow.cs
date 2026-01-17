using FightGameMS.Classes;
using FightGameMS.Classes.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            //int p1Dir;
            //int p2Dir;

            //if (_p1Right && !_p1Left)
            //    p1Dir = 1;
            //else if (_p1Left && !_p1Right)
            //    p1Dir = -1;
            //else
            //    p1Dir = 0;

            //if (_p2Right && !_p2Left)
            //    p2Dir = 1;
            //else if (_p2Left && !_p2Right)
            //    p2Dir = -1;
            //else
            //    p2Dir = 0;

            //Game.Action(ActionType.Move, 1, p1Dir);
            //Game.Action(ActionType.Move, 2, p2Dir);

            Game.Update(dtMs);
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
        }

        private void GameWindow_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void GameWindow_Load(object sender, EventArgs e)
        {

        }
    }
}
