﻿using CrossPlatformDesktopProject.Libraries.Container;

namespace CrossPlatformDesktopProject.Libraries.Command
{
    //Author: Shyamal Shah
    class PauseGameCommand : ICommand
    {
        public PauseGameCommand()
        {

        }
        public void Execute()
        {
            GameStateMachine.Instance.Pause();
        }
    }
}