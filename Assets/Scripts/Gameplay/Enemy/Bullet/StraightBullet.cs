using UnityEngine;

namespace ShootingGame.Enemy.Bullet
{
    public class StraightBullet : EnemyBullet<StraightBullet>
    {
        public override void Shoot()
        {
            base.Shoot();
            var myTransform = transform;
            var velocity = (_playerTransform.position - myTransform.position).normalized * _bulletSpeed;
            _rigidbody.velocity = velocity;
            myTransform.LookAt(_playerTransform);
            
            var newRotation = myTransform.rotation;
            newRotation.y = 0;
            myTransform.rotation = newRotation;
        }
    }
}