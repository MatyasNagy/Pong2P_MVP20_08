using Pong2P_MVP20_08.Model;
using Pong2P_MVP20_08.Presenter;
using Pong2P_MVP20_08.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Proba

namespace Pong2P_MVP20_08
{
    public partial class Form1 : Form, IPongView
    {
        ConsoleKey segedKeyLeA, segedKeyFelA;


        PongPresenter pongPresenter;



        public bool Isclosed=false;
        public bool Is_Closed { set => Isclosed=value; }
        public int Ball_Left { get => Ball.Left; set => Ball.Left=value; }
        public int Ball_Top { get => Ball.Top; set => Ball.Top=value; }
        public int RacketLeft_Top { get => RacketLeft.Top; set => RacketLeft.Top = value; }
        public int RacketRight_Top { get => RacketRight.Top; set => RacketRight.Top=value; }

        public bool GameOverLabel_Visible { get => GameOverLabel.Visible; set => GameOverLabel.Visible=value; }
        public bool timer_Enabled { get => timer.Enabled; set => timer.Enabled=value; }
        public ConsoleKey segedKeyLe { get => segedKeyLeA; set => segedKeyLeA = value; }
        public ConsoleKey segedKeyFel { get => segedKeyFelA; set => segedKeyFelA = value; }
        public int RacketRight_Left { get => RacketRight.Left; set => RacketRight.Left=value; }


        bool timerACTION;

        public event EventHandler GameStarted;
        protected void OnGameStarted()
        {
            if(GameStarted != null)
            {
                GameStarted(this, EventArgs.Empty);
            }
        }

        public Form1()
        {
            InitializeComponent();

            Cursor.Hide();
            FormBorderStyle = FormBorderStyle.None;
            //TopMost = true;
            Bounds = Screen.PrimaryScreen.Bounds;

            GameOverLabel.Left = (PlayGround.Width / 2) - (GameOverLabel.Width / 2);
            GameOverLabel.Top = (PlayGround.Height / 2) - (GameOverLabel.Height / 2);
            GameOverLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            scoreLabel.Left = (PlayGround.Width / 2) - (scoreLabel.Width / 2);
            RacketLeft.Left = 40;



            pongPresenter = new PongPresenter(this, new PongModel());
            pongPresenter.ConnectBetweenModelAndView();
            timerACTION = pongPresenter.ResetGame();
            timer.Enabled = timerACTION;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Interval = 10;
            pongPresenter.RocketsMove();
            pongPresenter.BallMove();
            GameOverLabel.Text = pongPresenter.GameOverLabel_Text;
            scoreLabel.Text = "Score: " + pongPresenter.score.ToString();

        }

        public void Bezarni()
        {
            Close();
        }



        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F1)
            {
                OnGameStarted();
            }
            //
            // To much keys down at a sametime, it must recognize for the pressed buttons
            //
            segedKeyLeA = (ConsoleKey)e.KeyCode;
            pongPresenter.ConnectBetweenModelAndView();
            pongPresenter.KeyDown();
 

        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            OnGameStarted();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            segedKeyFelA = (ConsoleKey)e.KeyCode;
            pongPresenter.ConnectBetweenModelAndView();
            pongPresenter.KeyUp();
            
        }


    }
}
