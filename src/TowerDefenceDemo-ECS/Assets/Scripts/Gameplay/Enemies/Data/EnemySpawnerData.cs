using UnityEngine;

namespace Gameplay.Enemies.Data
{
    [CreateAssetMenu(menuName = "Data/Gameplay/EnemySpawner", fileName = "EnemySpawner")]
    public class EnemySpawnerData : ScriptableObject
    {
        [field: SerializeField] public float Interval { get; private set; }
        [field: SerializeField] public EnemyType EnemyType { get; private set; }
    }
}