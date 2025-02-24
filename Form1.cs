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
        struct obstacle//Structure of Obstacle
        {
            public Image imageName;
            public int xLoc;
            public int yLoc;
            public int width;
            public int height;
            public Rectangle bounds;
        }
        obstacle[] obstacles = new obstacle[3]; // we have space for 3 objects in our array.
                                                // These are fixed and don't change so an array is appropriate
        int charWidth = 30;
        int charHeight = 40;
        static Image F1 = Tiny_Top_Adventure.Properties.Resources.walkF1;
        static Image F2 = Tiny_Top_Adventure.Properties.Resources.walkF2;
        static Image B1 = Tiny_Top_Adventure.Properties.Resources.walkB1;
        static Image B2 = Tiny_Top_Adventure.Properties.Resources.walkB2;
        static Image L1 = Tiny_Top_Adventure.Properties.Resources.walkL1;
        static Image L2 = Tiny_Top_Adventure.Properties.Resources.walkL2;
        static Image R1 = Tiny_Top_Adventure.Properties.Resources.walkR1;
        static Image R2 = Tiny_Top_Adventure.Properties.Resources.walkR2;
        static Image fence = Tiny_Top_Adventure.Properties.Resources.Fence;
        Image man = F1; 
        static int y = 20;
        static int x = 20;  

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            obstacles[0] = new obstacle
            {
                imageName = fence,
                xLoc = 500,
                yLoc = 450,
                width = 45,
                height = 40,
                bounds = new Rectangle(500, 450, 45, 40)
            };

            obstacles[1] = new obstacle
            {
                imageName = fence,
                xLoc = 350,
                yLoc = 400,
                width = 45,
                height = 40,
                bounds = new Rectangle(350, 400, 45, 40)
            };

            obstacles[2] = new obstacle
            {
                imageName = fence,
                xLoc = 580,
                yLoc = 300,
                width = 45,
                height = 40,
                bounds = new Rectangle(580, 300, 45, 40)
            };


        }

        private void Main_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(man, x, y, charWidth, charHeight );// charWidth and charHeight  are the charcter size
            for (int i = 0; i < 3; i++)
            {
                e.Graphics.DrawImage(obstacles[i].imageName, obstacles[i].xLoc, obstacles[i].yLoc, obstacles[i].width, obstacles[i].height);
            }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)//movement of the character
        { 
            int Gap = 10;// movement speed
            if (e.KeyCode == Keys.A && x - Gap >= 0)//if A is pressed
            {
                if (man == L1)
                { man = L2;}
                else
                { man = L1;}
                if (!checkCollision())
                { x = x - 10; }//move left
                else
                { x = x + 10; }// bounce back or we'll stick to the obstacle
            }

            if (e.KeyCode == Keys.D && x + Gap + charWidth <= Main.Width)//if D is pressed
            {
                if (man == R1)
                { man = R2; }
                else
                { man = R1; }
                if (!checkCollision())
                { x = x + 10; }//move left
                else
                { x = x - 10; }// bounce back or we'll stick to the obstacle
            }
            if (e.KeyCode == Keys.S && y + Gap + charHeight  <= Main.Height)//if W is pressed
            {
                if (man == F1)
                { man = F2; }
                else
                { man = F1; }
                if (!checkCollision())
                { y = y+ 10; }//move down
                else
                { y = y - 10; }// bounce back or we'll stick to the obstacle
                
            }
            if (e.KeyCode == Keys.W && y - Gap >= 0)//if D is pressed
            {
                if (man == B1)
                { man = B2; }
                else
                { man = B1; }
                if (!checkCollision())
                { y = y - 10; }//move up
                else
                { y = y + 10; }// bounce back or we'll stick to the obstacle
                
            }
            Main.Refresh(); // refresh and update the picture box
            Main.Update();
        }
        private Boolean checkCollision()// is an obstacle blocking the way
        { Boolean collision = false;
            RectangleF manBound = new RectangleF(x, y, 30, 40);            
                    for (int i = 0; i < 3; i++) //iterate through the obstacle array
            {
                if (manBound.IntersectsWith(obstacles[i].bounds))
                {
                    collision = true;
                }               
            }
                return collision;            
        }


    }
}
