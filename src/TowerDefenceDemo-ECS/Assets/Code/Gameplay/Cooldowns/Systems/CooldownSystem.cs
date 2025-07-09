using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Cooldowns.Systems
{
  public class CooldownSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _cooldownables;
    private readonly List<GameEntity> _buffer = new (32);

    public CooldownSystem(GameContext game)
    {
      _cooldownables = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Cooldown,
          GameMatcher.CooldownLeft));
    }

    public void Execute()
    {
      foreach (GameEntity cooldownable in _cooldownables.GetEntities(_buffer))
      {
        cooldownable.ReplaceCooldownLeft(cooldownable.CooldownLeft - Time.deltaTime);

        if (cooldownable.CooldownLeft <= 0)
        {
          cooldownable.isCooldownUp = true;
          cooldownable.RemoveCooldownLeft();
        }
      }
    }
  }
}