namespace Flappy
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
            this.gamertimer = new System.Windows.Forms.Timer(this.components);
            this.flappyBird = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.flappyBird)).BeginInit();
            this.SuspendLayout();
            // 
            // gamertimer
            // 
            this.gamertimer.Enabled = true;
            this.gamertimer.Interval = 15;
            this.gamertimer.Tick += new System.EventHandler(this.Tick);
            // 
            // flappyBird
            // 
            this.flappyBird.Image = global::Flappy.Properties.Resources.bird;
            this.flappyBird.Location = new System.Drawing.Point(55, 144);
            this.flappyBird.Name = "flappyBird";
            this.flappyBird.Size = new System.Drawing.Size(83, 64);
            this.flappyBird.TabIndex = 0;
            this.flappyBird.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Turquoise;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1028, 600);
            this.Controls.Add(this.flappyBird);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.P);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Press);
            ((System.ComponentModel.ISupportInitialize)(this.flappyBird)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer gamertimer;
        private System.Windows.Forms.PictureBox flappyBird;
    }
}

