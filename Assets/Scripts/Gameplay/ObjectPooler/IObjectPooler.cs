using System;
using UnityEngine;

namespace ShootingGame.Pooling
{
	public interface IObjectPooler
	{
		public GameObject Get<T>(GameObject go);
		public GameObject Get(Type key, GameObject go);
		public void Release<T>(GameObject go);
		public void ClearPool();
	}
}