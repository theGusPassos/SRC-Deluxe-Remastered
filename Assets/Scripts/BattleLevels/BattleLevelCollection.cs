using UnityEngine;

namespace Assets.Scripts.BattleLevels
{
    public class BattleLevelCollection : MonoBehaviour
    {
        [SerializeField] private BattleLevel[] battleLevels;
        private int currentLevel = 0;

        public void GoToFirstLevel() => currentLevel = 0;

        public void GoToNextLevel()
        {
            currentLevel++;
        }

        public string GetCurrentLevelScene() => battleLevels[currentLevel].sceneName;

        public bool IsInLastLevel() => currentLevel >= battleLevels.Length;
    }

    [System.Serializable]
    public struct BattleLevel
    {
        [SerializeField] public string sceneName;
    }
}
