using Script.Logic;
using Script.Services.Input;

namespace Script.Infrastructure
{
    public class Game
    {
        public static IInputServices InputServices;
        public readonly GameStateMachine StateMachine;
        public Game(ICoroutineRunner coroutineRunner, LoadingCurtain curtain)
        {
            StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), curtain);
        }
    }
}