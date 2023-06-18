namespace ShootingGame
{
    public class EventManager
    {
        public static EventManager Instance => _instance ??= new EventManager();
        private static EventManager _instance;

        private EventManager() { }

        public delegate void OnLifeCountChanged(int currentValue);
        public event OnLifeCountChanged OnPlayerLifeChanged;
        public event OnLifeCountChanged OnEnemyLifeChanged;
        
        public void TriggerOnPlayerLifeChanged(int currentValue)
        {
            OnPlayerLifeChanged?.Invoke(currentValue);
        }
        
        public void TriggerOnEnemyLifeChanged(int currentValue)
        {
            OnEnemyLifeChanged?.Invoke(currentValue);
        }

        public delegate void OnEntityDead();
        public event OnEntityDead OnPlayerDead;
        public event OnEntityDead OnEnemyDead;

        public void TriggerOnPlayerDead()
        {
            OnPlayerDead?.Invoke();
        }

        public void TriggerOnEnemyDead()
        {
            OnEnemyDead?.Invoke();
        }
    }
}