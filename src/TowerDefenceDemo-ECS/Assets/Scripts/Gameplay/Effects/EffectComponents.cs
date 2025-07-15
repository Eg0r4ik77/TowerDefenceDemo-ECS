using Entitas;

namespace Gameplay.Effects
{
    [Game] public class DamageEffect : IComponent {}
    [Game] public class Damage : IComponent { public float Value; }
    
    [Game] public class EffectTargetId : IComponent { public int Value; }
    [Game] public class EffectValue : IComponent { public float Value; }
}