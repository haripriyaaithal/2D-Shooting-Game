using ShootingGame.Pooling;
using UnityEngine;

namespace ShootingGame
{
	public abstract class Bullet<T> : MonoBehaviour, IBullet
	{
		[SerializeField] protected Rigidbody2D _rigidbody;
		[SerializeField] protected float _bulletSpeed = 10;

		protected float _minX;
		protected float _maxX;
		
		protected virtual void Awake()
		{
			var screenBounds = ScreenBoundsCalculator.Instance.GetScreenBounds();
			_minX = -screenBounds.x;
			_maxX = screenBounds.x;
		}
		
		protected virtual void FixedUpdate()
		{
			var position = _rigidbody.position;
			if (position.x <= _minX || position.x >= _maxX)
				ReturnToPool();
		}

		protected virtual void ReturnToPool()
		{
			_rigidbody.velocity = Vector3.zero;
			_rigidbody.angularVelocity = 0;
			ObjectPooler.Instance.Release<T>(gameObject);
		}

		protected virtual void OnTriggerEnter2D(Collider2D other)
		{
			ReturnToPool();
		}
		
		public virtual void Shoot() { }
	}
}
