using FightGameMS.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FightGameMS.Infrastructure.Repositories
{
    public class JsonHeroRepository
    {
        private readonly List<HeroTemplate> _heroes;
        public JsonHeroRepository(string url)
        {
            if (!File.Exists(url))
            {
                throw new FileNotFoundException("The specified hero data file was not found.", url);
            }

            string jsonData = File.ReadAllText(url);

            var root = JsonSerializer.Deserialize<List<HeroTemplate>>(jsonData)
                       ?? throw new InvalidOperationException("Invalid heroes.json structure.");

            _heroes = root;
        }

        public JsonHeroRepository(List<HeroTemplate> heroes)
        {
            _heroes = heroes;
        }


        public IReadOnlyList<HeroTemplate> GetAll()
        {
            return _heroes;
        }

        public HeroTemplate? GetById(string name)
        {
            return _heroes.FirstOrDefault(h => h.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public void saveAll(string url)
        {

            string jsonData = JsonSerializer.Serialize(_heroes);
            File.WriteAllText(url, jsonData);
        }
    }
}
