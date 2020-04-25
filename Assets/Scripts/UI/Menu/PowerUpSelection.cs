using Assets.Scripts.Scenes;
using UnityEngine;

namespace Assets.Scripts.UI.Menu
{
    public class PowerUpSelection : BaseMenu
    {
        [SerializeField] private SceneLoader sceneLoader;

        protected override void OnOptionSelected()
        {
            sceneLoader.LoadScene("SampleScene");
        }
    }
}
