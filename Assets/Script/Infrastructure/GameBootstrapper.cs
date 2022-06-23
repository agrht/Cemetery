using System.Collections;
using UnityEngine;
using Script.Logic;

namespace Script.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        public LoadingCurtain Curtain;
        
        private Game _game;

        private void Awake()
        {
            _game = new Game(this, Curtain);
            _game.StateMachine.Enter<BootstrapState>();
            
            DontDestroyOnLoad(this);
        }

        public Coroutine startCoroutine(IEnumerator coroutine)
        {
            throw new System.NotImplementedException();
        }
    }
}
