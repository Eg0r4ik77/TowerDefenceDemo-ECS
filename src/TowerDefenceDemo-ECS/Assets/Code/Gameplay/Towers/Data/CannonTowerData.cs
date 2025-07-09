using UnityEngine;

namespace Code.Gameplay.Towers
{
    [CreateAssetMenu(menuName = "Data/Gameplay/Tower/CannonTower", fileName = "CannonTower")]
    public class CannonTowerData : TowerData
    {
        [field: SerializeField] public GameObject ProjectilePrefab { get; private set; }
        [field: SerializeField] public int MaxProjectilesCountInPool { get; private set; }
        [field: SerializeField] public float RotationSpeed { get; private set; }
    }
}