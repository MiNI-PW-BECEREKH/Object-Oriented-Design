using System;
using System.Collections.Generic;

namespace GameConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            List<PlayerCharacter> players = new List<PlayerCharacter>
            {
                new PlayerCharacter(new IronArmorDefence())
                {
                    Name = "Tom"
                },
                new PlayerCharacter(new SteelArmorDefence())
                {
                    Name = "Bob"
                },
                new PlayerCharacter(ArmorDefence.Null)
                {
                    Name = "Frank"
                },
            };

            foreach (var item in players)
            {
                Random rand = new Random();
                item.Hit(rand.Next(25,50));
            }
        }
    }
}
