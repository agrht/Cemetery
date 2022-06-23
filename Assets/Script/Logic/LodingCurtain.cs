using System.Collections;
using UnityEngine;

namespace Script.Logic
{
    public class LodingCurtain:MonoBehaviour
    {
        public CanvasGroup Curtain;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public void Show()
        {
            gameObject.SetActive(true);
            Curtain.alpha = 1;
        }

        public void Hide() =>
            StatrCoroutine(FadeIn());

        private void StatrCoroutine(IEnumerator fadeIn)
        {
            throw new System.NotImplementedException();
        }

        private IEnumerator FadeIn()
        {
            while (Curtain.alpha > 0)
            {
                Curtain.alpha -= 0.03f;
                yield return new WaitForSeconds(0.03f);
            }
            
            gameObject.SetActive(false);
        }

    }
}