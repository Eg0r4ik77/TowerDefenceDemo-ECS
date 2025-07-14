using Entitas;
using UnityEngine;

namespace Code.Gameplay.Towers
{
    [Game] public class AttackSpawnPoint : IComponent { public Transform Value; }
    [Game] public class CannonLength : IComponent { public float Value; }
    [Game] public class AngleShot : IComponent { public float Value; }
    
    [Game] public class SimpleTowerComponent : IComponent { }
    [Game] public class CannonTowerComponent : IComponent { }
}