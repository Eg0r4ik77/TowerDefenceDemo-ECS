using UnityEngine;

namespace Code.Gameplay.Towers
{
    [CreateAssetMenu(menuName = "Data/Gameplay/Tower/SimpleTower", fileName = "SimpleTower")]
    public class SimpleTowerData : TowerData
    {
        [field: SerializeField] public GameObject ProjectilePrefab { get; private set; }
        [field: SerializeField] public int MaxProjectilesCountInPool { get; private set; }
    }
}