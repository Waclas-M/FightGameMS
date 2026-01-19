using FightGameMS.Classes;
using FightGameMS.Classes.Helpers;
using FightGameMS.Forms;
using FightGameMS.Infrastructure.Repositories;
using System.Diagnostics;

namespace FightGameMS
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.


            JsonHeroRepository jsonHeroRepository = new JsonHeroRepository(ActionImageHelper.DataRoot + "//Heros.json");
            List<HeroTemplate> Heros = jsonHeroRepository.GetAll().ToList();


            ApplicationConfiguration.Initialize();


            using var Startingform = new StartWindow(Heros);
            Application.Run(Startingform);




            //string selectedHero1 = Startingform._selectedHeroPlayer1;
            //string selectedHero2 = Startingform._selectedHeroPlayer2;
       

            // Chwilowe zmienne zamiast ekranu wyboru
            var Player1Selected = Startingform._selectedHeroPlayer1; 
            var Player2Selected = Startingform._selectedHeroPlayer2;

            

            Player player1 = new Player("Player1");
            Player player2 = new Player("Player2");

            player1.SelectedHeroTemplate = Heros.Find(x => x.ClassName == Player1Selected);
            player2.SelectedHeroTemplate = Heros.Find(x => x.ClassName == Player2Selected);
            

            GameSession gameSession = new GameSession(player1,player2);
            gameSession.SetUp();
            gameSession.Initialize(gameSession);




        }
    }
}