using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatDoSC
{
    public class Card
    {
        public string Name { get; set; }
        public string ImagePath { get; set; }

        public Card(string name, string imagePath)
        {
            Name = name;
            ImagePath = imagePath;
        }

       
        /*
// Method to check the player's guess
public string CheckGuess(string suspect, string weapon, string room)
        {
            // If all guesses are correct, return a success message
            if (suspect == correctSuspect && weapon == correctWeapon && room == correctRoom)
            {
                return "Correct! You solved the mystery!";
            }

            // Otherwise, give feedback and encourage another attempt
            return $"Wrong! Try again. (Hint: Suspect: {correctSuspect})";
        }                                                   ^
                                                       subjects' feedback = clue too easy 
                                                                        +   
                                                                using the term 'correct' is 'unethical' and 'raises questions' when the weapon is a cauldron in the kitchen 
                                                                                subject was suspended from giving feedback 
                                                                                                        ^
                                                                                                Cauldron was readded as murderweapon and added refernence in help page
    }
}
*/
    }
}
