using FightGameMS.Classes;
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


    public partial class StartWindow : Form
    {
        public string? _selectedHeroPlayer1;
        public string? _selectedHeroPlayer2;
        public List<HeroTemplate> heroTemplates;
        public StartWindow(List<HeroTemplate> Heros)
        {
            heroTemplates = Heros;
            InitializeComponent();

            heroTemplates.ForEach(hero =>
            {
                Player1ComboBox.Items.Add(hero.ClassName);
                Player2ComboBox.Items.Add(hero.ClassName);
            });

            Player1ComboBox.SelectedIndex = 0;
            Player2ComboBox.SelectedIndex = 0;
        }

        private void StartWindow_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Player2ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedHeroPlayer2 = Player2ComboBox.SelectedItem.ToString();
            
        }

        private void Player1ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedHeroPlayer1 = Player1ComboBox.SelectedItem.ToString();
            
        }
    }
}
