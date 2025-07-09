using System;
using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Enemies;
using Code.Gameplay.Enemies.Data;
using Code.Gameplay.Towers;
using UnityEngine;
using Zenject;

namespace Code.StaticData
{
    public class StaticDataService : IStaticDataService, IInitializable
    {
        private Dictionary<EnemyType, EnemyData> _enemyDataByType;
        private Dictionary<TowerType, TowerData> _towerDataByType;
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
    }
}