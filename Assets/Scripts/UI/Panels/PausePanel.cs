using UnityEngine.InputSystem;

namespace ShootingGame.UI
{
	public class PausePanel : BasePanel
	{
		protected override void AddListeners()
		{
			base.AddListeners();
			inputSystem.UI.Pause.performed += OnUnpaused;
		}

		protected override void RemoveListeners()
		{
			base.RemoveListeners();
			inputSystem.UI.Pause.performed -= OnUnpaused;
		}

		private void OnUnpaused(InputAction.CallbackContext context)
		{
			UIManager.Instance.ChangePanel<GameplayPanel>(pauseGameplay: false);
		}
	}
}