using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tiny_Top_Adventure
{
    public partial class Form1 : Form
    {
        static Image F1 = Tiny_Top_Adventure.Properties.Resources.walkF1;
        static Image F2 = Tiny_Top_Adventure.Properties.Resources.walkF2;
        static Image B1 = Tiny_Top_Adventure.Properties.Resources.walkB1;
        static Image B2 = Tiny_Top_Adventure.Properties.Resources.walkB2;
        static Image L1 = Tiny_Top_Adventure.Properties.Resources.walkL1;
        static Image L2 = Tiny_Top_Adventure.Properties.Resources.walkL2;
        static Image R1 = Tiny_Top_Adventure.Properties.Resources.walkR1;
        static Image R2 = Tiny_Top_Adventure.Properties.Resources.walkR2;
        Image man = F1; 
        static int y = 20;
        static int x = 20;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //fsdkhfkjdsfdasf

        }

        private void Main_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(man, x, y, 30, 40);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)//if A is pressed
            {
                if (man == L1)
                { man = L2;}
                else
                { man = L1;}
                x = x - 10;//moves left
            }

            if (e.KeyCode == Keys.D)//if D is pressed
            {
                if (man == R1)
                { man = R2; }
                else
                { man = R1; }
                x = x + 10;//moves right
            }
            if (e.KeyCode == Keys.S)//if W is pressed
            {
                if (man == F1)
                { man = F2; }
                else
                { man = F1; }
                y = y + 10;//moves UP
            }
            if (e.KeyCode == Keys.W)//if D is pressed
            {
                if (man == B1)
                { man = B2; }
                else
                { man = B1; }
                y = y - 10;//moves down
            }
            Main.Refresh(); // refresh and update the picture box
            Main.Update();
        }
    }
}
