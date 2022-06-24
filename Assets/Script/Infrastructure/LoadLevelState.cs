using Script.Logic;
using UnityEngine;

namespace Script.Infrastructure
{
    public class LoadLevelState: IState, IPayLoadedIState<string>, IExcitableState
    {
        private const string InitialPointTag = "InitialPoint";
        private const string HeroPath = "Hero/hero";
        private const string HudPath = "Graphics/Hud";
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _curtain;

        public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader, LoadingCurtain curtain)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _curtain = curtain;
        }
        public void Enter(string sceneName)
        { 
            _curtain.Show();
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit() => _curtain.Hide();

        public void Enter()
        {
        }

        private void OnLoaded( )
        {
            GameObject initialPoint = GameObject.FindWithTag(InitialPointTag);
            GameObject hero = Instantiate(LoadLevelState.HeroPath,at: initialPoint.transform.position);
            Instantiate(HudPath);
            
            CameraFollow(hero);
            
            _stateMachine.Enter<GameLoopState>();
        }

        private static GameObject Instantiate(string path)
        {
            var prefab = Resources.Load<GameObject>(path);
            return  Object.Instantiate(prefab);
        }
        
        private static GameObject Instantiate(string path, Vector3 at)
        {
            var prefab = Resources.Load<GameObject>(path);
            return  Object.Instantiate(prefab,at,Quaternion.identity);
        }
        private void CameraFollow(GameObject hero)
        {
            if (Camera.main != null)
                Camera.main
                    .GetComponent<CameraFollow.CameraFollow>()
                    .Follow(hero);
        }

        public void Enter<TPayLoad>()
        {
            
        }
    }
}