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
            ComputerChoice();
            DetermineWinner();

        }

        private void paperButton_Click(object sender, EventArgs e)
        {
            playerChoice = "paper";
            playerImage.BackgroundImage = paperImage;
            ComputerChoice();
            DetermineWinner();

        }

        private void scissorsButton_Click(object sender, EventArgs e)
        {
            playerChoice = "scissor";
            playerImage.BackgroundImage = scissorImage;

            ComputerChoice();
            DetermineWinner();

        }

        public void ComputerChoice()
        {
            int computerRandom = randGen.Next(1, 4); 
            jabPlayer.Play();

            if (computerRandom == 1)
            {
                cpuChoice = "rock";
                cpuImage.BackgroundImage = rockImage;
            }
            else if (computerRandom == 2)
            {
                cpuChoice = "paper";
                cpuImage.BackgroundImage = paperImage;
            }
            else if (computerRandom == 3)
            {
                cpuChoice = "scissors";
                cpuImage.BackgroundImage = scissorImage;
            }

        }


        public void DetermineWinner()
        {
            //check for winner
            if (playerChoice == cpuChoice) //tie
            {
                ties++;
                tiesLabel.Text = $"Ties: {ties}";
                resultImage.BackgroundImage = tieImage;

            }
            else if ((playerChoice == "scissors" && cpuChoice == "rock") || (playerChoice == "paper" && cpuChoice == "rock") || (playerChoice == "scissors" && cpuChoice == "paper")) //win
            {
                wins++;
                winsLabel.Text = $"Wins: {wins}";
                resultImage.BackgroundImage = winImage;
            }
            else  //loss
            {
                losses++;
                lossesLabel.Text = $"Losses: {losses}";
                resultImage.BackgroundImage = loseImage;

            }

            gongPlayer.Play();
            Refresh();
            Thread.Sleep(outcomePause);

            resultImage.BackgroundImage = null;
            playerImage.BackgroundImage = null;
            cpuImage.BackgroundImage = null;
        }

    }
}