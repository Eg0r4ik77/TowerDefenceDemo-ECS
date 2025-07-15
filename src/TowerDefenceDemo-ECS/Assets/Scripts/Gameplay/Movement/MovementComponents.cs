using Entitas;
using UnityEngine;

namespace Gameplay.Movement
{
    [Game] public class Moving : IComponent {}
    
    [Game] public class Direction : IComponent { public Vector3 Value; }
    [Game] public class Speed : IComponent { public float Value; }
    [Game] public class ReachDistance : IComponent { public float Value; }
    
    [Game] public class Rotation : IComponent { public Quaternion Value; }
    [Game] public class TargetRotationPosition : IComponent { public Vector3 Value; }
    [Game] public class RotationSpeed : IComponent { public float Value; }
    
    [Game] public class MovementByRigidbody : IComponent { }
    
    [Game] public class MovementToTransform : IComponent { }
    [Game] public class ParabolicMovement : IComponent { }
    
    [Game] public class TargetPosition : IComponent { public Vector3 Value; }
    [Game] public class FinishedPath : IComponent { }
}
