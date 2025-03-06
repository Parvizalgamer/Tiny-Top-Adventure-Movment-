using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Tiny_Top_Adventure
{
    public partial class Form1 : Form
    {
        //https://info.sonicretro.org/Sonic_the_Hedgehog_(16-bit)/Maps maps and sprites

        static Image[] SonicR = new Image[]
        {
            Tiny_Top_Adventure.Properties.Resources.R1,
            Tiny_Top_Adventure.Properties.Resources.R2,
            Tiny_Top_Adventure.Properties.Resources.R3,
            Tiny_Top_Adventure.Properties.Resources.R4,
            Tiny_Top_Adventure.Properties.Resources.R5,
            Tiny_Top_Adventure.Properties.Resources.R6,
            Tiny_Top_Adventure.Properties.Resources.R7,
            Tiny_Top_Adventure.Properties.Resources.R8,
            Tiny_Top_Adventure.Properties.Resources.R9,
            Tiny_Top_Adventure.Properties.Resources.R10
        };// right moving sonic array
        static Image[] SonicL = new Image[]
        {
            Tiny_Top_Adventure.Properties.Resources.L1,
            Tiny_Top_Adventure.Properties.Resources.L2,
            Tiny_Top_Adventure.Properties.Resources.L3,
            Tiny_Top_Adventure.Properties.Resources.L4,
            Tiny_Top_Adventure.Properties.Resources.L5,
            Tiny_Top_Adventure.Properties.Resources.L6,
            Tiny_Top_Adventure.Properties.Resources.L7,
            Tiny_Top_Adventure.Properties.Resources.L8,
            Tiny_Top_Adventure.Properties.Resources.L9,
            Tiny_Top_Adventure.Properties.Resources.L10
        };// left moving sonic array
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
        };//to cahnge with futher 
        static Image[] SonicD = new Image[]
        {
            Tiny_Top_Adventure.Properties.Resources.F1, // Replace with your actual resource names
            Tiny_Top_Adventure.Properties.Resources.F2,
            Tiny_Top_Adventure.Properties.Resources.F3,
            Tiny_Top_Adventure.Properties.Resources.F4,
            Tiny_Top_Adventure.Properties.Resources.F5,
            Tiny_Top_Adventure.Properties.Resources.F6,
        };// to cahnge wuith further

        // Animation Frame Indexes and Movement Flags
        int rightMoveFrame = 0;
        bool isMovingRight = false;
        int leftMoveFrame = 0;
        bool isMovingLeft = false;
        int upMoveFrame = 0;
        bool isMovingUp = false;
        int downMoveFrame = 0;
        bool isMovingDown = false;
        int idleFrame = 0;

        // Gravity and Jumping
        private int verticalVelocity = 0;
        private int gravity = 1;
        private bool isJumping = false;
        private int jumpHeight = -20; // Adjusted jump height

        private Timer idleTimer;
        static Image[] SonicIdle = new Image[]
{
    Tiny_Top_Adventure.Properties.Resources.frame_00_delay_2s,
    Tiny_Top_Adventure.Properties.Resources.frame_01_delay_0_08s,
    Tiny_Top_Adventure.Properties.Resources.frame_02_delay_0_08s,
    Tiny_Top_Adventure.Properties.Resources.frame_03_delay_0_16s,
    Tiny_Top_Adventure.Properties.Resources.frame_04_delay_0_08s,
    Tiny_Top_Adventure.Properties.Resources.frame_05_delay_0_08s,
    Tiny_Top_Adventure.Properties.Resources.frame_06_delay_0_08s,
    Tiny_Top_Adventure.Properties.Resources.frame_07_delay_0_08s,
    Tiny_Top_Adventure.Properties.Resources.frame_08_delay_0_24s,
    Tiny_Top_Adventure.Properties.Resources.frame_09_delay_0_13s,
    Tiny_Top_Adventure.Properties.Resources.frame_10_delay_0_2s,
    Tiny_Top_Adventure.Properties.Resources.frame_11_delay_0_13s,
    Tiny_Top_Adventure.Properties.Resources.frame_12_delay_0_2s,
    Tiny_Top_Adventure.Properties.Resources.frame_13_delay_0_13s,
    Tiny_Top_Adventure.Properties.Resources.frame_14_delay_0_2s,
    Tiny_Top_Adventure.Properties.Resources.frame_15_delay_0_13s,
    Tiny_Top_Adventure.Properties.Resources.frame_16_delay_0_2s,
    Tiny_Top_Adventure.Properties.Resources.frame_17_delay_0_13s,
    Tiny_Top_Adventure.Properties.Resources.frame_18_delay_0_2s,
    Tiny_Top_Adventure.Properties.Resources.frame_19_delay_0_13s,
    Tiny_Top_Adventure.Properties.Resources.frame_20_delay_0_83s,
};// IDLE animation


        // Character Movement Speed and Previous Position
        private int movementSpeed = 10;// sonic speed
        private int previousX;
        private int previousY;

        //Camera Control Variable
        private int cameraX = 0;
        private int cameraY = 0;
        private int cameraOffsetX = 200; // Increased offset
        private int cameraOffsetY = 150; // Increased offset
        private float cameraDamping = 0.1f; // Adjust for smoother vertical movement

        struct obstacle//Structure of Obstacle
        {
            public Image imageName;
            public int xLoc;
            public int yLoc;
            public int width;
            public int height;
            public Rectangle bounds;
        }
        obstacle[] obstacles = new obstacle[3]; // we have space for 3 objects in our array. These are fixed and don't change so an array is appropriate
        static Image fence = Tiny_Top_Adventure.Properties.Resources.Fence;

        // Coin Data and List
        static Image coinFront = Tiny_Top_Adventure.Properties.Resources.Coin_4;
        List<obstacle> coinList = new List<obstacle>();
        int coins;
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
        };// coins array
        int coinFrame = 0; // Keeps track of the current coin image

        // Man
        static Image F1 = Tiny_Top_Adventure.Properties.Resources.walkF1;
        Image man = F1;
        static int y = 20;
        static int x = 20;
        int charWidth = 50;
        int charHeight = 60;


        public Form1()
        {
            InitializeComponent();
            movementTimer = new Timer();
            movementTimer.Interval = 1000 / 60; // 60 updates per second
            movementTimer.Tick += movementTimer_Tick;
            movementTimer.Enabled = true;


            idleTimer = new Timer();
            idleTimer.Interval = 1000 / 8; // Example: 15 updates per second (idle) - adjust as needed
            idleTimer.Tick += idleTimer_Tick;
            idleTimer.Enabled = true;
        }
        // Movement Timer Tick Event (Handles Character Movement and Collision)
        private void movementTimer_Tick(object sender, EventArgs e)
        {
            int oldX = x;
            int oldY = y;
            int oldRightFrame = rightMoveFrame;
            int oldLeftFrame = leftMoveFrame;
            int oldUpFrame = upMoveFrame;
            int oldDownFrame = downMoveFrame;

            previousX = x;
            previousY = y;

            // Horizontal Movement
            if (isMovingRight && x + movementSpeed + charWidth <= Main.Width) { x += movementSpeed; }
            if (isMovingLeft && x - movementSpeed >= 0) { x -= movementSpeed; }

            // Gravity and Jumping
            if (isJumping)
            {
                y += verticalVelocity;
                verticalVelocity += gravity; // Apply gravity while jumping/falling
                if (isOnGround()) // Check for landing
                {
                    isJumping = false;
                    verticalVelocity = 0;
                }
            }
            else if (!isOnGround())
            {
                verticalVelocity += gravity;
                y += verticalVelocity;
            }
            else
            {
                verticalVelocity = 0;
            }

            // Collision Detection
            if (checkCollision())
            {
                x = previousX;
                y = previousY;
                verticalVelocity = 0;
                isJumping = false; // Ensure isJumping is false after collision
            }

            checkCoins();

            // Update camera X position (keep it as before)
            cameraX = x - Main.Width / 2 + cameraOffsetX;

            // Update camera Y position with damping
            float targetCameraY = y - Main.Height / 2 + cameraOffsetY;
            cameraY += (int)((targetCameraY - cameraY) * cameraDamping);

            // Ensure camera stays within bounds
            cameraX = Math.Max(0, Math.Min(cameraX, backgroundImage.Width - Main.Width)); // Adjust bounds if needed
            cameraY = Math.Max(0, Math.Min(cameraY, backgroundImage.Height - Main.Height)); // Adjust bounds if needed

            // Animation Logic
            if (isMovingRight) { rightMoveFrame++; if (rightMoveFrame >= SonicR.Length) rightMoveFrame = 0; }
            if (isMovingLeft) { leftMoveFrame++; if (leftMoveFrame >= SonicL.Length) leftMoveFrame = 0; }
            if (isMovingUp) { upMoveFrame++; if (upMoveFrame >= SonicU.Length) upMoveFrame = 0; }
            if (isMovingDown) { downMoveFrame++; if (downMoveFrame >= SonicD.Length) downMoveFrame = 0; }

            if (oldX != x || oldY != y || oldRightFrame != rightMoveFrame || oldLeftFrame != leftMoveFrame || oldUpFrame != upMoveFrame || oldDownFrame != downMoveFrame)
            {
                Main.Invalidate(new Rectangle(Math.Min(oldX, x), Math.Min(oldY, y), charWidth, charHeight));
                Main.Invalidate(new Rectangle(Math.Max(oldX, x), Math.Max(oldY, y), charWidth, charHeight));
            }
            // Horizontal Border Checks
            if (x < 0)
            {
                x = 0;
                isMovingLeft = false;
            }
            if (x + charWidth > backgroundImage.Width)
            {
                x = backgroundImage.Width - charWidth;
                isMovingRight = false;
            }

            // Collision Detection
            if (checkCollision())
            {
                x = previousX;
                y = previousY;
                verticalVelocity = 0;
                isJumping = false;
                isMovingRight = false;
                isMovingLeft = false;
                isMovingUp = false;
                isMovingDown = false;
            }
        }

        private void idleTimer_Tick(object sender, EventArgs e)
        {
            if (!isMovingRight && !isMovingLeft && !isMovingUp && !isMovingDown && !isJumping)
            {
                idleFrame++;
                if (idleFrame >= SonicIdle.Length) idleFrame = 0;
                Main.Invalidate();
            }
        }


        private Image backgroundImage;
        private RectangleF groundBounds; // Rectangle for the ground
        private void Form1_Load(object sender, EventArgs e)

        { // Initialize Obstacles
            obstacles[0] = new obstacle { imageName = fence, xLoc = 500, yLoc = 450, width = 45, height = 40, bounds = new Rectangle(500, 450, 45, 40) };
            obstacles[1] = new obstacle { imageName = fence, xLoc = 350, yLoc = 400, width = 45, height = 40, bounds = new Rectangle(350, 400, 45, 40) };
            obstacles[2] = new obstacle { imageName = fence, xLoc = 580, yLoc = 300, width = 45, height = 40, bounds = new Rectangle(580, 300, 45, 40) };

            backgroundImage = Properties.Resources.Level1;

            if (backgroundImage != null)
            {
                // Define the desired size (adjust these values)
                int desiredWidth = 5000; // Example desired width


                // Resize the image
                backgroundImage = ResizeImage(backgroundImage, desiredWidth);

                // adjust character starting position.
                x = backgroundImage.Width / 2;
                y = backgroundImage.Height / 2;

                // Scale Obstacle positions
                float widthScale = (float)backgroundImage.Width / Properties.Resources.Level1.Width;
                float heightScale = (float)backgroundImage.Height / Properties.Resources.Level1.Height;

                for (int i = 0; i < obstacles.Length; i++)
                {
                    obstacles[i].xLoc = (int)(obstacles[i].xLoc * widthScale);
                    obstacles[i].yLoc = (int)(obstacles[i].yLoc * heightScale);
                    obstacles[i].bounds = new Rectangle(obstacles[i].xLoc, obstacles[i].yLoc, obstacles[i].width, obstacles[i].height);
                }

                // Scale Coin positions
                coins = 0;
                int coinx = 400;
                float coinScaleFactor = 0.2f;

                coinList.Clear(); // clear the old coin list.
                for (int i = 0; i < 10; i++)
                {
                    Image coinImage = coinImages[0];
                    int scaledWidth = (int)(coinImage.Width * coinScaleFactor);
                    int scaledHeight = (int)(coinImage.Height * coinScaleFactor);
                    coinList.Add(new obstacle()
                    {
                        imageName = coinFront,
                        xLoc = (int)(coinx * widthScale), // Scale x position
                        yLoc = (int)(400 * heightScale), // Scale y position
                        width = scaledWidth,
                        height = scaledHeight,
                        bounds = new Rectangle((int)(coinx * widthScale) - scaledWidth / 2, (int)(400 * heightScale) - scaledHeight / 2, scaledWidth, scaledHeight)
                    });
                    coinx += 40;
                }
                groundBounds = new RectangleF(0, backgroundImage.Height - 10, backgroundImage.Width, 10); // Adjust the height as needed
            }
        }



        private Image ResizeImage(Image image, int width) // Only take width as input
        {
            // Calculate new height based on original aspect ratio
            int originalWidth = image.Width;
            int originalHeight = image.Height;
            float aspectRatio = (float)originalWidth / originalHeight;

            int newHeight = (int)(width / aspectRatio); // Calculate the new height

            var destRect = new Rectangle(0, 0, width, newHeight);
            var destImage = new Bitmap(width, newHeight);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new System.Drawing.Imaging.ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
        private void Main_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(backgroundImage, -cameraX, -cameraY);

            // Draw obstacles
            for (int i = 0; i < 3; i++)
            {
                e.Graphics.DrawImage(obstacles[i].imageName,
                    obstacles[i].xLoc - cameraX, // Apply camera offset
                    obstacles[i].yLoc - cameraY, // Apply camera offset
                    obstacles[i].width, obstacles[i].height);
            }

            // Draw character
            if (isMovingRight) { e.Graphics.DrawImage(SonicR[rightMoveFrame], x - cameraX, y - cameraY, charWidth, charHeight); }
            else if (isMovingLeft) { e.Graphics.DrawImage(SonicL[leftMoveFrame], x - cameraX, y - cameraY, charWidth, charHeight); }
            else if (isMovingUp) { e.Graphics.DrawImage(SonicU[upMoveFrame], x - cameraX, y - cameraY, charWidth, charHeight); }
            else if (isMovingDown) { e.Graphics.DrawImage(SonicD[downMoveFrame], x - cameraX, y - cameraY, charWidth, charHeight); }
            else { e.Graphics.DrawImage(SonicIdle[idleFrame], x - cameraX, y - cameraY, charWidth, charHeight); }

            // Draw coins
            if (coinList.Count > 0)
            {
                float scaleFactor = 0.35f;

                foreach (var coin in coinList)
                {
                    Image currentCoinImage = coinImages[coinFrame];
                    int originalWidth = currentCoinImage.Width;
                    int originalHeight = currentCoinImage.Height;

                    int scaledWidth = (int)(originalWidth * scaleFactor);
                    int scaledHeight = (int)(originalHeight * scaleFactor);

                    e.Graphics.DrawImage(currentCoinImage,
                        coin.xLoc - scaledWidth / 2 - cameraX, // Apply camera offset
                        coin.yLoc - scaledHeight / 2 - cameraY, // Apply camera offset
                        scaledWidth, scaledHeight);
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)//movement of the character
        {
            int Gap = 10;
            bool moved = false;

            if (e.KeyCode == Keys.A) { isMovingLeft = true; }
            if (e.KeyCode == Keys.D) { isMovingRight = true; }
            if (e.KeyCode == Keys.Space && isOnGround() && !isJumping)
            {
                verticalVelocity = jumpHeight;
                isJumping = true;
            }
            if (e.KeyCode == Keys.S)
            {
                isMovingDown = true;
                moved = true;
            }
            if (e.KeyCode == Keys.W)
            {
                isMovingUp = true;
                moved = true;
            }

            if (moved)
            {
                if (checkCollision())
                {
                    //if (e.KeyCode == Keys.A) x += Gap;
                    //if (e.KeyCode == Keys.D) x -= Gap;
                    //if (e.KeyCode == Keys.S) y -= Gap;
                   // if (e.KeyCode == Keys.W) y += Gap;
                }
                checkCoins();
                Main.Refresh();
            }
        }

        private Boolean checkCollision()// is an obstacle blocking the way
        {
            Boolean collision = false;
            RectangleF manBound = new RectangleF(x, y, charWidth, charHeight); 
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
            RectangleF manBound = new RectangleF(x, y, charWidth, charHeight);
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

        private bool isOnGround()
        {
            RectangleF manBound = new RectangleF(x, y + 1, charWidth, charHeight);
            if (manBound.IntersectsWith(groundBounds))
            {
                return true; // Keep only one return here
            }
            for (int i = 0; i < obstacles.Length; i++)
            {
                if (manBound.IntersectsWith(obstacles[i].bounds))
                {
                    return true;
                }
            }
            return false;
        }

    }
}
