using UnityEngine;

public class EnemyMovementController : MonoBehaviour
{
	[SerializeField, Min(0)] private float _movementSpeed;
	[SerializeField] private Rigidbody2D _rigidbody2D;
	[SerializeField] private SpriteRenderer _spriteRenderer;
	
	private float _minY;
	private float _maxY;
	
	private Vector2 _targetPosition;

	private void Awake()
	{
		var screenBounds = ScreenBoundsCalculator.Instance.GetScreenBounds();
		var spriteBoundY = _spriteRenderer.bounds.size.y * 0.5f;
		_minY = -screenBounds.y + spriteBoundY;
		_maxY = screenBounds.y - spriteBoundY;

		_targetPosition = Vector2.up;
	}

	private void FixedUpdate()
	{
		if (_rigidbody2D.position.y <= _minY)
			_targetPosition = Vector2.up;
		else if (_rigidbody2D.position.y >= _maxY)
			_targetPosition = Vector2.down;
		
		var velocity = _targetPosition * _movementSpeed;
		_rigidbody2D.velocity = velocity;
	}
}