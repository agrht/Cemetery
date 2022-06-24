using System.Collections.Generic;
using System;
using Script.Logic;

namespace Script.Infrastructure
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, IExcitableState> _states;
        private IExcitableState _activeState;

        public GameStateMachine(SceneLoader sceneLoader, LoadingCurtain curtain)
        {
            _states = new Dictionary<Type, IExcitableState>
            {
                [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader),
                [typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader, curtain),
                [typeof(GameLoopState)] = new GameLoopState(this),
            };
        }
        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }
        public void Enter<TState, TPayLoad>(TPayLoad payLoad) where TState : class,IPayLoadedIState<TPayLoad>, IExcitableState 
        {
            TState state = ChangeState<TState>();
            state.Enter<TPayLoad>();
        }
        private TState GetState<TState>() where TState : class, IExcitableState => 
            _states[typeof(TState)] as TState;
        private TState ChangeState<TState>() where TState : class, IExcitableState
        {
            _activeState?.Exit();
            TState state = GetState<TState>();
            _activeState = state;
            return state;
        }
    }
}