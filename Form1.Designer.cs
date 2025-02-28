namespace Tiny_Top_Adventure
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Main = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Cointxt = new System.Windows.Forms.Label();
            this.Coins_label = new System.Windows.Forms.Label();
            this.coinTimer = new System.Windows.Forms.Timer(this.components);
            this.rightMoveTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Main
            // 
            this.Main.BackgroundImage = global::Tiny_Top_Adventure.Properties.Resources.background;
            this.Main.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Main.Location = new System.Drawing.Point(474, 18);
            this.Main.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Main.Name = "Main";
            this.Main.Size = new System.Drawing.Size(1356, 979);
            this.Main.TabIndex = 0;
            this.Main.TabStop = false;
            this.Main.Paint += new System.Windows.Forms.PaintEventHandler(this.Main_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.LightBlue;
            this.pictureBox1.Location = new System.Drawing.Point(18, 18);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(440, 980);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // Cointxt
            // 
            this.Cointxt.AutoSize = true;
            this.Cointxt.BackColor = System.Drawing.Color.LightCyan;
            this.Cointxt.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cointxt.Location = new System.Drawing.Point(62, 165);
            this.Cointxt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Cointxt.Name = "Cointxt";
            this.Cointxt.Size = new System.Drawing.Size(110, 51);
            this.Cointxt.TabIndex = 2;
            this.Cointxt.Text = "Coins";
            // 
            // Coins_label
            // 
            this.Coins_label.BackColor = System.Drawing.Color.LightCyan;
            this.Coins_label.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Coins_label.Location = new System.Drawing.Point(222, 165);
            this.Coins_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Coins_label.Name = "Coins_label";
            this.Coins_label.Size = new System.Drawing.Size(111, 51);
            this.Coins_label.TabIndex = 3;
            // 
            // coinTimer
            // 
            this.coinTimer.Enabled = true;
            this.coinTimer.Tick += new System.EventHandler(this.coinTimer_Tick);
            // 
            // rightMoveTimer
            // 
            this.rightMoveTimer.Tick += new System.EventHandler(this.rightMoveTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1858, 1029);
            this.Controls.Add(this.Coins_label);
            this.Controls.Add(this.Cointxt);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Main);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.Main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Main;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label Cointxt;
        private System.Windows.Forms.Label Coins_label;
        private System.Windows.Forms.Timer coinTimer;
        private System.Windows.Forms.Timer rightMoveTimer;
        private System.Windows.Forms.Timer movementTimer;
    }
}

