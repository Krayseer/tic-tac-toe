using System;
using System.Windows.Forms;

namespace CrossAnZero
{
    public partial class Form1 : Form
    {
        public string type;
        bool crossWin, circleWin;
        readonly Button[,] btn = new Button[3, 3];
        readonly Random rnd = new Random();
        readonly int[,] field = new int[,] 
        {
            { 0, 0, 0 },
            { 0, 0, 0 },
            { 0, 0, 0 }
        };

        public Form1()
        {
            InitializeComponent();

            if (rnd.Next(1, 10) <= 5)
            {
                type = "Крестики";
                label1.Text = "Ходят X";
            }

            else
            {
                type = "Нолики";
                label1.Text = "Ходят 0";
            }

            btn = new Button[,] 
            { 
                { button1, button2, button3 }, 
                { button6, button5, button4 }, 
                { button9, button8, button7 } 
            };

            byte count = 0;

            foreach (var number in field)
                if (number == 0)
                    count++;

            if (count == 0)
            {
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
                        btn[i, j].Enabled = false;
                button10.Enabled = true;
                label1.Text = "Ничья";
            }

            count = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
                for(int j = 0; j < 3; j++)
                {
                    if (sender == btn[i, j])
                    {
                        if (type == "Крестики")
                        {
                            btn[i, j].Text = "Х";
                            label1.Text = "Ходят 0";
                            type = "Нолики";
                            btn[i, j].Enabled = false;
                            field[i, j] = 1;
                            break;
                        }

                        else
                        {
                            btn[i, j].Text = "0";
                            label1.Text = "Ходят X";
                            type = "Крестики";
                            btn[i, j].Enabled = false;
                            field[i, j] = 2;
                            break;
                        }
                    }
                }

            for (int i = 0; i < 3; i++)
            {
                if (field[i, 0] == field[i, 1] && field[i, 1] == field[i, 2] && field[i, 0] != 0)
                {
                    for(int j = 0; j < 3; j++)
                        btn[i, j].BackColor = System.Drawing.Color.Green;
                    if (field[i, 0] == 1) crossWin = true;
                    else if (field[i, 0] == 2) circleWin = true;
                }

                if (field[0, i] == field[1, i] && field[1, i] == field[2, i] && field[0, i] != 0)
                {
                    for (int j = 0; j < 3; j++)
                        btn[j, i].BackColor = System.Drawing.Color.Green;
                    if (field[0, i] == 1) crossWin = true;
                    else if (field[0, i] == 2) circleWin = true;
                }

                if (field[0, 0] == field[1, 1] && field[1, 1] == field[2, 2] && field[1, 1] != 0)
                {
                    for (int j = 0; j < 3; j++)
                        btn[i, i].BackColor = System.Drawing.Color.Green;
                    if (field[1, 1] == 1) crossWin = true;
                    else if (field[1, 1] == 2) circleWin = true;
                }
                
                if (field[0, 2] == field[1, 1] && field[1, 1] == field[2, 0] && field[1, 1] != 0)
                {
                    btn[0, 2].BackColor = System.Drawing.Color.Green;
                    btn[1, 1].BackColor = System.Drawing.Color.Green;
                    btn[2, 0].BackColor = System.Drawing.Color.Green;
                    if (field[1, 1] == 1)
                        crossWin = true;
                    else if (field[1, 1] == 2)
                        circleWin = true;
                }
            }

            if (crossWin)
            {
                for (int i = 0; i < 3; i++)
                    for(int j = 0; j < 3; j++)
                        btn[i, j].Enabled = false;
                button10.Enabled = true;
                label1.Text = "Выйграли крестики";
            }

            if (circleWin)
            {
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
                        btn[i, j].Enabled = false;
                button10.Enabled = true;
                label1.Text = "Выйграли нолики";
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            circleWin = false;
            crossWin = false;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    field[i, j] = 0;
                    btn[i, j].Text = "";

                    if (rnd.Next(1, 10) <= 5)
                    {
                        type = "Крестики";
                        label1.Text = "Ходят X";
                    }

                    else
                    {
                        type = "Нолики";
                        label1.Text = "Ходят 0";
                    }

                    btn[i, j].Enabled = true;
                    btn[i, j].BackColor = System.Drawing.Color.White;
                }
        }

        private void label1_Click(object sender, EventArgs e) { }

        private void Form1_Load(object sender, EventArgs e) { }
    }
}
