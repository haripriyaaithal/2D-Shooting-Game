using UnityEngine;

namespace ShootingGame.UI
{
	public abstract class BasePanel : MonoBehaviour, IPanel
	{
		[SerializeField] private GameObject rootObject;

		protected InputSystem inputSystem;

		private void Awake()
		{
			ResolveDependencies();
		}

		private void ResolveDependencies()
		{
			inputSystem ??= new InputSystem();
		}

		public virtual void OpenPanel()
		{
			UpdateUI();
			AddListeners();
			rootObject.SetActive(true);
		}

		public virtual void ClosePanel()
		{
			RemoveListeners();
			rootObject.SetActive(false);
		}

		public virtual void UpdateUI()
		{
		}

		protected virtual void AddListeners()
		{
			ResolveDependencies();
			inputSystem.Enable();
		}

		protected virtual void RemoveListeners()
		{
			ResolveDependencies();
			inputSystem.Disable();
		}

		private void OnDestroy()
		{
			inputSystem = null;
		}
	}

	public interface IPanel
	{
		public void OpenPanel();
		public void ClosePanel();

		public void UpdateUI();
	}
}