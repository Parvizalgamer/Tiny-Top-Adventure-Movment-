using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Tiny_Top_Adventure
{
    public partial class Form1 : Form
    {

        static Image[] SonicR = new Image[]
        {
            Tiny_Top_Adventure.Properties.Resources.R1, // Replace with your actual resource names
            Tiny_Top_Adventure.Properties.Resources.R2,
            Tiny_Top_Adventure.Properties.Resources.R3,
            Tiny_Top_Adventure.Properties.Resources.R4,
            Tiny_Top_Adventure.Properties.Resources.R5,
            Tiny_Top_Adventure.Properties.Resources.R6,
            Tiny_Top_Adventure.Properties.Resources.R7,
            Tiny_Top_Adventure.Properties.Resources.R8,
            Tiny_Top_Adventure.Properties.Resources.R9,
            Tiny_Top_Adventure.Properties.Resources.R10
        };
        static Image[] SonicL = new Image[]
        {
            Tiny_Top_Adventure.Properties.Resources.L1, // Replace with your actual resource names
            Tiny_Top_Adventure.Properties.Resources.L2,
            Tiny_Top_Adventure.Properties.Resources.L3,
            Tiny_Top_Adventure.Properties.Resources.L4,
            Tiny_Top_Adventure.Properties.Resources.L5,
            Tiny_Top_Adventure.Properties.Resources.L6,
            Tiny_Top_Adventure.Properties.Resources.L7,
            Tiny_Top_Adventure.Properties.Resources.L8,
            Tiny_Top_Adventure.Properties.Resources.L9,
            Tiny_Top_Adventure.Properties.Resources.L10
        };
        static Image[] SonicU = new Image[]
        {
            Tiny_Top_Adventure.Properties.Resources.B1, // Replace with your actual resource names
            Tiny_Top_Adventure.Properties.Resources.B2,
            Tiny_Top_Adventure.Properties.Resources.B3,
            Tiny_Top_Adventure.Properties.Resources.B4,
            Tiny_Top_Adventure.Properties.Resources.B5,
            Tiny_Top_Adventure.Properties.Resources.B6,
            Tiny_Top_Adventure.Properties.Resources.B7,
            Tiny_Top_Adventure.Properties.Resources.B8,
            Tiny_Top_Adventure.Properties.Resources.B9, 
        };
        static Image[] SonicD = new Image[]
        {
            Tiny_Top_Adventure.Properties.Resources.F1, // Replace with your actual resource names
            Tiny_Top_Adventure.Properties.Resources.F2,
            Tiny_Top_Adventure.Properties.Resources.F3,
            Tiny_Top_Adventure.Properties.Resources.F4,
            Tiny_Top_Adventure.Properties.Resources.F5,
            Tiny_Top_Adventure.Properties.Resources.F6,
        };
        int rightMoveFrame = 0;
        bool isMovingRight = false;
        int leftMoveFrame = 0;
        bool isMovingLeft = false;

        int upMoveFrame = 0;
        bool isMovingUp = false;

        int downMoveFrame = 0;
        bool isMovingDown = false;
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
        static Image coinFront = Tiny_Top_Adventure.Properties.Resources.Coin_4;
        List<obstacle> coinList = new List<obstacle>();
        int coins;
        int charWidth = 30;
        int charHeight = 40;
        static Image F1 = Tiny_Top_Adventure.Properties.Resources.walkF1;
        static Image F2 = Tiny_Top_Adventure.Properties.Resources.walkF2;
        static Image B1 = Tiny_Top_Adventure.Properties.Resources.walkB1;
        static Image B2 = Tiny_Top_Adventure.Properties.Resources.walkB2;
        static Image L1 = Tiny_Top_Adventure.Properties.Resources.walkL1;
        static Image L2 = Tiny_Top_Adventure.Properties.Resources.walkL2;
        //static Image R1 = Tiny_Top_Adventure.Properties.Resources.walkR1;
        //static Image R2 = Tiny_Top_Adventure.Properties.Resources.walkR2;
        static Image fence = Tiny_Top_Adventure.Properties.Resources.Fence;

        static Image[] coinImages = new Image[]
        {
            Tiny_Top_Adventure.Properties.Resources.Coin_1,
            Tiny_Top_Adventure.Properties.Resources.Coin_2,
            Tiny_Top_Adventure.Properties.Resources.Coin_3,
            Tiny_Top_Adventure.Properties.Resources.Coin_4,
            Tiny_Top_Adventure.Properties.Resources.Coin_5,
            Tiny_Top_Adventure.Properties.Resources.Coin_6,
            Tiny_Top_Adventure.Properties.Resources.Coin_7,
            Tiny_Top_Adventure.Properties.Resources.Coin_8,
            Tiny_Top_Adventure.Properties.Resources.Coin_9,
            Tiny_Top_Adventure.Properties.Resources.Coin_10,
            Tiny_Top_Adventure.Properties.Resources.Coin_11,
            Tiny_Top_Adventure.Properties.Resources.Coin_12,
            Tiny_Top_Adventure.Properties.Resources.Coin_13,
        };
        int coinFrame = 0; // Keeps track of the current coin image



        Image man = F1;
        static int y = 20;
        static int x = 20;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rightMoveTimer.Enabled = true;
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

            coins = 0;
            int coinx = 400;
            float scaleFactor = 0.2f; // Same scale factor as in Main_Paint

            for (int i = 0; i < 10; i++)
            {
                Image coinImage = coinImages[0]; // Use any coin image to get dimensions
                int originalWidth = coinImage.Width;
                int originalHeight = coinImage.Height;

                int scaledWidth = (int)(originalWidth * scaleFactor);
                int scaledHeight = (int)(originalHeight * scaleFactor);

                coinList.Add(new obstacle()
                {
                    imageName = coinFront,
                    xLoc = coinx,
                    yLoc = 400,
                    width = scaledWidth, // Use scaled width for hitbox
                    height = scaledHeight, // Use scaled height for hitbox
                    bounds = new Rectangle(coinx - scaledWidth / 2, 400 - scaledHeight / 2, scaledWidth, scaledHeight) // Center the hitbox
                });
                coinx = coinx + 40;
            }
        }

        private void Main_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(man, x, y, charWidth, charHeight);// charWidth and charHeight  are the charcter size
            for (int i = 0; i < 3; i++)
            {
                e.Graphics.DrawImage(obstacles[i].imageName, obstacles[i].xLoc, obstacles[i].yLoc, obstacles[i].width, obstacles[i].height);
            }
            if (coinList.Count > 0)
            {
                float scaleFactor = 0.35f; // Adjust this value to your desired size (e.g., 0.5 for half size)

                foreach (var coin in coinList)
                {
                    Image currentCoinImage = coinImages[coinFrame];
                    int originalWidth = currentCoinImage.Width;
                    int originalHeight = currentCoinImage.Height;

                    // Calculate scaled dimensions
                    int scaledWidth = (int)(originalWidth * scaleFactor);
                    int scaledHeight = (int)(originalHeight * scaleFactor);

                    // Draw the coin centered using scaled dimensions
                    e.Graphics.DrawImage(currentCoinImage,
                        coin.xLoc - scaledWidth / 2,
                        coin.yLoc - scaledHeight / 2,
                        scaledWidth,
                        scaledHeight);
                }
            }

            if (isMovingRight)
            {
                e.Graphics.DrawImage(SonicR[rightMoveFrame], x, y, charWidth, charHeight);
            }
            else if (isMovingLeft)
            {
                e.Graphics.DrawImage(SonicL[leftMoveFrame], x, y, charWidth, charHeight);
            }
            else if (isMovingUp)
            {
                e.Graphics.DrawImage(SonicU[upMoveFrame], x, y, charWidth, charHeight);
            }
            else if (isMovingDown)
            {
                e.Graphics.DrawImage(SonicD[downMoveFrame], x, y, charWidth, charHeight);
            }
            else
            {
                e.Graphics.DrawImage(man, x, y, charWidth, charHeight); // Draw the standing sprite
            }
            if (coinList.Count > 0)
            {
                float scaleFactor = 0.35f; // Adjust this value to your desired size (e.g., 0.5 for half size)

                foreach (var coin in coinList)
                {
                    Image currentCoinImage = coinImages[coinFrame];
                    int originalWidth = currentCoinImage.Width;
                    int originalHeight = currentCoinImage.Height;

                    // Calculate scaled dimensions
                    int scaledWidth = (int)(originalWidth * scaleFactor);
                    int scaledHeight = (int)(originalHeight * scaleFactor);

                    // Draw the coin centered using scaled dimensions
                    e.Graphics.DrawImage(currentCoinImage,
                        coin.xLoc - scaledWidth / 2,
                        coin.yLoc - scaledHeight / 2,
                        scaledWidth,
                        scaledHeight);
                }
            }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)//movement of the character
        {
            int Gap = 10;
            bool moved = false;

            if (e.KeyCode == Keys.A && x - Gap >= 0)
            {
                isMovingRight = false;
                isMovingUp = false;
                isMovingDown = false;
                isMovingLeft = true;
                leftMoveFrame = 0;
                x -= Gap;
                moved = true;
                if (x < 0) x = pictureBox1.Width;
            }
            if (e.KeyCode == Keys.D && x + Gap + charWidth <= Main.Width)
            {
                isMovingLeft = false;
                isMovingUp = false;
                isMovingDown = false;
                isMovingRight = true;
                rightMoveFrame = 0;
                x += Gap;
                moved = true;
            }
            if (e.KeyCode == Keys.S && y + Gap + charHeight <= Main.Height)
            {
                isMovingRight = false;
                isMovingLeft = false;
                isMovingUp = false;
                isMovingDown = true;
                downMoveFrame = 0;
                y += Gap;
                moved = true;
            }
            if (e.KeyCode == Keys.W && y - Gap >= 0)
            {
                isMovingRight = false;
                isMovingLeft = false;
                isMovingDown = false;
                isMovingUp = true;
                upMoveFrame = 0;
                y -= Gap;
                moved = true;
            }
            if (moved)
            {
                if (checkCollision())
                {
                    if (e.KeyCode == Keys.A) x += Gap;
                    if (e.KeyCode == Keys.D) x -= Gap;
                    if (e.KeyCode == Keys.S) y -= Gap;
                    if (e.KeyCode == Keys.W) y += Gap;
                }
                checkCoins();
                Main.Refresh();
            }
        }
        private Boolean checkCollision()// is an obstacle blocking the way
        {
            Boolean collision = false;
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
        private Boolean checkCoins()
        {
            RectangleF manBound = new RectangleF(x, y, 30, 40);
            for (int i = 0; i < coinList.Count; i++)
            {
                if (manBound.IntersectsWith(coinList[i].bounds))
                {
                    coinList.RemoveAt(i);
                    coins++;
                    Coins_label.Text = coins.ToString();
                }
            }
            return true;
        }
        bool coinReverse = false; // Flag to track animation direction
        private void coinTimer_Tick(object sender, EventArgs e)
        {
            if (!coinReverse)
            {
                coinFrame++;
                if (coinFrame >= coinImages.Length - 1) coinReverse = true;
            }
            else
            {
                coinFrame--;
                if (coinFrame <= 0) coinReverse = false;
            }

            Main.Invalidate(); // Redraw the game screen
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D)
            {
                isMovingRight = false;
            }
            if (e.KeyCode == Keys.A)
            {
                isMovingLeft = false;
            }
            if (e.KeyCode == Keys.W)
            {
                isMovingUp = false;
            }
            if (e.KeyCode == Keys.S)
            {
                isMovingDown = false;
            }

        }

        private void rightMoveTimer_Tick(object sender, EventArgs e)
        {
            if (isMovingRight)
            {
                rightMoveFrame++;
                if (rightMoveFrame >= SonicR.Length) rightMoveFrame = 0;
            }
            if (isMovingLeft)
            {
                leftMoveFrame++;
                if (leftMoveFrame >= SonicL.Length) leftMoveFrame = 0;
            }
            if (isMovingUp)
            {
                upMoveFrame++;
                if (upMoveFrame >= SonicU.Length) upMoveFrame = 0;
            }
            if (isMovingDown)
            {
                downMoveFrame++;
                if (downMoveFrame >= SonicD.Length) downMoveFrame = 0;
            }

            Main.Invalidate();
        }
    }
}
