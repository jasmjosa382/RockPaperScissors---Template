using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Threading;

/// <summary>
/// A rock, paper, scissors game that utilizes basic methods
/// for repetitive tasks.
/// </summary>

namespace RockPaperScissors
{
    public partial class Form1 : Form
    {
        string playerChoice, cpuChoice;

        int wins = 0;
        int losses = 0;
        int ties = 0;
        int choicePause = 1000;
        int outcomePause = 3000;

        Random randGen = new Random();

        SoundPlayer jabPlayer = new SoundPlayer(Properties.Resources.jabSound);
        SoundPlayer gongPlayer = new SoundPlayer(Properties.Resources.gong);

        Image rockImage = Properties.Resources.rock168x280;
        Image paperImage = Properties.Resources.paper168x280;
        Image scissorImage = Properties.Resources.scissors168x280;
        Image winImage = Properties.Resources.winTrans;
        Image loseImage = Properties.Resources.loseTrans;
        Image tieImage = Properties.Resources.tieTrans;

        public Form1()
        {
            InitializeComponent();
        }

        private void rockButton_Click(object sender, EventArgs e)
        {
            /// TODO Set the playerchoice value, show the appropriate image,
            /// play a sound, wait for a second; repeat for the computer turn
            /// 

            playerChoice = "rock";
            playerImage.BackgroundImage = rockImage;
            jabPlayer.Play();

            int computerRandom = randGen.Next(1, 4);

            if (computerRandom == 1)
            {
                cpuChoice = "rock";
                cpuImage.BackgroundImage = rockImage;
                ties++;
                tiesLabel.Text = $"Ties: {ties}";
                resultImage.BackgroundImage = tieImage;
                gongPlayer.Play();
            }
            else if (computerRandom == 2)
            {
                cpuChoice = "paper";
                cpuImage.BackgroundImage= paperImage;
                losses++;
                lossesLabel.Text = $"Losses: {losses}";
                resultImage.BackgroundImage = loseImage;
                gongPlayer.Play();
            }
            else if (computerRandom == 3)
            {
                cpuChoice = "scissors";
                cpuImage.BackgroundImage = scissorImage;
                wins++;
                winsLabel.Text = $"Wins: {wins}";
                resultImage.BackgroundImage = winImage;
                gongPlayer.Play();
            }
            //wait for a second
            Refresh();
            Thread.Sleep(outcomePause);
            resultImage.BackgroundImage = null;
            playerImage.BackgroundImage = null;
            cpuImage.BackgroundImage = null;
        }

        private void paperButton_Click(object sender, EventArgs e)
        {

        }

        private void scissorsButton_Click(object sender, EventArgs e)
        {

        }
    }
}