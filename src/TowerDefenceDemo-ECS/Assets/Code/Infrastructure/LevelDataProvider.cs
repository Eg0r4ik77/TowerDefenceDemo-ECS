using System;
using UnityEngine;

namespace Code.Infrastructure
{
    [Serializable]
    public class LevelDataProvider
    {
        [field: SerializeField] private Transform _spawnPoint;
        [field: SerializeField] private Transform _targetPoint;
        
        public Vector3 SpawnPosition => _spawnPoint.position;
        public Vector3 TargetPosition => _targetPoint.position;
    }
}