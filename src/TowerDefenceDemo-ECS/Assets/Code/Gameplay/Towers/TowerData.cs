using Code.Infrastructure.View;
using UnityEngine;

namespace Code.Gameplay.Towers
{
    [CreateAssetMenu(menuName = "Data/Gameplay/Tower/Base", fileName = "Tower")]
    public class TowerData : ScriptableObject
    {
        [field: SerializeField] public TowerType Type { get; private set; }
        [field: SerializeField] public EntityView View { get; private set; }
        [field: SerializeField] public float FindTargetInterval { get; private set; }
        [field: SerializeField] public float AttackTimeInterval { get; private set; }
        [field: SerializeField] public float Range { get; private set; }
        [field: SerializeField] public bool FollowTarget { get; private set; }
    }
}