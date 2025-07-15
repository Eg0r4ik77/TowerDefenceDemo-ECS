using Entitas;

namespace Gameplay.TargetDetection
{
    [Game] public class TargetId : IComponent { public int Value; }
    [Game] public class TargetDetectionInterval : IComponent { public float Value; }
    [Game] public class TargetDetectionTimer : IComponent { public float Value; }
    [Game] public class TargetDetectionDistance : IComponent { public float Value; }
    [Game] public class TargetDetectionLayerMask : IComponent { public int Value; }
    
    [Game] public class Layer : IComponent { public EntityLayer Value; }
    
    [Game] public class NeedForDetection : IComponent { }
    [Game] public class ReadyForDetection : IComponent { }
    [Game] public class FollowingTarget : IComponent { }
}