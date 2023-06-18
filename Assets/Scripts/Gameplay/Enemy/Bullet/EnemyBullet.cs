using ShootingGame.Life;
using UnityEngine;

namespace ShootingGame.Enemy
{
    public abstract class EnemyBullet<T> : Bullet<T>
    {
        protected Transform _playerTransform;
        protected Transform _enemyTransform;
        
        protected override void Awake()
        {
            base.Awake();
            var playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj is not null)
                playerObj.TryGetComponent<Transform>(out _playerTransform);

            var enemyObj = GameObject.FindObjectOfType<EnemyShooter>();
            if (enemyObj is not null)
                _enemyTransform = enemyObj.transform;
        }

        protected override void OnTriggerEnter2D(Collider2D other)
        {
            base.OnTriggerEnter2D(other);

            if (other.TryGetComponent<ILifeSystem>(out var lifeSystem))
                lifeSystem.ReduceLife();
        }
    }
}