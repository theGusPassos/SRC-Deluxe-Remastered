using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class BattleLevels : MonoBehaviour
    {
        [SerializeField] private Level[] levels;

        private int currentLevel = 0;

        public void GoToNextLevel()
        {
            currentLevel++;
        }

        public bool IsLastLevel() => currentLevel == levels.Length - 1;
    }

    public class Level
    {
    }
}
