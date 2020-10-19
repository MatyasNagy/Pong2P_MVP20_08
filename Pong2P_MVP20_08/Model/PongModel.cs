using Pong2P_MVP20_08.Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Pong2P_MVP20_08.Model
{
    public class PongModel : IPongModel
    {
        private readonly Timer timer = new Timer(1000);

        private int _stepIntervallInSeconds;
        public int StepIntervallInSeconds 
        { 
            get => _stepIntervallInSeconds;
            set
            {
                this._stepIntervallInSeconds = value;
                timer.Interval = value * 1000;
            }
        }

        public PongModel()
        {
            timer.Elapsed += Timer_Elapsed;
        }

        public void StartGame()
        {
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            throw new NotImplementedException();
        }

        int BallSpeed = 5;
        int BallAngle = 5;

        //Minimális változók a logika működéséhez
        public int Score { get; set; }

        private Point _ballPosition = new Point { X = 0, Y = 0 };
        public Point BallPosition 
        {
            get => _ballPosition; 
            set
            {
                var _ballPosition = "asdf";
                this._ballPosition = value;
                OnBallPositionChanged();
            }
        }
        public event EventHandler BallPositionChanged;
        protected virtual void OnBallPositionChanged()
        {
            if(BallPositionChanged!= null)
            {
                BallPositionChanged(this, EventArgs.Empty);
            }
        }

        public Point LeftRacketPosition { get; set; }
        public Point RightRacketPosition { get; set; }


        //TODO: remove the method and use the event
        public event EventHandler GameOverEvent;


        public string GameOverLabel_Text { get; set; }
        public bool GameOverLabel_Visible { get; set; }
        public bool timer_Enabled { get; set; }

        public int Ball_Left { get; set; }
        public int Ball_Top { get; set; }
        public int RacketLeft_Top { get; set; }
        public int RacketRight_Top { get; set; }
       

        public ConsoleKey segedKeyLe { get; set; }
        public ConsoleKey segedKeyFel { get; set; }
        public bool IsClosed { get; set; }
        int IPongModel.RacketRight_Left { get => RacketRight_Left; set => RacketRight_Left=value; }


        //beégetett értékek
        static int PlayGround_Left=0;
        static int PlayGround_Top = 0;
        static int PlayGround_Width= PlayGround_Left+1600;
        static int PlayGround_Bottom= PlayGround_Top+900;

        static int RacketLeft_Height = 150;
        static int RacketRight_Height = 150;
        static int RacketRight_Width = 20;
        static int RacketLeft_Width = 20;

        static int RacketLeft_Left= PlayGround_Left + 20;
        int RacketRight_Left = PlayGround_Width - (20 + RacketRight_Width);

        int RacketRight_Right=PlayGround_Width-20;

        int RacketLeft_Right = RacketLeft_Left + RacketLeft_Width;
        int Ball_Height = 20;
        int Ball_Width = 20;



        bool racketLeftUP = false;
        bool racketLeftDOWN = false;
        bool racketRightUP = false;
        bool racketRightDOWN = false;


        //Balls direction on the PlayGround
        bool ballDOWN = true;
        bool ballRIGHT = true;


        public bool ResetGame()
        {
            GameOverLabel_Visible = false;
            RacketLeft_Top = PlayGround_Bottom / 2 - RacketLeft_Height / 2;
            RacketRight_Left = PlayGround_Width - (20 + RacketRight_Width);
            RacketRight_Top = PlayGround_Bottom / 2 - RacketRight_Height / 2;
            BallStartPosition();
            timer_Enabled = true;
            BallSpeed = 5;
            BallAngle = 2;
            Score = 0;
            Scoring(0);
            return timer_Enabled;
          
        }

        private (int,int) BallStartPosition()
        {
            Random r = new Random();
            Ball_Left = PlayGround_Width / 2;
            Ball_Top = r.Next(0, PlayGround_Bottom);
            return (Ball_Left,Ball_Top);
        }

        public void KeyDown()
        {
            //
            // To much keys down at a sametime, it must recognize for the pressed buttons
            //


            if (segedKeyLe == ConsoleKey.Escape) { Close(); }
            if (segedKeyLe == ConsoleKey.F1) { ResetGame(); }

            if (segedKeyLe == ConsoleKey.Q) { racketLeftUP = true; }
            if (segedKeyLe == ConsoleKey.A) { racketLeftDOWN = true; }
            if (segedKeyLe == ConsoleKey.O) { racketRightUP = true; }
            if (segedKeyLe == ConsoleKey.L) { racketRightDOWN = true; }
        }

        private bool Close()
        {
            IsClosed = true;
            return IsClosed;
        }

        public void LeftRackatUp(){}
        public void LeftRackatDown() { }

        public void RightRackatUp() { }
        public void RightRackatDown() { }


        public void KeyUp()
        {
            if (segedKeyFel == ConsoleKey.Q) { racketLeftUP = false; }
            if (segedKeyFel == ConsoleKey.A) { racketLeftDOWN = false; }
            if (segedKeyFel == ConsoleKey.O) { racketRightUP = false; }
            if (segedKeyFel == ConsoleKey.L) { racketRightDOWN = false; }
        }

        

        public (int RacketLeft_Top, int RacketRight_Top) RocketsMove()
        {
            //
            // Separeted Method this move the rackets, not problem with multiple keys down
            //
            int RacketLeft_Bottom = RacketLeft_Top - RacketLeft_Height;
            int RacketRight_Bottom = RacketRight_Top - RacketRight_Height;

            if (racketLeftUP && RacketLeft_Top >= PlayGround_Top) { RacketLeft_Top -= 10; }
            if (racketLeftDOWN && RacketLeft_Bottom <= PlayGround_Bottom) { RacketLeft_Top += 10; }
            if (racketRightUP && RacketRight_Top >= PlayGround_Top) { RacketRight_Top -= 10; }
            if (racketRightDOWN && RacketRight_Bottom <= PlayGround_Bottom) { RacketRight_Top += 10; }

            return ( RacketLeft_Top,  RacketRight_Top);
        }



        public (int Ball_Left, int Ball_Top) BallMove()
        {
            //From ball position -> To ball direction
            int Ball_Bottom = Ball_Top + Ball_Height;
            int Ball_Right = Ball_Left + Ball_Width;
            int RacketRight_Bottom= RacketRight_Top+RacketRight_Height;
            int RacketLeft_Bottom = RacketLeft_Top + RacketLeft_Height;

            if (Ball_Top < PlayGround_Top) { ballDOWN = true; }
            if (Ball_Bottom > PlayGround_Bottom) { ballDOWN = false; }

            if (Ball_Left >= RacketLeft_Right && Ball_Right >= RacketRight_Left && Ball_Top >= RacketRight_Top && Ball_Bottom <= RacketRight_Bottom) { ballRIGHT = false; Scoring(1); CalculateBallAngle(ballRIGHT); }
            if (Ball_Right > RacketRight_Right) { GameOver(2); }
            if (Ball_Left <= RacketLeft_Right && Ball_Right <= RacketRight_Left && Ball_Top >= RacketLeft_Top && Ball_Bottom <= RacketLeft_Bottom) { ballRIGHT = true; Scoring(1); CalculateBallAngle(ballRIGHT); }
            if (Ball_Left < RacketLeft_Left) { GameOver(1); }



            //Ball move to a chosed direction.
            if (ballDOWN) { Ball_Top += BallAngle; }
            else { Ball_Top -= BallAngle; }
            if (ballRIGHT) { Ball_Left += BallSpeed; }
            else { Ball_Left -= BallSpeed; }

            return (Ball_Left, Ball_Top);



        }

        private void CalculateBallAngle(bool ballRIGHT)
        {

            if (ballRIGHT == true)
            {
                //Itt nem működik valamiért... :(
                int leftRacketPosition = RacketLeft_Top + (RacketLeft_Height / 2);
                int ballPosition = Ball_Top + (Ball_Height / 2);
                int calculatedAngle = (ballPosition - leftRacketPosition) / 15;
                if (calculatedAngle < 0)
                {
                    calculatedAngle = -calculatedAngle;
                    if (ballDOWN) { ballDOWN = false; BallAngle -= calculatedAngle; }
                    else BallAngle += calculatedAngle;//else { ballDOWN = true; }
                }
                else
                {
                    if (ballDOWN == false) { ballDOWN = true; BallAngle -= calculatedAngle; }
                    else BallAngle += calculatedAngle;
                }
                //BallAngle = calculatedAngle;
            }
            if (ballRIGHT == false)
            {

                int rightRacketPosition = RacketRight_Top + (RacketRight_Height / 2);
                int ballPosition = Ball_Top + (Ball_Height / 2);
                int calculatedAngle = (ballPosition - rightRacketPosition) / 15;
                if (calculatedAngle < 0)
                {
                    calculatedAngle = -calculatedAngle; if (ballDOWN) { ballDOWN = false; BallAngle -= calculatedAngle; }
                    else BallAngle += calculatedAngle;
                } //else { ballDOWN = true; } }
                else
                {
                    if (ballDOWN == false) { ballDOWN = true; BallAngle -= calculatedAngle; }
                    else BallAngle += calculatedAngle;
                }
                //BallAngle = calculatedAngle;
            }
            if (BallAngle <= 0) { BallAngle = 0; }
        }

        private void GameOver(int loser_playerID)
        {

            int PlayGround_Height = PlayGround_Bottom;

            if (loser_playerID == 2) {  GameOverLabel_Text = "GAME OVER\nWinner: Player1\nScore: " + Score.ToString() + "\nRestart: F1\nExit: Esc"; }
            if (loser_playerID == 1) {  GameOverLabel_Text = "GAME OVER\nWinner: Player2\nScore: " + Score.ToString() + "\nRestart: F1\nExit: Esc"; }

            
            GameOverLabel_Visible = true;
            timer_Enabled = false;

        }

        private void Scoring(int sco)
        {
            Score += sco;
            // changing ball speed
            if (Score % 5 == 0 && Score > 0)
            {
                BallSpeed += 2;
            }


        }
    }
}
