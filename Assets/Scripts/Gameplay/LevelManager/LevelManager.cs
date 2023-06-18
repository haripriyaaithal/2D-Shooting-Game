using ShootingGame.Pooling;
using ShootingGame.UI;
using UnityEngine;

namespace ShootingGame.Level
{
    public class LevelManager : ILevelManager
    {
        public static ILevelManager Instance => _instance ??= new LevelManager();
        private static ILevelManager _instance;
        
        private int _currentLevel = 1;
        private const int MaxLevel = 3;

        public int CurrentLevel => _currentLevel;
        
        private LevelManager() { }
        
        public void ResetProgress()
        {
            _currentLevel = 1;
            ObjectPooler.Instance.ClearPool();
        }

        public void OnLevelWin()
        {
            if (_currentLevel >= MaxLevel)
            {
                Debug.Log("Game Complete");
                UIManager.Instance.ChangePanel<GameWonPanel>();
                ResetProgress();
                return;
            }

            _currentLevel += 1;
            _currentLevel = Mathf.Clamp(_currentLevel, 1, MaxLevel);
            UIManager.Instance.ChangePanel<LevelCompletePanel>();
            Debug.Log($"Level complete. Next level: {_currentLevel}");
        }
    }
}