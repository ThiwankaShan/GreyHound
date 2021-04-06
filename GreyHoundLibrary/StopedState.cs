using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace GreyHoundLibrary
{
    public class StopedState : IGamePlayState
    {
        public GamePlay gamePlayContext;
        public StopedState(GamePlay gamePlayContext)
        {
            this.gamePlayContext = gamePlayContext;
        }
        
        public void pause()
        {
            Debug.WriteLine("cannot go to pause state from stoped state");
        }

        public void play()
        {
            gamePlayContext.setInitStatus();
            gamePlayContext.isPlaying = true;
            gamePlayContext.thread = new Thread(gamePlayContext.start);
            gamePlayContext.thread.Start();
            gamePlayContext.setState(gamePlayContext.playState);
            Debug.WriteLine("Gameplay started");
        }

        public void stop()
        {
            Debug.WriteLine("already in stoped state");
        }
    }
}
