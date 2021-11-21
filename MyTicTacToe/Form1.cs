using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyTicTacToe
{
    public partial class Form1 : Form
    {
        bool turn = true;
        int turn_count = 0;


        int N_side = 3;
        int N = 9;
            
        String player_1 = "Player 1 ";
        String player_2 = "Player 2 ";
        String Symbol = "";

        /*
        private Button[,] btn = new Button[,]
            {
                { A1, A2, A3 },
                { B1, B2,  B3},
                { C1, C2,  C3}
            };
        // */


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            initiator();
        }
        //*
        private void initiator()
        {
            Symbol = "X";
            playersTurnLabel.Text = player_1 + " - " + Symbol;
        }
        //*/
        private void ticTacToeBttns(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (turn)
            {
                btn.Text = "X";
                Symbol = "O";
            }
            else
            {
                btn.Text = "O";
                Symbol = "X";
            }

            turn = !turn;
            playersTurnDisplay();
            btn.Enabled = false;
            turn_count++;
           gameResult();
        }


        private void gameResult() 
        {
            bool isThereAWinner = false;
            /*
            Button[,] btn = new Button[,]
            {
                { A1, A2, A3 },
                { B1, B2,  B3},
                { C1, C2,  C3}
            };
            // */

            if ((isHorzontalMatch()) || isVerticalMatch() || isDiagonalMatch())
            {
                isThereAWinner = true;
            }
            


            if (isThereAWinner)
            {
                
                disableButtons();
                
                String winner = "";
                if(turn)
                {
                    winner = "O";
                    playersTurnLabel.Text = player_2 + "Wins!";
                }
                else
                {
                    winner = "X";
                    playersTurnLabel.Text = player_1 + "Wins!";
                }
                MessageBox.Show(winner + " Wins!", "Result");
            }
            else
            {
                if(turn_count == N)
                {
                    playersTurnLabel.Text = "Draw!"; 
                    MessageBox.Show("Draw!", "Result");
                }
            }
        }



        private bool isHorzontalMatch()
        {


            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled) && (!A2.Enabled) && (!A3.Enabled))
            {
                A1.BackColor = Color.Green;
                A2.BackColor = Color.Green;
                A3.BackColor = Color.Green;
                return true;
            }
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled) && (!B2.Enabled) && (!B3.Enabled))
            {
                B1.BackColor = Color.Green;
                B2.BackColor = Color.Green;
                B3.BackColor = Color.Green;
                return true;
            }
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled) && (!C2.Enabled) && (!C3.Enabled))
            {
                C1.BackColor = Color.Green;
                C2.BackColor = Color.Green;
                C3.BackColor = Color.Green;
                return true;
            }
            else 
            {
                return false;
            }
                
        }

        private bool isVerticalMatch()
        {
            if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled) && (!B1.Enabled) && (!C1.Enabled))
            {
                A1.BackColor = Color.Green;
                B1.BackColor = Color.Green;
                C1.BackColor = Color.Green;
                return true;
            }
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled) && (!B2.Enabled) && (!C2.Enabled))
            {
                A2.BackColor = Color.Green;
                B2.BackColor = Color.Green;
                C2.BackColor = Color.Green;
                return true;
            }
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled) && (!B3.Enabled) && (!C3.Enabled))
            {
                A3.BackColor = Color.Green;
                B3.BackColor = Color.Green;
                C3.BackColor = Color.Green;
                return true;
            }
            else
            {
                return false;
            }
         }

        private bool isDiagonalMatch()
        {
            if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled) && (!B2.Enabled) && (!C3.Enabled))
            {
                A1.BackColor = Color.Green;
                B2.BackColor = Color.Green;
                C3.BackColor = Color.Green;
                return true;
            }
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!A3.Enabled) && (!B2.Enabled) && (!C1.Enabled))
            {
                A3.BackColor = Color.Green;
                B2.BackColor = Color.Green;
                C1.BackColor = Color.Green;
                return true;
            }
            else
            {
                return false;
            }

        }
        //*/

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("By Tan, Frederick B. ", "Tic Tac Toe About");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void disableButtons()
        {
           Button[,] btn = new Button[,]
           {
                { A1, A2, A3 },
                { B1, B2,  B3},
                { C1, C2,  C3}
           };

            int i, j;
            for (i = 0; i < N_side; i++)
            {
                for (j = 0; j < N_side; j++)
                {
                    btn[i, j].Enabled = false;
                }
            }
            
        }


        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turn_count = 0;

            Button[,] btn = new Button[,]
            {
                { A1, A2, A3 },
                { B1, B2,  B3},
                { C1, C2,  C3}
            };

            int i, j;
            for (i = 0; i < N_side; i++)
            {
                for(j = 0; j < N_side; j++)
                {
                    btn[i, j].Enabled = true;
                    btn[i, j].BackColor = Color.White;
                    btn[i, j].Text = "";
                }
            }
            initiator();

         
        }
        //*
        private void playersTurnDisplay()
        {
            if(turn)
            {
                playersTurnLabel.Text = player_1 + " - " + Symbol;
            }
            else
            {
                playersTurnLabel.Text = player_2 + " - " + Symbol;
            }
        }
        //*/
    }
}
