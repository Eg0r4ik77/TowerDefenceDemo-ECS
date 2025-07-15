using System.Collections.Generic;
using Entitas;
using Infrastructure.Identifiers;

namespace Common.Destroy.Systems
{
    public class CleanupDestroyedSystem : ICleanupSystem
    {
        private readonly IIdentifierGenerator _identifierGenerator;
        private readonly IGroup<GameEntity> _entities;
        private readonly List<GameEntity> _buffer = new (64);

        public CleanupDestroyedSystem(GameContext game, IIdentifierGenerator identifierGenerator)
        {
            _identifierGenerator = identifierGenerator;
            _entities = game.GetGroup(GameMatcher.Destroyed);
        }

        public void Cleanup()
        {
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            {
                if(entity.hasId)
                    _identifierGenerator.ReleaseId(entity.Id);
                
                entity.Destroy();
            }
        }
    }
}