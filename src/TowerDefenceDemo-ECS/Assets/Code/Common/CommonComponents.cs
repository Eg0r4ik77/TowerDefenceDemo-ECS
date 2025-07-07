using Entitas;
using UnityEngine;

namespace Code.Common
{
    [Game] public class WorldPosition : IComponent { public Vector3 Value; }
    [Game] public class View : IComponent { public GameObject Value; }
    [Game] public class TransformComponent : IComponent { public Transform Value; }
    [Game] public class Destroyed : IComponent { }
}