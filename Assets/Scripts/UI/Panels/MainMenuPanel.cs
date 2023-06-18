using UnityEngine;
using UnityEngine.InputSystem;

namespace ShootingGame.UI
{
	public class MainMenuPanel : BasePanel
	{
		private void Awake()
		{
			Time.timeScale = 0;
		}

		private void OnEnable()
		{
			AddListeners();
		}

		protected override void AddListeners()
		{
			base.AddListeners();
			inputSystem.UI.StartGame.performed += OnStartGame;
		}

		protected override void RemoveListeners()
		{
			base.RemoveListeners();
			inputSystem.UI.StartGame.performed -= OnStartGame;
		}

		private void OnStartGame(InputAction.CallbackContext obj)
		{
			 UIManager.Instance.ChangePanel<GameplayPanel>(pauseGameplay: false);
		}
	}
}