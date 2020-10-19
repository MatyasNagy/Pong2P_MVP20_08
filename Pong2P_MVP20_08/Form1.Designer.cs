namespace Pong2P_MVP20_08
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
            this.PlayGround = new System.Windows.Forms.Panel();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.GameOverLabel = new System.Windows.Forms.Label();
            this.RacketLeft = new System.Windows.Forms.PictureBox();
            this.RacketRight = new System.Windows.Forms.PictureBox();
            this.Ball = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.PlayGround.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RacketLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RacketRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ball)).BeginInit();
            this.SuspendLayout();
            // 
            // PlayGround
            // 
            this.PlayGround.Controls.Add(this.scoreLabel);
            this.PlayGround.Controls.Add(this.GameOverLabel);
            this.PlayGround.Controls.Add(this.RacketLeft);
            this.PlayGround.Controls.Add(this.RacketRight);
            this.PlayGround.Controls.Add(this.Ball);
            this.PlayGround.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlayGround.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayGround.Location = new System.Drawing.Point(0, 0);
            this.PlayGround.Name = "PlayGround";
            this.PlayGround.Size = new System.Drawing.Size(1200, 600);
            this.PlayGround.TabIndex = 0;
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.ForeColor = System.Drawing.Color.White;
            this.scoreLabel.Location = new System.Drawing.Point(0, 0);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(40, 45);
            this.scoreLabel.TabIndex = 4;
            this.scoreLabel.Text = "0";
            // 
            // GameOverLabel
            // 
            this.GameOverLabel.AutoSize = true;
            this.GameOverLabel.ForeColor = System.Drawing.Color.Red;
            this.GameOverLabel.Location = new System.Drawing.Point(0, 0);
            this.GameOverLabel.Name = "GameOverLabel";
            this.GameOverLabel.Size = new System.Drawing.Size(186, 45);
            this.GameOverLabel.TabIndex = 3;
            this.GameOverLabel.Text = "Game Over";
            this.GameOverLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RacketLeft
            // 
            this.RacketLeft.BackColor = System.Drawing.Color.White;
            this.RacketLeft.Location = new System.Drawing.Point(82, 132);
            this.RacketLeft.Name = "RacketLeft";
            this.RacketLeft.Size = new System.Drawing.Size(20, 150);
            this.RacketLeft.TabIndex = 2;
            this.RacketLeft.TabStop = false;
            // 
            // RacketRight
            // 
            this.RacketRight.BackColor = System.Drawing.Color.White;
            this.RacketRight.Location = new System.Drawing.Point(713, 132);
            this.RacketRight.Name = "RacketRight";
            this.RacketRight.Size = new System.Drawing.Size(20, 150);
            this.RacketRight.TabIndex = 1;
            this.RacketRight.TabStop = false;
            // 
            // Ball
            // 
            this.Ball.BackColor = System.Drawing.Color.Red;
            this.Ball.Location = new System.Drawing.Point(399, 116);
            this.Ball.Name = "Ball";
            this.Ball.Size = new System.Drawing.Size(20, 20);
            this.Ball.TabIndex = 0;
            this.Ball.TabStop = false;
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowText;
            this.ClientSize = new System.Drawing.Size(1200, 600);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PlayGround);
            this.Name = "Form1";
            this.Text = "Pong 1v1";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.PlayGround.ResumeLayout(false);
            this.PlayGround.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RacketLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RacketRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ball)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PlayGround;
        private System.Windows.Forms.PictureBox RacketLeft;
        private System.Windows.Forms.PictureBox RacketRight;
        private System.Windows.Forms.PictureBox Ball;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label GameOverLabel;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Label label1;
    }
}

