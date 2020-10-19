using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong2P_MVP20_08.View
{
    interface IPongView
    {
        event EventHandler GameStarted;

        //int RacketLeft_Left { get; set; }
        bool Is_Closed { set; }
        int Ball_Left { get; set; }
        int Ball_Top { get; set; }
        int RacketLeft_Top { get; set; }
        int RacketRight_Top { get; set; }
        int RacketRight_Left { get; set; }
        bool GameOverLabel_Visible { get; set; }
        bool timer_Enabled { get; set; }
        ConsoleKey segedKeyLe { get; set; }
        ConsoleKey segedKeyFel {  get; set;}
        void Bezarni();






    }
}
