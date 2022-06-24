using System.Collections;
using UnityEngine;
using Script.Logic;
using UnityEngine.Serialization;

namespace Script.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        [FormerlySerializedAs("Curtain")] public LoadingCurtain curtain;
        
        private Game _game;

        private void Awake()
        {
            _game = new Game(this, curtain);
            _game.StateMachine.Enter<BootstrapState>();
            
            DontDestroyOnLoad(this);
        }
        public new Coroutine StartCoroutine(IEnumerator coroutine)
        {
            throw new System.NotImplementedException();
        }
    }
}
