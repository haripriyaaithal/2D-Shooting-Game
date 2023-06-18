using ShootingGame.Level;
using ShootingGame.Player;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ShootingGame.UI
{
	public class GameWonPanel : BasePanel
	{
		[SerializeField] private Button _restartButton;
		[SerializeField] private TextMeshProUGUI _bulletsFiredText;
		
		protected override void AddListeners()
		{
			base.AddListeners();
			_restartButton.onClick.AddListener(OnClickRestart);
		}

		protected override void RemoveListeners()
		{
			base.RemoveListeners();
			_restartButton.onClick.RemoveListener(OnClickRestart);
		}

		public override void UpdateUI()
		{
			base.UpdateUI();
			var bulletsFired = BulletFiredCounter.Instance.BulletsFired;
			_bulletsFiredText.text = $"Number of bullets fired: {bulletsFired}";
		}

		private void OnClickRestart()
		{
			var activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
			SceneManager.LoadScene(activeSceneIndex);
			BulletFiredCounter.Instance.Reset();
			LevelManager.Instance.ResetProgress();
		}
	}
}