using Script.Logic;
using UnityEngine;

namespace Script.Infrastructure
{
    public class LoadLevelState: IPayLoadedIState<string>
    {
        private const string InitialPointTag = "InitialPoint";
        private const string HeroPath = "Hero/Hero";
        private const string HudPath = "Hud/Hud";
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

        public void Exit() =>
            _curtain.Hide();

        private void OnLoaded()
        {
            GameObject initialPoint = GameObject.FindWithTag(InitialPointTag);
            GameObject hero = Instantiate(HeroPath,at: initialPoint.transform.position);
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
        private static void CameraFollow(GameObject hero)
        {
            Camera.main
                    .GetComponent<CameraFollow.CameraFollow>()
                    .Follow(hero);
        }
    }
}