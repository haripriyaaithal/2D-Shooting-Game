using ShootingGame.Level;
using ShootingGame.Player;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ShootingGame.UI
{
	public class LevelFailPanel : BasePanel
	{
		[SerializeField] private Button _restartButton;

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

		private void OnClickRestart()
		{
			var activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
			SceneManager.LoadScene(activeSceneIndex);
			BulletFiredCounter.Instance.Reset();
			LevelManager.Instance.ResetProgress();
		}
	}
}