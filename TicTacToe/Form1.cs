using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        bool singlePlayer = false;
        bool turn = true; // true = x turn false= y turn
        int turn_count = 0;

        public Form1()
        {
           
            InitializeComponent();
            var answer = MessageBox.Show("Wanna Play signle mode?", "Welcome!", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (answer == DialogResult.Yes)
            {
                singlePlayer = true;
                singlePlayerToolStripMenuItem.Checked = true;
                singlePlayerToolStripMenuItem.BackColor = Color.White;
            }
            singlePlayerToolStripMenuItem.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {//background-color 
            BackColor = Color.AliceBlue;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Written By Nima", "About Programmer");
        }

      

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (singlePlayer)
            {
                b.Text = "X";
                b.Enabled = false;
                turn = !turn;
                _checkForWiner();
                turn_count++;
                playAsAI();
            }
            else
            {
                if (turn)
                {
                    b.ForeColor = Color.Red;
                    b.Text = "X";
                }
                else
                {

                    b.Text = "O";

                }
                turn = !turn;
                b.Enabled = false;

            }
            turn_count++;
            _checkForWiner();

        }

        private void playAsAI()
        {
            var resultPtr = transformDataIntoMatrix();
            int[][] result = { new int[] { 0, 0, 0 }, new int[] { 0, 0, 0 }, new int[] { 0, 0, 0 } };
            for (int i = 0; i < 3; i++)
            {
                IntPtr rowPtr = Marshal.ReadIntPtr(resultPtr, i * Marshal.SizeOf<IntPtr>());
                for (global::System.Int32 j = 0; j < 3; j++)
                {
                    result[i][j] = Marshal.ReadInt32(rowPtr, j * Marshal.SizeOf<int>());
                }
            }
            transformMatrixIntoText(result);
            turn = !turn;
            _checkForWiner();
        }

        private unsafe void transformMatrixIntoText(int[][] result)
        {
            if (result[0][0] == 2)
            {
                A1.Text = "O";
                A1.Enabled = false;
            }
           
            if (result[0][1] == 2)
            {
                A2.Text = "O";
                A2.Enabled = false;

            }


            if (result[0][2] == 2)
            {
                A3.Text = "O";
                A3.Enabled = false;

            }

            if (result[1][0] == 2)
            {
                B1.Text = "O";
                B1.Enabled = false;
            }
     

            if (result[1][1] == 2)
            {
                B2.Text = "O";
                B2.Enabled = false;

            }


            if (result[1][2] == 2)
            {
                B3.Text = "O";
                B3.Enabled = false;
            }

            if (result[2][0] == 2)
            {
                C1.Text = "O";
                C1.Enabled = false;
            }
          

            if (result[2][1] == 2)
            {
                C2.Text = "O";
                C2.Enabled = false;
            }

            if (result[2][2] == 2)
            {
                C3.Text = "O";
                C3.Enabled = false;
            }

        }

        private IntPtr transformDataIntoMatrix()
        {
            int[][] array = new int[3][]
            {
            new int[3],
            new int[3],
            new int[3]
            };


            FillArray(array);

            IntPtr[] platePtrs = new IntPtr[3];
            for (int i = 0; i < 3; i++)
            {
                platePtrs[i] = Marshal.AllocHGlobal(Marshal.SizeOf<int>() * 3);
                for (int j = 0; j < 3; j++)
                {
                    Marshal.WriteInt32(platePtrs[i], j * Marshal.SizeOf<int>(), array[i][j]);
                }
            }

            IntPtr platePtr = Marshal.AllocHGlobal(Marshal.SizeOf<IntPtr>() * 3);
            for (int i = 0; i < 3; i++)
            {
                Marshal.WriteIntPtr(platePtr, i * Marshal.SizeOf<IntPtr>(), platePtrs[i]);
            }

            IntPtr resultPtr = IntPtr.Zero;
            resultPtr = answer_as_o(platePtr);



            return resultPtr;
        }

        private void FillArray(int[][] array)
        {
            array[0][0] = A1.Text == "O" ? 2 : (A1.Text == "X" ? 1 : 0);
            array[0][1] = A2.Text == "O" ? 2 : (A2.Text == "X" ? 1 : 0);
            array[0][2] = A3.Text == "O" ? 2 : (A3.Text == "X" ? 1 : 0);
            array[1][0] = B1.Text == "O" ? 2 : (B1.Text == "X" ? 1 : 0);
            array[1][1] = B2.Text == "O" ? 2 : (B2.Text == "X" ? 1 : 0);
            array[1][2] = B3.Text == "O" ? 2 : (B3.Text == "X" ? 1 : 0);
            array[2][0] = C1.Text == "O" ? 2 : (C1.Text == "X" ? 1 : 0);
            array[2][1] = C2.Text == "O" ? 2 : (C2.Text == "X" ? 1 : 0);
            array[2][2] = C3.Text == "O" ? 2 : (C3.Text == "X" ? 1 : 0);
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
                var answer = MessageBox.Show("Wanna play again?", "Game has ended", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (answer==DialogResult.Yes)
                {
                    Application.Restart();
                }
                else
                {
                    Application.Exit();
                }
            }
            //checks for draw
            else
            {
                if (turn_count >= 9)
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

        private void singlePlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            singlePlayer = true;
        }
        [DllImport("C:\\ProgramData\\TicTacToe\\AI.dll", EntryPoint = "answer_as_o", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr answer_as_o(IntPtr matrix);
    }
}
