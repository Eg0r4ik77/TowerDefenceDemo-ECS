using UnityEngine;

namespace Gameplay.Towers.Data
{
    [CreateAssetMenu(menuName = "Data/Gameplay/Tower/CannonTower", fileName = "CannonTower")]
    public class CannonTowerData : TowerData
    { 
        [field: SerializeField] public float RotationSpeed { get; private set; }
        [field: SerializeField] public float StartProjectileSpeed { get; private set; }
    }
}