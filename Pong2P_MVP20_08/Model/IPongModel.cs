using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong2P_MVP20_08.Model
{
    interface IPongModel
    {
        string GameOverLabel_Text { get; set; }
        int Score { get; set; }
        bool GameOverLabel_Visible { get; set; }
        bool timer_Enabled { get; set; }
        bool IsClosed { get; set; }

        int Ball_Left { get; set; }
        int Ball_Top { get; set; }
        int RacketLeft_Top { get; set; }
        int RacketRight_Top { get; set; }
        int RacketRight_Left   { get; set; }
        //int RacketLeft_Left { get; set; }

        ConsoleKey segedKeyLe { get; set; }
        ConsoleKey segedKeyFel { get; set; }

        (int RacketLeft_Top, int RacketRight_Top) RocketsMove();
        (int Ball_Left, int Ball_Top) BallMove();
        bool ResetGame();
        void KeyDown();
        void KeyUp();

        Point BallPosition { get; set; }
        event EventHandler BallPositionChanged;

        void StartGame();
        void LeftRackatUp();
        void LeftRackatDown();

        void RightRackatUp();
        void RightRackatDown();
    }
}
