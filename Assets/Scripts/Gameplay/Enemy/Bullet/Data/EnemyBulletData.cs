using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ShootingGame.Enemy.Bullet
{
	[CreateAssetMenu(menuName = "SO/Enemy bullet data", fileName = "EnemyBulletData")]
	public class EnemyBulletData : ScriptableObject
	{
		[SerializeField] private List<LevelBulletData> _bulletData;

		public GameObject GetBullet(int level, int health)
		{
			var levelBulletData = _bulletData.FirstOrDefault(data => data.levelNumber == level);
			var bulletData = levelBulletData?.bulletData.FirstOrDefault(data => health >= data.minHealth && health <= data.maxHealth);
			return bulletData?.bulletPrefab;
		}

		[Serializable]
		private class LevelBulletData
		{
			[Min(0)] public int levelNumber;
			public List<BulletData> bulletData;
		}
		
		[Serializable]
		public class BulletData
		{
			public GameObject bulletPrefab;
			[Min(0)] public int minHealth;
			[Min(0)] public int maxHealth;
		}
		
	}
}