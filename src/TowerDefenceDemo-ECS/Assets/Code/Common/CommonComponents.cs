using Code.Infrastructure.View;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Code.Common
{
    [Game] public class Id : IComponent { [PrimaryEntityIndex] public int Value; }
    [Game] public class WorldPosition : IComponent { public Vector3 Value; }
    
    [Game] public class View : IComponent { public IEntityView Value; }
    [Game] public class ViewPrefab : IComponent { public GameObject Value; }
    
    [Game] public class TransformComponent : IComponent { public Transform Value; }
    [Game] public class BottomPoint : IComponent { public Transform Value; }
    [Game] public class Layer : IComponent { public EntityLayer Value; }
    
    [Game] public class Health : IComponent { public float Value; }
    [Game] public class MaxHealth : IComponent { public float Value; }
    
    [Game] public class SelfDestructTimer : IComponent { public float Value; }
    [Game] public class Destroyed : IComponent { }
}