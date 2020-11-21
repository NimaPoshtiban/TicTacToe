using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        bool turn = true; // true = x turn false= y turn
        int turn_count = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {//background-color 
            BackColor = Color.AliceBlue;




        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Written By Nima", "About Programmer");
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)

                b.Text = "X";


            else


                b.Text = "O";

            turn = !turn;
            b.Enabled = false;
            turn_count++;
            _checkForWiner();

        }
        private void _checkForWiner()
        {
            bool there_is_a_winner = false;
            //horizontal checks
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
                there_is_a_winner = true;
           
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                there_is_a_winner = true;
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                there_is_a_winner = true;
            //Vertical checks 
            if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                there_is_a_winner = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                there_is_a_winner = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                there_is_a_winner = true;
            //Orib Checks
            if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                there_is_a_winner = true;
            if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!A3.Enabled))
                there_is_a_winner = true;
            //end of checks
            if (there_is_a_winner)
            {
                _disableButtons();
                String winner = "";
                if (turn)
                {
                    winner = "O";
                }
                else
                {
                    winner = "X";
                }
                MessageBox.Show(winner + " " + "Wins!", "Yay!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //checks for draw
            else
            {
                if (turn_count == 9)
                    MessageBox.Show("Draw", "Oops!");
            }

        }//end of the check for winer

        private void _disableButtons()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }//end of foreach
            }
            catch { }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void LightSeaGreen(object sender, EventArgs e)
        {

        }
    }
}
