using UnityEngine.InputSystem;

namespace ShootingGame.UI
{
	public class LevelCompletePanel : BasePanel
	{
		protected override void AddListeners()
		{
			base.AddListeners();
			inputSystem.UI.NextLevel.performed += OnNextLevelInput;
		}

		protected override void RemoveListeners()
		{
			base.RemoveListeners();
			inputSystem.UI.NextLevel.performed -= OnNextLevelInput;
		}

		private void OnNextLevelInput(InputAction.CallbackContext context)
		{
			UIManager.Instance.ChangePanel<GameplayPanel>(pauseGameplay: false);			
		}
	}
}