using ShootingGame.Pooling;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ShootingGame.Player
{
    public class PlayerShooter : MonoBehaviour
    {
        [SerializeField] private GameObject bullet;
        
        private InputSystem _inputSystem;

        private void Awake()
        {
            _inputSystem = new InputSystem();
        }

        private void OnEnable()
        {
            _inputSystem.Enable();
            _inputSystem.Gameplay.Shoot.performed += OnShoot;
        }

        private void OnDisable()
        {
            _inputSystem.Disable();
            _inputSystem.Gameplay.Shoot.performed -= OnShoot;
        }
        
        private void OnShoot(InputAction.CallbackContext context)
        {
            var bulletInstance = ObjectPooler.Instance.Get<PlayerBullet>(bullet);
            var bulletTransform = bulletInstance.transform;
            bulletTransform.position = transform.position;
            bulletTransform.rotation = Quaternion.identity;

            if (bulletInstance.TryGetComponent<IBullet>(out var b))
                b.Shoot();
            
            BulletFiredCounter.Instance.OnBullerFired();
        }
    }
}