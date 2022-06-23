using Script.Logic;
using UnityEngine;
using static Script.Logic.LodingCurtain;

namespace Script.Infrastructure
{
    public class LoadLevelState: IPayloadedIState<string>, IExitableState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;

        public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader, LodingCurtain curtain)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter(string sceneName)
        { 
            LodingCurtain _curtain = null;//????
            _curtain.Show();
            _sceneLoader.Load(sceneName, () => OnLoaded("InitialPoint", "Assets/Resources/Hero/hero.prefab", "Assets/Graphics/Hud.prefab"));
        }

        public void Exit() => _curtain.Hide();

        public void Enter()
        {
            throw new System.NotImplementedException();
        }

        private void OnLoaded(string InitialpointTag, string HeroPath, string HudPath)
        {
            GameObject InitialPoint = GameObject.FindWithTag(InitialpointTag);
            GameObject hero = Instantiate(HeroPath,InitialPoint.transform.position);
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
            Camera.main
                .GetComponent<CameraFollow.CameraFollow>()
                .Follow(hero);
        }
    }
}