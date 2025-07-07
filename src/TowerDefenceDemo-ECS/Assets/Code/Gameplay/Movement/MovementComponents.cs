using Entitas;
using UnityEngine;

namespace Code.Gameplay.Movement
{
    [Game] public class Moving : IComponent {}
    [Game] public class Direction : IComponent { public Vector3 Value; }
    [Game] public class Speed : IComponent { public float Value; }
    [Game] public class ReachDistance : IComponent { public float Value; }
    
    [Game] public class TargetPosition : IComponent { public Vector3 Value; }
    [Game] public class FinishedPath : IComponent { }
}
