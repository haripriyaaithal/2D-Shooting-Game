using UnityEngine;

public class ScreenBoundsCalculator
{
	public static ScreenBoundsCalculator Instance => _instance ??= new ScreenBoundsCalculator();
	private static ScreenBoundsCalculator _instance;
	
	private Camera _mainCamera;

	private ScreenBoundsCalculator()
	{
		_mainCamera = Camera.main;
	}

	public Vector2 GetScreenBounds()
	{
		var point = new Vector2(Screen.width, Screen.height);

		if (!_mainCamera)
			_mainCamera = Camera.main;	

		return _mainCamera.ScreenToWorldPoint(point);
	}
}
