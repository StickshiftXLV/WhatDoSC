using System;
using System.ComponentModel;
using System.Diagnostics;

namespace WhatDoSC
{
    public partial class Form1 : Form
    {
        GameLogic gameEngine = new GameLogic(); //creates a new instance of the game engine cause yeah i'd like to restart
        private List<string> cardDeckActive;            // Stores the paths to card images
        private List<PictureBox> drawnCardsActive = new List<PictureBox>(); // Stores PictureBox for drawn cards
        private Random random = new Random();
        private List<string> suspectCardsActive; // Stores suspect cards
        private List<string> weaponCardsActive; // Stores weapon cards
        private List<string> roomCardsActive;            // Stores room cards
        private List<string> selectedCaseActive; // Stores the case (1 suspect, 1 weapon, 1 room)
        private int guessCount = 0; // for calculating the score in the scoreboard form


        // Game state counters

        int turnCounter = 0;
        int swanSong = 3;               // for when all cards are drawn and the user only has a few correct choices
        int warning = 0; // controls the message box warning
        public Form1()
        {


            InitializeComponent();

            cardDeckActive = new List<string>();     //card deck, list of file paths to card images

            foreach (var card in gameEngine.GetSuspects())             // Initialize card deck and populate it with card paths

                cardDeckActive.Add(card.ImagePath);

            foreach (var card in gameEngine.GetWeapons())            // Initialize card deck and populate it with card paths

                cardDeckActive.Add(card.ImagePath);

            foreach (var card in gameEngine.GetRooms())            // Initialize card deck and populate it with card paths

                cardDeckActive.Add(card.ImagePath);

            comboBoxSus.DataSource = gameEngine.GetSuspects();
            comboBoxSus.DisplayMember = "Name";

            comboBoxWeapon.DataSource = gameEngine.GetWeapons();
            comboBoxWeapon.DisplayMember = "Name";

            comboBoxRoom.DataSource = gameEngine.GetRooms();
            comboBoxRoom.DisplayMember = "Name";


            // Initialize card category lists & generate the deck
            InitializeCardLists();
            GenerateCardDeck();

        }

        private void InitializeCardLists()
        {
            // Initialize and define the lists for suspects, weapons, and rooms
            suspectCardsActive = new List<string>
            {
                "Suspect1.png", "suspect2.png", "suspect3.png", "suspect4.png", "suspect5.png",
                "suspect6.png",// "suspect7.png", "suspect8.png", "suspect9.png", "suspect10.png"
            };

            weaponCardsActive = new List<string>
            {
                "Weapon1.png", "weapon2.png", "weapon3.png", "weapon4.png", //"weapon5.png",
                //"weapon6.png", "weapon7.png", "weapon8.png", "weapon9.png", "weapon10.png"
            };

            roomCardsActive = new List<string>
            {
                "Room1.png", "room2.png", "room3.png", "room4.png", "room5.png",
                "room6.png", "room7.png", "room8.png", "room9.png", "room10.png"
            };
        }

        private void GenerateCardDeck()
        {
            // Ask GameLogic for the mystery and retrieves
            var mystery = gameEngine.GetMystery();
            selectedCaseActive = new List<string>
            {
                mystery.Suspect.ImagePath,
                mystery.Weapon.ImagePath,
                mystery.Room.ImagePath
            };

            // Build pools from all cards EXCEPT the mystery
            var suspects = gameEngine.GetSuspects()
                .Where(card => card != mystery.Suspect)
                .Select(card => card.ImagePath).ToList();

            var weapons = gameEngine.GetWeapons()
                .Where(card => card != mystery.Weapon)
                .Select(card => card.ImagePath).ToList();

            var rooms = gameEngine.GetRooms()
                .Where(card => card != mystery.Room)
                .Select(card => card.ImagePath).ToList();

            // Build the playable deck
            cardDeckActive = new List<string>();
            AddRandomCardsFromList(suspects, 5);
            AddRandomCardsFromList(weapons, 3);
            AddRandomCardsFromList(rooms, 9);
        }





        private void AddRandomCardsFromList(List<string> sourceList, int count)
        {
            // Randomly select 'count' cards from sourceList and add to the deck
            for (int i = 0; i < count; i++)
            {
                int randomIndex = random.Next(sourceList.Count);
                cardDeckActive.Add(sourceList[randomIndex]);
                sourceList.RemoveAt(randomIndex);
            }
        }


        /*
        private void UpdateCardImage(ComboBox comboBox, PictureBox pictureBox)
        {
            if (comboBox.SelectedItem is Card card)
            {
                string imagePath = Path.Combine(Application.StartupPath, card.ImagePath);
                if (File.Exists(imagePath))
                {
                    pictureBox.Image = Image.FromFile(imagePath);
                }
                else
                {
                    pictureBox.Image = null;
                }
            }
        }
        */

        private void Dealer()
        {
            
           

            //lblGuessCount.Text = $"Guesses: {turnCounter}";
            lblCardsDrawn.Text = $"Cards Drawn: {drawnCardsActive.Count + 1}";            // Increment the turn counter

            // Randomly pick a card
            int randomIndex = random.Next(cardDeckActive.Count);
            string selectedCard = cardDeckActive[randomIndex];

            pictureBoxDisplay.Image = Image.FromFile(selectedCard);             // Display the card in the main PictureBox


            cardDeckActive.RemoveAt(randomIndex);       // Remove the card from the deck


            // Create a new PictureBox for the drawn card and display it permanently
            PictureBox newCardBox = new PictureBox
            {
                Image = Image.FromFile(selectedCard),
                Size = new Size(125, 150),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BorderStyle = BorderStyle.FixedSingle
            };

            // Position the new PictureBox below existing ones
            int xOffset = 1150 + (drawnCardsActive.Count % 5) * 120; // Horizontal spacing lower = left
            int yOffset = 450 + (drawnCardsActive.Count / 5) * 148; // Vertical spacing  lower = up
            newCardBox.Location = new Point(xOffset, yOffset);

            // Add the new PictureBox to the form and the list
            this.Controls.Add(newCardBox);
            newCardBox.BringToFront(); // Ensure the PictureBox is in front of other controls
            drawnCardsActive.Add(newCardBox);
        }


        // Handlers to update the picture when a suspect/weapon/room is selected
        private void comboBoxSus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSus.SelectedItem is Card card)
                pictureBoxSus.Image = Image.FromFile(card.ImagePath);
        }

        private void comboBoxRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxRoom.SelectedItem is Card card)
                pictureBoxRoom.Image = Image.FromFile(card.ImagePath);
        }

        private void comboBoxWeapon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxWeapon.SelectedItem is Card card)
                pictureBoxWeapon.Image = Image.FromFile(card.ImagePath);
        }
        private void ShowScoreboardAndClose()
        {
            // Show the scoreboard and close the main form
            int drawn = drawnCardsActive.Count;
            scoreBoardForm scoreForm = new scoreBoardForm(tally, drawn, guessCount);
            scoreForm.Show();
            this.Close(); // or Close();
        }
        private void btnMakeGuess_Click(object sender, EventArgs e)
        {

            lblTurn.Text = $"Turn: {tally}";

            //RevealMystery();
            if (comboBoxSus.SelectedItem is Card suspect &&
            comboBoxWeapon.SelectedItem is Card weapon &&
            comboBoxRoom.SelectedItem is Card room)
            {
                
                guessCount++;
                lblGuessCount.Text = $"Guesses: {guessCount}"; //lblguesscount

                string result = gameEngine.CheckGuess(suspect, weapon, room);
                lblResults.Text = $"You guessed:\n" +               //lblResults
                                  $"Suspect: {suspect.Name}\n" +
                                  $"Weapon: {weapon.Name}\n" +
                                  $"Room: {room.Name}\n\n" +
                                  $"{result}";


                // Handle different game outcomes
                if (result == "Correct!")
                {
                    MessageBox.Show("You solved the mystery!");
                    DisableAllButtons();
                    ShowScoreboardAndClose();
                }
                else if (guessCount >= 21 && warning >= 1)
                {
                    MessageBox.Show("Too many guesses! The killer escaped.");
                    DisableAllButtons();
                    ShowScoreboardAndClose();

                }
                
                else if (cardDeckActive.Count == 0 && swanSong == 1)
                {
                    panel2.Enabled = false;
                    panel2.Visible = false;
                    panel3.Enabled = false;
                    panel3.Visible = false;
                    DisableAllButtons();
                    ShowScoreboardAndClose();

                }
                else if (cardDeckActive.Count == 0 && warning == 1)
                {
                   // MessageBox.Show("All cards have been drawn!");
                    DisableAllButtons();
                    swanSong--;
                    lblSwanSong.Visible = true;
                    lblSwanSong.Text = ($"The Killer is having a blast, watching your struggle");
                    lblSwanSong2.Visible = true;
                    lblSwanSong2.Text = swanSong.ToString($" but they see the pattern now, you have :{swanSong} , more attempts before they flee");
                    panel3.Enabled=false;
                    panel3.Visible=false;
                    panel2.Visible=true;
                    panel2.Enabled=true;
                    return;

                }
                else if (cardDeckActive.Count == 0 && warning == 0)
                {
                    MessageBox.Show("All cards have been drawn! Rely on your instincts.");
                    warning++;
                    lblSwanSong.Visible = true;
                    lblSwanSong.Text = ($"The Killer is having a blast, watching your struggle");
                    lblSwanSong2.Visible = true;
                    lblSwanSong2.Text = swanSong.ToString($" but they see the pattern now, you have :{swanSong} , more attempts before they flee");
                    DisableAllButtons();
                    return;

                }
                else if (guessCount >= 21 && result == "Correct!")
                {
                    MessageBox.Show("You solved the mystery! but the killer is nowhere to be found");
                    ShowScoreboardAndClose();
                }
                else if (tally == 10)
                {

                    lblResults.Text = tally.ToString();
                    panel2.Enabled = false;
                    panel2.Visible = false;
                    MessageBox.Show("all rooms have been investigated, moving to interrogations ");

                    panel3.Enabled = true;
                    panel3.Visible = true;

                    /*


                     MessageBox.Show("All cards have been drawn!", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnServant.Enabled = false;
                    btnThrone.Enabled = false;
                    btnDining.Enabled = false;
                    btnMaster.Enabled = false;
                    btnPantry.Enabled = false;
                    btnKitchen.Enabled = false;
                    btnHall.Enabled = false;
                    btnLivingRoom.Enabled = false;
                    btnCellar.Enabled = false;
                    btnBalcony.Enabled = false;
                    return;
                    */
                }
                else
                {
                    Dealer(); // Show new card / continues game
                }
            }
        }
        int tally = 0; //triggers the interegation stage

        private void DisableAllButtons()
        {
            btnServant.Enabled = false;
            btnThrone.Enabled = false;
            btnDining.Enabled = false;
            btnMaster.Enabled = false;
            btnPantry.Enabled = false;
            btnKitchen.Enabled = false;
            btnHall.Enabled = false;
            btnLivingRoom.Enabled = false;
            btnCellar.Enabled = false;
            btnBalcony.Enabled = false;
            btnAsmon.Enabled = false;
            BtnScar.Enabled = false;
            btnMao.Enabled = false;
            btnMist.Enabled = false;
            btnJeff.Enabled = false;
            btnPlum.Enabled = false;                 //used to be profplum now mistourwhatdo
            btnAsmon.Visible = false;
            BtnScar.Visible = false;
            btnMao.Visible = false;
            btnMist.Visible = false;
            btnJeff.Visible = false;
            btnPlum.Visible = false;

            // all added later on form ease
            btnServant.Visible = false;  
            btnThrone.Visible = false; 
            btnDining.Visible = false;
            btnMaster.Visible = false;
            btnPantry.Visible = false;
            btnKitchen.Visible = false;
            btnHall.Visible = false;
            btnLivingRoom.Visible = false;
            btnCellar.Visible = false;
            btnBalcony.Visible = false;

        }

       
        //btns for searching rooms 
        private void btnServant_Click(object sender, EventArgs e)
        {
            
            Dealer();
            btnServant.Enabled = false;
            btnServant.Visible = false;
            tally++;
            lblTurn.Text = $"Turn: {tally}";

            if (cardDeckActive.Count == 0)
            {
                DisableAllButtons();
            }
        }

        private void btnThrone_Click(object sender, EventArgs e)
        {
            Dealer();
            btnThrone.Enabled = false;
            btnThrone.Visible = false;
            tally++;
            lblTurn.Text = $"Turn: {tally}";

            if (cardDeckActive.Count == 0)
            {
                DisableAllButtons();
            }
        }

        private void btnDining_Click(object sender, EventArgs e)
        {
            Dealer();
            btnDining.Enabled = false;
            btnDining.Visible = false;
            tally++;
            lblTurn.Text = $"Turn: {tally}";
            if (cardDeckActive.Count == 0)
            {
                DisableAllButtons();
            }
        }

        private void btnMaster_Click(object sender, EventArgs e)
        {
            Dealer();
            btnMaster.Enabled = false;
            btnMaster.Visible = false;
            tally++;
            lblTurn.Text = $"Turn: {tally}";
            if (cardDeckActive.Count == 0)
            {
                DisableAllButtons();
            }

        }

        private void btnPantry_Click(object sender, EventArgs e)
        {
            Dealer();
            btnPantry.Enabled = false;
            btnPantry.Visible = false;
            tally++;
            lblTurn.Text = $"Turn: {tally}";
            if (cardDeckActive.Count == 0)
            {
                DisableAllButtons();
            }
        }

        private void btnKitchen_Click(object sender, EventArgs e)
        {
            Dealer();
            btnKitchen.Enabled = false;
            btnKitchen.Visible = false;
            tally++;
            lblTurn.Text = $"Turn: {tally}";
            if (cardDeckActive.Count == 0)
            {
                DisableAllButtons();
            }
        }

        private void btnHall_Click(object sender, EventArgs e)
        {
            Dealer();
            btnHall.Enabled = false;
            btnHall.Visible = false;
            tally++;
            lblTurn.Text = $"Turn: {tally}";
            if (cardDeckActive.Count == 0)
            {
                DisableAllButtons();
            }
        }

        private void btnLivingRoom_Click(object sender, EventArgs e)
        {
            Dealer();
            btnLivingRoom.Enabled = false;
            btnLivingRoom.Visible = false;
            tally++;
            lblTurn.Text = $"Turn: {tally}";
            if (cardDeckActive.Count == 0)
            {
                DisableAllButtons();
            }
            
           /// if (roomCounter == 10) {
            ///  btnThrone.Enabled = false;
            ///    btnThrone.Visible = false;
            ///}
        }


        private void btnCellar_Click(object sender, EventArgs e)
        {
            Dealer();
            btnCellar.Enabled = false;
            btnCellar.Visible = false;
            tally++;
            lblTurn.Text = $"Turn: {tally}";
            if (cardDeckActive.Count == 0)
            {
                DisableAllButtons();
            }
        }

        private void btnBalcony_Click(object sender, EventArgs e)
        {
            Dealer();
            btnBalcony.Enabled = false;
            btnBalcony.Visible = false;
            tally++;
            lblTurn.Text = $"Turn: {tally}";
            if (cardDeckActive.Count == 0)
            {
                DisableAllButtons();
            }

        }


        /*
        //dev cheat
        private void RevealMystery()
        {
               
            if (selectedCaseActive.Count < 3) return;

            pictureBoxMysterySuspect.Image = Image.FromFile(selectedCaseActive[0]);
            pictureBoxMysteryWeapon.Image = Image.FromFile(selectedCaseActive[1]);
            pictureBoxMysteryRoom.Image = Image.FromFile(selectedCaseActive[2]);
        }
        */
        

        private void btnPythonNotepad_Click(object sender, EventArgs e)
        {
            //controlls the python integration
            string pythonPath = @"C:\Users\zebco\source\repos\CluedoGame\CanvasApp.py";            // Path to the Python scriptdddddddddd


            //guy on stack overflow helped me with these
            ProcessStartInfo start = new ProcessStartInfo // Start the Python script
            {
                FileName = "python", // calls file name
                Arguments = $"\"{pythonPath}\"", //parses arguments
                UseShellExecute = false, 
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true // closes the original form otherwise
            };
            try
            {
                using (Process process = Process.Start(start))
                {
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();
                    process.WaitForExit();

                    if (!string.IsNullOrEmpty(error))
                    {
                        MessageBox.Show($"Error: {error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            //error catch
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to open Python canvas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
            // CanvasForm canvasForm = new CanvasForm();
            // canvasForm.Show();
        }



       



        //btns for people, similar to rooms 
        private void BtnScar_Click(object sender, EventArgs e)
        {
            if (cardDeckActive.Count == 0)
            {
                DisableAllButtons();
                MessageBox.Show("All cards Have been Drawn. Good Luck");
                
            }
            else
            {
                Dealer();
                BtnScar.Enabled = false;
                BtnScar.Visible = false;
                tally++;
                lblTurn.Text = $"Turn: {tally}";
            }
        }

        private void btnMist_Click(object sender, EventArgs e)
        {
            
            if (cardDeckActive.Count == 0)
            {
                DisableAllButtons();
                MessageBox.Show("All cards Have been Drawn. Good Luck");

            }
            else
            {
                Dealer();
                btnMist.Enabled = false;
                btnMist.Visible = false;
                tally++;
                lblTurn.Text = $"Turn: {tally}";
            }
         
        }

        private void btnPlum_Click(object sender, EventArgs e)
        {
            
            if (cardDeckActive.Count == 0)
            {
                DisableAllButtons();
                MessageBox.Show("All cards Have been Drawn. Good Luck");

            }
            else
            {
                Dealer();
                btnPlum.Enabled = false;
                btnPlum.Visible = false;
                tally++;
                lblTurn.Text = $"Turn: {tally}";
            }
        }

        private void btnMao_Click(object sender, EventArgs e)
        {
            
            if (cardDeckActive.Count == 0)
            {
                DisableAllButtons();
                MessageBox.Show("All cards Have been Drawn. Good Luck");

            }
            else
            {
                Dealer();
                btnMao.Enabled = false;
                btnMao.Visible = false;
                tally++;
                lblTurn.Text = $"Turn: {tally}";
            }
        }

        private void btnAsmon_Click(object sender, EventArgs e)
        {
            
            if (cardDeckActive.Count == 0)
            {
                DisableAllButtons();
                MessageBox.Show("All cards Have been Drawn. Good Luck");

            }
            else
            {
                Dealer();
                btnAsmon.Enabled = false;
                btnAsmon.Visible = false;
                tally++;
                lblTurn.Text = $"Turn: {tally}";
            }
        }

        private void btnJeff_Click(object sender, EventArgs e)
        {
            
            if (cardDeckActive.Count == 0)
            {
                DisableAllButtons();
                MessageBox.Show("All cards Have been Drawn. Good Luck");

            }
            else
            {
                Dealer();
                btnJeff.Enabled = false;
                btnJeff.Visible = false;
                tally++;
                lblTurn.Text = $"Turn: {tally}";
            }
        }
    }




}

