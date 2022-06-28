using System.Collections;
using System;
using UnityEngine;
using Script.Logic;
using UnityEngine.Serialization;
using UnityEngine.SceneManagement;

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
       
    }
    public interface ICoroutineRunner
    {
        // ReSharper disable once UnusedMethodReturnValue.Global
        Coroutine  StartCoroutine(IEnumerator coroutine);
    }
}
