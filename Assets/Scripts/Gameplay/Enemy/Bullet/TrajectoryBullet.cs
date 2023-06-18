using System.Collections;
using UnityEngine;

namespace ShootingGame.Enemy.Bullet
{
	public class TrajectoryBullet : EnemyBullet<TrajectoryBullet>
	{
		private WaitForFixedUpdate _waitForFixedUpdate;
		private Coroutine _coroutine;
		private float _elapsedTime = 0f;
		private float _duration = 1f;
		
		public override void Shoot()
		{
			base.Shoot();
			_waitForFixedUpdate ??= new WaitForFixedUpdate();

			_coroutine = StartCoroutine(ShootInTrajectory());
		}

		private IEnumerator ShootInTrajectory()
		{
			var playerPosition = _playerTransform.position;
			var curvePoint = playerPosition.y > _enemyTransform.position.y
				? Vector2.up * 20f
				: Vector2.down * 20f;

			while (Vector3.Distance(playerPosition, transform.position) >= 0.1f)
			{
				_elapsedTime += Time.fixedDeltaTime;
				var t = Mathf.Clamp01(_elapsedTime / _duration);

				var curvePosition = CatmullRomCurve(_enemyTransform.position, curvePoint, playerPosition, t);
				var velocity = (curvePosition - transform.position);

				_rigidbody.velocity = velocity.normalized * _bulletSpeed;

				yield return _waitForFixedUpdate;
			}
		}

		private Vector3 CatmullRomCurve(Vector3 p0, Vector3 p1, Vector3 p2, float t)
		{
			var t2 = t * t;
			var t3 = t2 * t;

			var v0 = p1 * (0.5f * 2f);
			var v1 = 0.5f * (p2 - p0);
			var v2 = 0.5f * (2f * p0 - 5f * p1 + 4f * p2 - p2);
			var v3 = 0.5f * (-p0 + 3f * p1 - 3f * p2 + p2);

			return v3 * t3 + v2 * t2 + v1 * t + v0;
		}

		protected override void ReturnToPool()
		{
			if (_coroutine is not null)
				StopCoroutine(_coroutine);
			Destroy(gameObject);
		}
	}
}