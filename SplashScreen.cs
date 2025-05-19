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
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
            InitializeSplashScreen();
        }

        private void InitializeSplashScreen()
        {
            pictureBoxBackground.Image = Properties.Resources.whatDoTrailer; // fetches it as a project resource to ensure load

        }

        private void btnStart_Click(object sender, EventArgs e) //btn Start
        {

            Form1 mainGame = new Form1();
            mainGame.Show();
            this.Hide();
        }

        private void btnHelp_Click(object sender, EventArgs e) //tbn Help
        {
            helpForm help = new helpForm();
            help.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e) // btn exit
        {
            this.Close();
            
        }
    }
}
