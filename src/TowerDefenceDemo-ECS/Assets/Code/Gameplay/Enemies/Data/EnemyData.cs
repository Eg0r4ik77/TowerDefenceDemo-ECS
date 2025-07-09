using Code.Infrastructure.View;
using UnityEngine;

namespace Code.Gameplay.Enemies.Data
{
    [CreateAssetMenu(menuName = "Data/Gameplay/Enemy", fileName = "Monster")]
    public class EnemyData : ScriptableObject
    {
        [field: SerializeField] public EnemyType Type { get; private set; }
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public int MaxHealth { get; private set; }
        [field: SerializeField] public float ReachDistance { get; private set; }
        [field: SerializeField] public GameObject Prefab { get; private set; }
    }
}