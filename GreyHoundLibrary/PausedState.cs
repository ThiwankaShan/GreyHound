using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace GreyHoundLibrary
{
    class PausedState : IGamePlayState
    {
        public GamePlay gamePlayContext;
        public PausedState(GamePlay gamePlayContext)
        {
            this.gamePlayContext = gamePlayContext;
        }

        public void pause()
        {
            Debug.WriteLine("already in paused state");
        }

        public void play()
        {
            gamePlayContext.isPlaying = true;
            gamePlayContext.thread = new Thread(gamePlayContext.start);
            gamePlayContext.thread.Start();
            gamePlayContext.setState(gamePlayContext.playState);
            Debug.WriteLine("Gameplay started");
        }

        public void stop()
        {
            gamePlayContext.isPlaying = false;
            try
            {
                gamePlayContext.thread.Abort();
            }
            catch
            {
                Debug.WriteLine("Couldnt stop thread");
            }
            gamePlayContext.setInitStatus();
            gamePlayContext.setState(gamePlayContext.stopedState);
            Debug.WriteLine("Gameplay stoped");
        }
    }
}
