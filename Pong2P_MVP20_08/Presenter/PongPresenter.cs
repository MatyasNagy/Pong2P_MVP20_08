using Pong2P_MVP20_08.Model;
using Pong2P_MVP20_08.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong2P_MVP20_08.Presenter
{
    class PongPresenter
    {
        IPongModel pongModel;
        IPongView pongView;

        public string GameOverLabel_Text { get; set; }
        public int score { get; set; }


        public PongPresenter(IPongView pView, IPongModel pModel)
        {
            pongView = pView;
            pongModel = pModel;
            pongModel.BallPositionChanged += PongModel_BallPositionChanged;
            pView.GameStarted += PView_GameStarted;
        }

        private void PView_GameStarted(object sender, EventArgs e)
        {
            pongModel.StartGame();
        }

        private void PongModel_BallPositionChanged(object sender, EventArgs e)
        {

        }

        public void ConnectBetweenModelAndView()
        {

            pongModel.Ball_Left         = pongView.Ball_Left;
            pongModel.Ball_Top          = pongView.Ball_Top;
            pongModel.RacketLeft_Top    = pongView.RacketLeft_Top;
            pongModel.RacketRight_Top   = pongView.RacketRight_Top;
            pongModel.segedKeyFel       = pongView.segedKeyFel;
            pongModel.segedKeyLe        = pongView.segedKeyLe;

            pongModel.timer_Enabled     = pongView.timer_Enabled;


            pongView.RacketRight_Left = pongModel.RacketRight_Left;
            pongView.Is_Closed = pongModel.IsClosed;
            //pongView.RacketLeft_Left = pongModel.RacketLeft_Left;
      

        }

        public void RocketsMove()
        {
            pongView.RacketLeft_Top= pongModel.RocketsMove().RacketLeft_Top;
            pongView.RacketRight_Top = pongModel.RocketsMove().RacketRight_Top;
            pongView.timer_Enabled = pongModel.timer_Enabled;
        }

        public void BallMove()
        {
            pongView.Ball_Left = pongModel.BallMove().Ball_Left;
            pongView.Ball_Top = pongModel.BallMove().Ball_Top;
            pongView.GameOverLabel_Visible = pongModel.GameOverLabel_Visible;
            GameOverLabel_Text = pongModel.GameOverLabel_Text;
            score = pongModel.Score;

        }

        public void KeyDown()
        {
            pongModel.KeyDown();
            pongView.timer_Enabled = pongModel.timer_Enabled;
            if (pongModel.IsClosed)
            {
                pongView.Bezarni();
            }
        }



        public void KeyUp()
        {
            pongModel.KeyUp();
        }

        public bool ResetGame()
        {
            pongModel.ResetGame();
            pongView.Ball_Left = pongModel.Ball_Left;
            pongView.Ball_Top = pongModel.Ball_Top;
            return pongModel.ResetGame();
        }



    }
}
