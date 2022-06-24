using Script.Services.Input;
using UnityEngine;

namespace Script.Infrastructure
{
    public class BootstrapState : IState
    {
        private const string Initial = "Initial";
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            RegisterServices();
            _sceneLoader.Load(Initial, onLoaded: EnterLoadLevel);
           // _sceneLoader.Load("Main");
        }

        public void Exit()
        {
        }

        private void EnterLoadLevel() => _stateMachine.Enter<LoadLevelState, string>("Scenes/Main");
        private void RegisterServices()
        {
            Game.InputServices = RegisterInputServices();
        }
        private static IInputServices RegisterInputServices()
        {
            if (Application.isEditor)
                return new StandaloneInputService(/*VirtualInputsPlugin.Instance*/);
            else
                return new MobileInputService(/*VirtualInputsPlugin.Instance*/);
        }
    }
}