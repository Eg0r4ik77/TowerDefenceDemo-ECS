using Entitas;

namespace Gameplay.Cooldowns
{
  [Game] public class Cooldown : IComponent { public float Value; }
  [Game] public class CooldownLeft : IComponent { public float Value; }
  [Game] public class CooldownUp : IComponent { }
}