using System.Collections.Generic;
using System;


namespace Script.Infrastructure
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, IExitableState> _states;
        private IExitableState _activeState;

        public GameStateMachine(SceneLoader sceneLoader)
        {
            _states = new Dictionary<Type, IExitableState>
            {
                [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader),
                [typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader, curtain),
                [typeof(GameLoopState)] = new GameLoopState(this),
            };
        }
        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _activeState?.Exit();
            TState state = GetState<TState>();
            _activeState = state;

            return state;
        }
        
        public void Enter<TState>() where TState : class,IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        private TState GetState<TState>() where TState : class,IExitableState => 
            _states[typeof(TState)] as TState;

        public void Enter<TState, TPayLoad>(TPayLoad payLoad) where TState : class,IPayloadedIState<TPayLoad>, IExitableState
        {
            TState state = ChangeState<TState>();
            state.Enter(payLoad);
        }
    }

    public interface IPayloadedIState<T>
    {
    }
}