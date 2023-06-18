using ShootingGame.Life;
using ShootingGame.UI;

namespace ShootingGame.Player
{
	public class PlayerLifeSystem : LifeSystem
	{
		protected override void OnLifeUpdate()
		{
			base.OnLifeUpdate();
			EventManager.Instance.TriggerOnPlayerLifeChanged(_currentLifeCount);
		}

		protected override void TriggerEntityDead()
		{
			base.TriggerEntityDead();
			EventManager.Instance.TriggerOnPlayerDead();
			UIManager.Instance.ChangePanel<LevelFailPanel>();
		}
	}	
}
