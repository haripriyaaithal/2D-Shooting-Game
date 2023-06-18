using UnityEngine;
using UnityEngine.UI;

namespace ShootingGame.UI
{
	public class EnemyLifeUI : MonoBehaviour
	{
		[SerializeField] private Slider _slider;

		private void OnEnable()
		{
			EventManager.Instance.OnEnemyLifeChanged += OnLifeChanged;
		}

		private void OnDisable()
		{
			EventManager.Instance.OnEnemyLifeChanged -= OnLifeChanged;
		}

		private void OnLifeChanged(int currentValue)
		{
			_slider.value = Mathf.Clamp(currentValue, _slider.minValue, _slider.maxValue);
		}
	}
    
}
