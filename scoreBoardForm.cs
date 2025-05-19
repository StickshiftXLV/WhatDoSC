using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WhatDoSC
{
    public partial class scoreBoardForm : Form
    {
        public scoreBoardForm(int turns, int cardsDrawn, int guesses)
        {
            InitializeComponent();
            
            lblTurns.Text = $"Turns Taken: {turns}";
            lblCards.Text = $"Cards Drawn: {cardsDrawn}";
            lblGuesses.Text = $"Guesses Made: {guesses}";

            int score = CalculateScore(turns, cardsDrawn, guesses);
            lblScore.Text = $"Final Score: {score}";

            SaveScoreToFile(score, turns, cardsDrawn, guesses); // save to file
            LoadScoreHistory(); // load score after save
        }

        private int CalculateScore(int turns, int cards, int guesses)
        {
            // Example formula: fewer turns, fewer guesses = better
            int baseScore = 1000;
            return baseScore - (turns * 20 + guesses * 30 + cards * 5);
        }

        private void SaveScoreToFile(int score, int turns, int cards, int guesses)
        {
            string line = $"Score={score}, Turns={turns}, Cards={cards}, Guesses={guesses}: {DateTime.Now}:";
            File.AppendAllText("scoreboard.txt", line + Environment.NewLine);
        }

        private void LoadScoreHistory()
        {
            if (File.Exists("scoreboard.txt"))
            {
                string[] lines = File.ReadAllLines("scoreboard.txt");
                listBoxHistory.Items.AddRange(lines.Reverse().Take(60).ToArray());
            }
        }


        private void btnRestart_Click(object sender, EventArgs e)
        {
            Form1 mainGame = new Form1();
            mainGame.Show();
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }
    }
}
