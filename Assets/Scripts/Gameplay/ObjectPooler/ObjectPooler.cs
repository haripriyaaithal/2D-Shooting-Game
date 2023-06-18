using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ShootingGame.Pooling
{
	public class ObjectPooler : IObjectPooler
	{
		public static IObjectPooler Instance => _instance ??= new ObjectPooler();
		private static IObjectPooler _instance;

		private readonly Dictionary<Type, List<GameObject>> _objectPoolDictionary;
		private readonly Vector2 _defaultPosition = new Vector2(25000, 0);

		private ObjectPooler()
		{
			_objectPoolDictionary = new Dictionary<Type, List<GameObject>>();
			SceneManager.sceneLoaded += OnSceneChange;
		}

		~ObjectPooler()
		{
			SceneManager.sceneLoaded -= OnSceneChange;
		}

		public GameObject Get<T>(GameObject go)
		{
			var key = typeof(T);
			return GetObject(go, key);
		}

		private GameObject GetObject(GameObject go, Type key)
		{
			if (!_objectPoolDictionary.TryGetValue(key, out var goList))
			{
				var goInstance = CreateInstance(go);
				goList = new List<GameObject> { goInstance };
				_objectPoolDictionary.Add(key, goList);
			}

			var instance = default(GameObject);
			if (goList.Count > 0)
			{
				instance = goList.FirstOrDefault();
				goList.Remove(instance);
			}
			else
			{
				instance = CreateInstance(go);
			}

			instance.SetActive(true);

			return instance;
		}

		public GameObject Get(Type key, GameObject go)
		{
			return GetObject(go, key);
		}

		public void Release<T>(GameObject go)
		{
			go.SetActive(false);
			var key = typeof(T);
			if (_objectPoolDictionary.TryGetValue(key, out var goList))
				goList.Add(go);
		}

		private GameObject CreateInstance(GameObject go)
		{
			return GameObject.Instantiate(go, _defaultPosition, quaternion.identity);
		}

		private void OnSceneChange(Scene arg0, LoadSceneMode arg1)
		{
			ClearPool();
		}

		public void ClearPool()
		{
			foreach (var key in _objectPoolDictionary.Keys)
				_objectPoolDictionary[key].Clear();

			_objectPoolDictionary?.Clear();
		}
	}
}