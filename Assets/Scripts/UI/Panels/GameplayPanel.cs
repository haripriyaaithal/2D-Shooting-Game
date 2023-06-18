using UnityEngine.InputSystem;

namespace ShootingGame.UI
{
    public class GameplayPanel : BasePanel
    {
        protected override void AddListeners()
        {
            base.AddListeners();
            inputSystem.UI.Pause.performed += OnPaused;
        }

        protected override void RemoveListeners()
        {
            base.RemoveListeners();
            inputSystem.UI.Pause.performed -= OnPaused;
        }
        
        private void OnPaused(InputAction.CallbackContext obj)
        {
            UIManager.Instance.ChangePanel<PausePanel>();
        }
    }
}