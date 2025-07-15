using System;
using System.Collections.Generic;
using System.Linq;
using Gameplay.Enemies;
using Gameplay.Enemies.Data;
using Gameplay.Projectiles;
using Gameplay.Projectiles.Data;
using Gameplay.Towers;
using Gameplay.Towers.Data;
using UnityEngine;
using Zenject;

namespace Infrastructure.StaticData
{
    public class StaticDataService : IStaticDataService, IInitializable
    {
        private Dictionary<EnemyType, EnemyData> _enemyDataByType;
        private Dictionary<TowerType, TowerData> _towerDataByType;
        private Dictionary<ProjectileType, ProjectileData> _projectileDataByType;
        private EnemySpawnerData _enemySpawnerData;
        
        public void Initialize()
        {
            LoadAll();
        }
        
        public void LoadAll()
        {
            LoadEnemyData();
            LoadEnemySpawnerData();
            LoadTowerData();
            LoadProjectileData();
        }

        public EnemyData GetEnemyData(EnemyType type) => _enemyDataByType.TryGetValue(type, out EnemyData data)
            ? data
            : throw new Exception($"Data for enemy {type} was not found");

        public EnemySpawnerData GetEnemySpawnerData() => _enemySpawnerData != null
            ? _enemySpawnerData
            : throw new Exception($"Data for enemy spawner was not found");
        
        public TowerData GetTowerData(TowerType type)=> _towerDataByType.TryGetValue(type, out TowerData data)
            ? data
            : throw new Exception($"Data for tower {type} was not found");
        
        public ProjectileData GetProjectileData(ProjectileType type)=> _projectileDataByType.TryGetValue(type, out ProjectileData data)
            ? data
            : throw new Exception($"Data for projectile {type} was not found");
        
        private void LoadEnemyData()
        {
            _enemyDataByType = Resources.LoadAll<EnemyData>("Data/Enemies")
                .ToDictionary(data => data.Type, data => data);
        }
        private void LoadEnemySpawnerData()
        {
            _enemySpawnerData = Resources.Load<EnemySpawnerData>("Data/EnemySpawnerData");
        }
        
        private void LoadTowerData()
        {
            _towerDataByType = Resources.LoadAll<TowerData>("Data/Towers")
                .ToDictionary(data => data.Type, data => data);
        }
        
        private void LoadProjectileData()
        {
            _projectileDataByType = Resources.LoadAll<ProjectileData>("Data/Projectiles")
                .ToDictionary(data => data.Type, data => data);
        }
    }
}