using UnityEngine;

namespace Assets.Scripts.Utilities
{
    public class StopParticleSystem : MonoBehaviour
    {
        private void Awake()
        {
            GetComponent<ParticleSystem>().Stop();
        }
    }
}
