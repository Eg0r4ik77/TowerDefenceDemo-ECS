using Entitas;
using UnityEngine;

namespace Gameplay.Effects.Systems
{
    public class ProcessDamageSystem : IExecuteSystem
    {
        private readonly GameContext _gameContext;
        private readonly IGroup<GameEntity> _entities;

        public ProcessDamageSystem(GameContext gameContext)
        {
            _gameContext = gameContext;
            _entities = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.DamageEffect,
                GameMatcher.EffectTargetId,
                GameMatcher.EffectValue));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                GameEntity target = _gameContext.GetEntityWithId(entity.EffectTargetId);

                if (target.hasHealth)
                {
                    target.ReplaceHealth(target.Health - entity.EffectValue);
                    Debug.Log($"Entity {target.Id}: {target.Health} HP");
                }
                
                entity.isDestroyed = true;
            }
        }
    }
}