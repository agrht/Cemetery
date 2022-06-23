using Script.Services.Input;
using UnityEngine;


namespace Script.Infrastructure
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private SceneLoader _sceneLoader;
        private string Initial;

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            RegisterServices();
            Initial = "Initial";
            _sceneLoader.Load(Initial,EnterLoadLevel);
        }

        private void EnterLoadLevel() => _stateMachine.Enter<LoadLevelState, string>("simple_scene2");

        private void RegisterServices()
        {
            Game.InputServices = RegisterInputServices();
        }

        private static IInputServices RegisterInputServices()
        {
            if (Application.isEditor)
                return new StandaloneInputService(/*VirtualInputsPlugin.Instance*/);
            else
                return new MobileInputService();
        }

        public void Exit( _curtain)
        {
            throw new System.NotImplementedException();
        }
    }
}