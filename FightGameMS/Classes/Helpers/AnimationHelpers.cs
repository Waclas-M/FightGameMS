using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightGameMS.Classes.Helpers
{
    public class ActionImageHelper
    {
        //public static readonly string DataRoot =
        //@"C:\Users\wecla\source\repos\GreenFightForms\GreenFightForms\infrastructure\Data";

        public static readonly string DataRoot = Path.GetFullPath(
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\infrastructure\Data")
        );

        public static List<Image> LoadFrames(string folderPath)
        {
            if (!Directory.Exists(folderPath))
                throw new DirectoryNotFoundException($"Brak folderu: {folderPath}");

            return Directory.GetFiles(folderPath, "*.png")
                .OrderBy(f => f)
                .Select(Image.FromFile)
                .ToList();
        }

        public static string AnimPath(string hero, string animation, string direction)
            => Path.Combine(DataRoot, hero, animation, direction);
    }
}
