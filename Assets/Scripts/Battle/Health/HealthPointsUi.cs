using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Battle.Health
{
    public class HealthPointsUi : MonoBehaviour
    {
        private Slider slider;

        [SerializeField] private float sliderSpeed;
        private float nextValue;
        private bool isChangingHealth = false;

        private void Awake()
        {
            slider = GetComponentInChildren<Slider>();
            slider.value = slider.maxValue;
        }

        public void SetHpPercentage(float healthPercentage)
        {
            nextValue = healthPercentage;
            isChangingHealth = true;
        }

        private void Update()
        {
            if (isChangingHealth) ChangeHealth();
        }

        private void ChangeHealth()
        {
            slider.value = Mathf.Lerp(slider.value, nextValue, sliderSpeed);
            
            if (slider.value == nextValue)
            {
                isChangingHealth = false;
            }
        }
    }
}
