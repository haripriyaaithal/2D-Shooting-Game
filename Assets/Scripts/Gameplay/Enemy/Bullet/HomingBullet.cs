using System.Collections;
using ShootingGame.Player;
using UnityEngine;

namespace ShootingGame.Enemy.Bullet
{
	public class HomingBullet : EnemyBullet<HomingBullet>
	{
		private WaitForFixedUpdate _waitForFixedUpdate;
		private Coroutine _trackingCoroutine;
		
		public override void Shoot()
		{
			base.Shoot();
			_waitForFixedUpdate ??= new WaitForFixedUpdate();
			_trackingCoroutine = StartCoroutine(TrackPlayer());
		}

		private IEnumerator TrackPlayer()
		{
			while (true)
			{
				yield return _waitForFixedUpdate;
			
				var myTransform = transform;
				var velocity = (_playerTransform.position - myTransform.position).normalized * _bulletSpeed;
				_rigidbody.velocity = velocity;
				myTransform.LookAt(_playerTransform);
            
				var newRotation = myTransform.rotation;
				newRotation.y = 0;
				myTransform.rotation = newRotation;	
			}
		}

		protected override void ReturnToPool()
		{
			base.ReturnToPool();
			if (_trackingCoroutine is not null)
				StopCoroutine(_trackingCoroutine);
		}

		private void OnCollisionEnter2D(Collision2D other)
		{
			if (!other.gameObject.CompareTag("PlayerBullet"))
				return;
			
			if (other.gameObject.TryGetComponent<PlayerBullet>(out var playerBullet))
				playerBullet.OnCollisionWithBullet();
			
			ReturnToPool();
		}
	}
}