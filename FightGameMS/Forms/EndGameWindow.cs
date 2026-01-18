using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FightGameMS.Classes;

namespace FightGameMS.Forms
{
    public partial class EndGameWindow : Form
    {
        public EndGameWindow(GameSession game)
        {
            InitializeComponent();
            if (game.Winner == 1) Winner.Text = "Player1";
            if (game.Winner == 2) Winner.Text = "Player2";
            if (game.Winner == 0) Winner.Text = "Remis";

        }

        private void EndGameWindow_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void EndGameWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
