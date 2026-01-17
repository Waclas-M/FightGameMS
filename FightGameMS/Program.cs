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







            ApplicationConfiguration.Initialize();

           

            JsonHeroRepository jsonHeroRepository = new JsonHeroRepository(ActionImageHelper.DataRoot + "//Heros.json");
            List<HeroTemplate> Heros = jsonHeroRepository.GetAll().ToList();
            Heros.ForEach(hero =>
            {
                Debug.WriteLine("\n" + hero.ClassName + "\n");
            });

            // Chwilowe zmienne zamiast ekranu wyboru
            var Player1Selected = "Warrior";
            var Player2Selected = "Warrior";


            Player player1 = new Player("Marcin");
            Player player2 = new Player("Wojtek");

            player1.SelectedHeroTemplate = Heros.Find(x => x.ClassName == Player1Selected);
            player2.SelectedHeroTemplate = Heros.Find(x => x.ClassName == Player2Selected);
            Debug.WriteLine(player1.SelectedHeroTemplate);
            

            GameSession gameSession = new GameSession(player1,player2);
            gameSession.SetUp();
            gameSession.Initialize(gameSession);




        }
    }
}