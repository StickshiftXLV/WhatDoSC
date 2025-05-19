namespace WhatDoSC
{
    partial class scoreBoardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTurns = new Label();
            lblCards = new Label();
            lblGuesses = new Label();
            lblScore = new Label();
            lblGameOver = new Label();
            btnRestart = new Button();
            btnExit = new Button();
            listBoxHistory = new ListBox();
            SuspendLayout();
            // 
            // lblTurns
            // 
            lblTurns.AutoSize = true;
            lblTurns.BackColor = Color.Transparent;
            lblTurns.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblTurns.ForeColor = Color.White;
            lblTurns.Location = new Point(206, 304);
            lblTurns.Name = "lblTurns";
            lblTurns.Size = new Size(86, 17);
            lblTurns.TabIndex = 0;
            lblTurns.Text = "Turns Taken:";
            // 
            // lblCards
            // 
            lblCards.AutoSize = true;
            lblCards.BackColor = Color.Transparent;
            lblCards.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblCards.ForeColor = Color.White;
            lblCards.Location = new Point(206, 352);
            lblCards.Name = "lblCards";
            lblCards.Size = new Size(90, 17);
            lblCards.TabIndex = 1;
            lblCards.Text = "Cards Drawn:";
            // 
            // lblGuesses
            // 
            lblGuesses.AutoSize = true;
            lblGuesses.BackColor = Color.Transparent;
            lblGuesses.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblGuesses.ForeColor = Color.White;
            lblGuesses.Location = new Point(206, 266);
            lblGuesses.Name = "lblGuesses";
            lblGuesses.Size = new Size(99, 17);
            lblGuesses.TabIndex = 2;
            lblGuesses.Text = "Guesses Made:";
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.BackColor = Color.Transparent;
            lblScore.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblScore.ForeColor = Color.White;
            lblScore.Location = new Point(213, 394);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(79, 17);
            lblScore.TabIndex = 3;
            lblScore.Text = "Final Score:";
            // 
            // lblGameOver
            // 
            lblGameOver.AutoSize = true;
            lblGameOver.BackColor = Color.Transparent;
            lblGameOver.Font = new Font("Stencil", 72F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGameOver.ForeColor = Color.White;
            lblGameOver.Location = new Point(110, 126);
            lblGameOver.Name = "lblGameOver";
            lblGameOver.Size = new Size(573, 114);
            lblGameOver.TabIndex = 4;
            lblGameOver.Text = "Game Over";
            // 
            // btnRestart
            // 
            btnRestart.Location = new Point(153, 491);
            btnRestart.Name = "btnRestart";
            btnRestart.Size = new Size(75, 23);
            btnRestart.TabIndex = 5;
            btnRestart.Text = "Play Again";
            btnRestart.UseVisualStyleBackColor = true;
            btnRestart.Click += btnRestart_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(390, 491);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(75, 23);
            btnExit.TabIndex = 6;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // listBoxHistory
            // 
            listBoxHistory.BackColor = Color.White;
            listBoxHistory.FormattingEnabled = true;
            listBoxHistory.ItemHeight = 15;
            listBoxHistory.Location = new Point(718, 126);
            listBoxHistory.Name = "listBoxHistory";
            listBoxHistory.Size = new Size(452, 454);
            listBoxHistory.TabIndex = 7;
            // 
            // scoreBoardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.beholdtheFInalBackground;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1284, 719);
            Controls.Add(listBoxHistory);
            Controls.Add(btnExit);
            Controls.Add(btnRestart);
            Controls.Add(lblGameOver);
            Controls.Add(lblScore);
            Controls.Add(lblGuesses);
            Controls.Add(lblCards);
            Controls.Add(lblTurns);
            DoubleBuffered = true;
            Name = "scoreBoardForm";
            Text = "scoreBoardForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTurns;
        private Label lblCards;
        private Label lblGuesses;
        private Label lblScore;
        private Label lblGameOver;
        private Button btnRestart;
        private Button btnExit;
        private ListBox listBoxHistory;
    }
}