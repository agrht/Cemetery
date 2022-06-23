using System;

namespace Script.Infrastructure
{
    public class GameLoopState :IState
    {
        public GameLoopState(GameStateMachine stateMachine){}
        public void Exit(object _curtain)
        {
            throw new NotImplementedException();
        }

        public void Enter()
        {
            throw new NotImplementedException();
        }
    }
}