using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace GreyHoundLibrary
{
    class PlayState : IGamePlayState
    {
        public GamePlay gamePlayContext;
        public PlayState(GamePlay gamePlayContext)
        {
            this.gamePlayContext = gamePlayContext;
        }
        
        public void pause()
        {
            gamePlayContext.isPlaying = false;
            try
            {
                gamePlayContext.thread.Abort();
            }
            catch
            {

            }

            gamePlayContext.setState(gamePlayContext.stopedState);
            Debug.WriteLine("Gameplay paused");
        }

        public void play()
        {
            Debug.WriteLine("already in play state");
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

            }
            gamePlayContext.setInitStatus();
            gamePlayContext.setState(gamePlayContext.stopedState);
            Debug.WriteLine("Gameplay stoped");
        }
    }
}
