using ShootingGame.Level;
using ShootingGame.Life;

namespace ShootingGame.Enemy
{
    public class EnemyLifeSystem : LifeSystem
    {
        protected override void OnLifeUpdate()
        {
            base.OnLifeUpdate();
            EventManager.Instance.TriggerOnEnemyLifeChanged(_currentLifeCount);
        }

        protected override void TriggerEntityDead()
        {
            base.TriggerEntityDead();
            EventManager.Instance.TriggerOnEnemyDead();
            LevelManager.Instance.OnLevelWin();
            ResetLife();
            OnLifeUpdate();
        }
    }
}
