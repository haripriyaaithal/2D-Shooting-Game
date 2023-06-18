using ShootingGame.Life;
using UnityEngine;

namespace ShootingGame.Player
{
	public class PlayerBullet : Bullet<PlayerBullet>
	{
		[SerializeField] private int damage;

		protected override void OnTriggerEnter2D(Collider2D other)
		{
			base.OnTriggerEnter2D(other);

			if (other.TryGetComponent<ILifeSystem>(out var lifeSystem))
				lifeSystem.ReduceLife(damage);
		}

		public override void Shoot()
		{
			base.Shoot();
						
			if (TryGetComponent<Rigidbody2D>(out var rb))
				rb.velocity = Vector2.right * _bulletSpeed;
		}

		public void OnCollisionWithBullet()
		{
			ReturnToPool();
		}
	}
}