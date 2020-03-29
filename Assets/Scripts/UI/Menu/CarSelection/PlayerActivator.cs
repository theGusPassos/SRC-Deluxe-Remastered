using UnityEngine;

namespace Assets.Scripts.UI.Menu.CarSelection
{
    public class PlayerActivator : MonoBehaviour
    {
        [SerializeField] private GameObject outOfGame;
        [SerializeField] private GameObject inGame;

        public void ActivatePlayer()
        {
            outOfGame.SetActive(false);
            inGame.SetActive(true);
        }
    }
}
