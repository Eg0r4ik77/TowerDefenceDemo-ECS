using System.Collections.Generic;
using Code.Infrastructure.Identifiers;
using Entitas;

namespace Code.Common.Systems
{
    public class CleanupDestroyedSystem : ICleanupSystem
    {
        private readonly IIdentifierGenerator _identifierGenerator;
        private readonly IGroup<GameEntity> _entities;
        private readonly List<GameEntity> _buffer = new (64);

        public CleanupDestroyedSystem(GameContext game, IIdentifierGenerator identifierGenerator)
        {
            _identifierGenerator = identifierGenerator;
            _entities = game.GetGroup(GameMatcher.AllOf(GameMatcher.Destroyed));
        }

        public void Cleanup()
        {
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            {
                _identifierGenerator.ReleaseId(entity.Id);
                entity.Destroy();
            }
        }
    }
}