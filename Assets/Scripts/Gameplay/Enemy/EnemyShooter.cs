using System.Collections;
using ShootingGame.Enemy.Bullet;
using ShootingGame.Level;
using ShootingGame.Pooling;
using UnityEngine;

namespace ShootingGame.Enemy
{
	public class EnemyShooter : MonoBehaviour
	{
		[SerializeField] private EnemyLifeSystem _enemyLifeSystem;		
		[SerializeField] private EnemyBulletData _enemyBulletData;
		[SerializeField, Min(0)] private float _shootDelay;

		private WaitForSeconds _waitForSeconds;
		
		private void Start()
		{
			_waitForSeconds = new WaitForSeconds(_shootDelay);
			StartCoroutine(Shoot());
		}

		private IEnumerator Shoot()
		{
			yield return _waitForSeconds;

			var level = LevelManager.Instance.CurrentLevel;
			var bulletPrefab = _enemyBulletData.GetBullet(level, _enemyLifeSystem.CurrentLifeCount);
			var key = bulletPrefab.GetComponent<IBullet>().GetType();
			var instance = ObjectPooler.Instance.Get(key, bulletPrefab);
			instance.transform.position = transform.position;
			if (instance.TryGetComponent<IBullet>(out var bullet))
				bullet.Shoot();

			StartCoroutine(Shoot());
		}
	}   
}
