using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ShootingGame.UI
{
	public class UIManager : MonoBehaviour
	{
		[SerializeField] private List<BasePanel> _uiPanels;

		public static UIManager Instance { get; private set; }
		
		private Type _currentPanel = typeof(MainMenuPanel);
		private Type _previousPanel;
		
		private Dictionary<Type, BasePanel> _uiPanelDictionary;
		
		private void Awake()
		{
			Instance = this;
			
			_uiPanelDictionary = _uiPanels.ToDictionary(panel => panel.GetType(), panel => panel);
			_uiPanels.Clear();
			_uiPanels = null;
		}

		private void OnDestroy()
		{
			_uiPanelDictionary?.Clear();
		}

		public void ChangePanel<T>(bool pauseGameplay = true) where T : BasePanel
		{
			ChangePanel(typeof(T));
			Time.timeScale = pauseGameplay 
				? 0 
				: 1;
		}
		
		private void ChangePanel(Type type)
		{
			if (type == typeof(PausePanel) && _currentPanel == typeof(PausePanel))
				_currentPanel = _previousPanel;
			else
				_currentPanel = type;
			
			foreach (var key in _uiPanelDictionary.Keys)
				_uiPanelDictionary[key].ClosePanel();

			_uiPanelDictionary[_currentPanel].OpenPanel();
		}
	}	
}