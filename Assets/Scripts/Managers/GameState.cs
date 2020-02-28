using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class GameState : MonoBehaviour
    {
        private State gameState = State.START_SCREEN;
    }

    public enum State
    {
        START_SCREEN,
        SELECTING_GAME_MODE,
        IN_GAME
    }
}
