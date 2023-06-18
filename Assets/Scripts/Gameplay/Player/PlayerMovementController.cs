using UnityEngine;
using UnityEngine.InputSystem;

namespace ShootingGame.Player
{
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        
        [Header("Movement Data")]
        [SerializeField, Min(0)] private float _movementSpeed;
        [SerializeField] private float _movementMaxClampX; 
        
        private InputSystem _inputSystem;
        private Vector2 _moveInputVector;

        private Vector2 _minBounds;
        private Vector2 _maxBounds;
        
        private void Awake()
        {
            _inputSystem = new InputSystem();

            CalculateBounds();
        }

        private void CalculateBounds()
        {
            var screenBounds = ScreenBoundsCalculator.Instance.GetScreenBounds();

            var bounds = _spriteRenderer.bounds;
            var playerWidth = bounds.size.x * 0.5f;
            var playerHeight = bounds.size.y * 0.5f;

            var minX = -screenBounds.x + playerWidth;

            var maxY = screenBounds.y - playerHeight;
            var minY = -screenBounds.y + playerHeight;

            _minBounds = new Vector2(minX, minY);
            _maxBounds = new Vector2(_movementMaxClampX, maxY);
        }

        private void OnEnable()
        {
            _inputSystem.Enable();
            _inputSystem.Gameplay.Movement.performed += OnPlayerMove;
            _inputSystem.Gameplay.Movement.canceled += OnPlayerMoveCancelled;
        }

        private void OnDisable()
        {
            if (_inputSystem is null)
                return;
            
            _inputSystem.Gameplay.Movement.performed -= OnPlayerMove;
            _inputSystem.Gameplay.Movement.canceled -= OnPlayerMoveCancelled;
            _inputSystem.Disable();
        }

        private void OnPlayerMoveCancelled(InputAction.CallbackContext context)
        {
            _moveInputVector = Vector2.zero;
        }

        private void OnPlayerMove(InputAction.CallbackContext context)
        {
            _moveInputVector = context.ReadValue<Vector2>();
        }

        private void FixedUpdate()
        {
            _rb.velocity =  _moveInputVector * _movementSpeed;

            var clampedX = Mathf.Clamp(_rb.position.x, _minBounds.x, _maxBounds.x);
            var clampedY = Mathf.Clamp(_rb.position.y, _minBounds.y, _maxBounds.y);
            var clampedPosition = new Vector2(clampedX, clampedY);
            _rb.position = clampedPosition;
        }
    }
}