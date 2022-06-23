using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using System.Collections;

namespace Script.Infrastructure
{
    public class SceneLoader
    {
        private readonly ICoroutineRunner _coroutineRunner;
        
        public SceneLoader(ICoroutineRunner coroutineRunner) => 
            _coroutineRunner = coroutineRunner;

        public void Load(string name, Action onLoaded = null) =>
            _coroutineRunner.startCoroutine(LoadScene(name, onLoaded));
        public IEnumerator LoadScene(string nextScene, Action onLoaded = null)
        {
            if (SceneManager.GetActiveScene().name == nextScene)
            {
                onLoaded?.Invoke();
                yield break;
            }
            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(nextScene);
            while (!waitNextScene.isDone)
                yield return null;
            onLoaded?.Invoke();
        }

        public void Load()
        {
        }
    }
}