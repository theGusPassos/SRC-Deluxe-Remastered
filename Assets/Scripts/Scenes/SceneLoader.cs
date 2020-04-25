using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Scenes
{
    public class SceneLoader : MonoBehaviour
    {
        public void LoadScene(string scene)
        {
            StartCoroutine(LoadSceneAsync(scene));
        }

        private IEnumerator LoadSceneAsync(string scene)
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);
            while (!asyncLoad.isDone)
            {
                yield return null;
            }
        }
    }
}
