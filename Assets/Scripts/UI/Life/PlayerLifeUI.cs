using TMPro;
using UnityEngine;

namespace ShootingGame.UI
{
    public class PlayerLifeUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _lifeText;
        
        private void Awake()
        {
            _lifeText.text = "x3"; // TODO: get it from common place
        }
        
        private void OnEnable()
        {
            EventManager.Instance.OnPlayerLifeChanged += OnLifeChanged;
        }

        private void OnDisable()
        {
            EventManager.Instance.OnPlayerLifeChanged -= OnLifeChanged;
        }

        private void OnLifeChanged(int currentValue)
        {
            _lifeText.text = $"x{currentValue}";
        }
    }
}