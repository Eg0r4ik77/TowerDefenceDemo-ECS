using UnityEngine;

namespace Gameplay.Projectiles.Data
{
    [CreateAssetMenu(menuName = "Data/Gameplay/Projectile", fileName = "Projectile")]
    public class ProjectileData : ScriptableObject
    {
        [field: SerializeField] public ProjectileType Type { get; private set; }
        [field: SerializeField, Range(15, 40)] public float Speed { get; private set; }
        [field: SerializeField] public int Damage { get; private set; }
        [field: SerializeField] public float LifeTime { get; private set; }
        [field: SerializeField] public GameObject Prefab { get; private set; }
    }
}