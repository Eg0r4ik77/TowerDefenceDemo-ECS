using Entitas;
using Entitas.CodeGeneration.Attributes;
using Infrastructure.View;
using UnityEngine;

namespace Common
{
    [Game] public class Id : IComponent { [PrimaryEntityIndex] public int Value; }
    [Game] public class WorldPosition : IComponent { public Vector3 Value; }
    
    [Game] public class View : IComponent { public IEntityView Value; }
    [Game] public class ViewPrefab : IComponent { public GameObject Value; }
    
    [Game] public class SpawnPoint : IComponent { public Transform Value; }
    [Game] public class AdjustTransformWithSpawnPoint : IComponent { }
    
    [Game] public class TransformComponent : IComponent { public Transform Value; }
    [Game] public class RigidbodyComponent : IComponent { public Rigidbody Value; }
    
    [Game] public class SelfDestroyTimer : IComponent { public float Value; }
    [Game] public class Destroyed : IComponent { }
}