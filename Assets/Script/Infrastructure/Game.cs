using Script.Services.Input;
using Script.Services;

namespace Script.Infrastructure
{
    public class Game
    {
        public static IInputServices InputServices;
        public GameStateMachine StateMachine;
        public Game(ICoroutineRunner coroutineRunner)
        {
            StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), curtain);
        }
    }
}