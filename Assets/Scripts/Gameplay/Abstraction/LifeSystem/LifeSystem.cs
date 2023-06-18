using UnityEngine;

namespace ShootingGame.Life
{
	public abstract class LifeSystem : MonoBehaviour, ILifeSystem
	{
		[SerializeField, Min(1)] protected int _maxLifeCount;

		protected int _currentLifeCount;

		private void Awake()
		{
			ResetLife();
		}

		public int CurrentLifeCount => _currentLifeCount;

		public virtual void ReduceLife(int amount = 1)
		{
			_currentLifeCount -= amount;

			OnLifeUpdate();
			
			if (_currentLifeCount <= 0)
				TriggerEntityDead();
		}

		protected void ResetLife()
		{
			_currentLifeCount = _maxLifeCount;
		}

		protected virtual void TriggerEntityDead()
		{
			
		}

		protected virtual void OnLifeUpdate()
		{
			
		}
	}   
}
