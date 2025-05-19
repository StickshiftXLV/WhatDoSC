using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatDoSC
{
    internal class GameLogic
    {
        private List<Card> suspects;
        private List<Card> weapons;
        private List<Card> rooms;
        private (Card Suspect, Card Weapon, Card Room) mystery;

        public GameLogic()
        {
            suspects = new List<Card>
            {
            new Card("Miss Scarlet", "Resources/suspect01.png"),
            new Card("Professor Mundane", "Resources/suspect02.png"),
            new Card("mistour whatitdo", "Resources/suspect03.png"),
            new Card("Asmongler the Harbor Master", "Resources/suspect04.png"),
            new Card("Jerma the Snipper", "Resources/suspect05.png"),
            new Card("mao zhaomadong", "Resources/suspect06.png")
            };



            weapons = new List<Card>
            {
            new Card("The Cauldron", "Resources/weapon01.png"),
            new Card("The Harpoon Revolver", "Resources/weapon02.png"),
            new Card ("The Wooden Throne", "Resources/weapon03.png"),
            new Card("The Candelabra", "Resources/weapon04.png")
            };


            rooms = new List<Card>
            {
            new Card("Kitchen", "Resources/room01.png"),
            new Card("Pantry", "Resources/room02.png"),
            new Card("Living Room", "Resources/room03.png"),
            new Card ("Powder Room", "Resources/room04.png"),
            new Card("Dining Room", "Resources/room05.png"),
            new Card ("Balcony", "Resources/room06.png"),
            new Card("Hallway", "Resources/room07.png"),
            new Card("Servant Quarters", "Resources/room08.png"),
            new Card ("Master Bedroom", "Resources/room09.png"),
            new Card ("Cellar", "Resources/room010.png")
            };

            SetupMystery();
        }
        
        private void SetupMystery()
        {

        

            Random rand = new Random();
            mystery = (
                suspects[rand.Next(suspects.Count)],
                weapons[rand.Next(weapons.Count)],
                rooms[rand.Next(rooms.Count)]
  
        );
         }
        

        public (Card Suspect, Card Weapon, Card Room) GetMystery()
        {
            return mystery;
        }
        public string CheckGuess(Card suspect, Card weapon, Card room)
        {
            if (suspect == mystery.Suspect && weapon == mystery.Weapon && room == mystery.Room)
                return "Correct!";
            return "Try again.";
        }

        public List<Card> GetSuspects() => suspects;
        public List<Card> GetWeapons() => weapons;
        public List<Card> GetRooms() => rooms;
    }
}
