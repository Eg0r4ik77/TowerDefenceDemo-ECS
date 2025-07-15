using UnityEngine;

namespace Gameplay.Towers.Data
{
    [CreateAssetMenu(menuName = "Data/Gameplay/Tower/Base", fileName = "Tower")]
    public class TowerData : ScriptableObject
    {
        [field: SerializeField] public TowerType Type { get; private set; }
        [field: SerializeField] public GameObject Prefab { get; private set; }
        [field: SerializeField] public float TargetDetectionInterval { get; private set; }
        [field: SerializeField] public float TargetDetectionDistance { get; private set; }
        [field: SerializeField] public float Cooldown { get; private set; }
    }
}