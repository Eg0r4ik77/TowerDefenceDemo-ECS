using System;
using Code.Common.Extensions;
using Code.Gameplay.Damage;
using Code.Gameplay.Effects.Factory;

namespace Entitas
{
    public class EffectFactory : IEffectFactory
    {
        private readonly GameContext _gameContext;

        public EffectFactory(GameContext gameContext)
        {
            _gameContext = gameContext;
        }
        
        public GameEntity Create(EffectType type, float value, int targetId)
        {
            return type switch
            {
                EffectType.Damage => CreateDamageEffect(value, targetId),
                _ => throw new Exception($"Effect with type {type} does not exist")
            };
        }

        private GameEntity CreateDamageEffect(float value, int targetId)
        {
            return _gameContext.CreateEntity()
                .AddEffectValue(value)
                .AddEffectTargetId(targetId)
                .With(e => e.isDamageEffect = true);
        }
    }
}