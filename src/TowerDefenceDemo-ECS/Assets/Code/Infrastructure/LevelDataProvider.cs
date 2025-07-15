using System;
using UnityEngine;

namespace Code.Infrastructure
{
    [Serializable]
    public class LevelDataProvider
    {
        [field: SerializeField] private Transform _spawnPoint;
        [field: SerializeField] private Transform _targetPoint;

        public Transform SpawnPoint => _spawnPoint;
        public Transform TargetPoint => _targetPoint;
    }
}