using Entitas;

namespace Code.Gameplay.Lifetime
{
    [Game] public class Health : IComponent { public float Value; }
    [Game] public class MaxHealth : IComponent { public float Value; }
    [Game] public class Dead : IComponent { }
}