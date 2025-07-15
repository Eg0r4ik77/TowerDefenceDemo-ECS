using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Gameplay.Movement.Systems
{
    public class AdjustTransformWithSpawnPointSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _movers;
        
        private readonly List<GameEntity> _buffer = new (64);

        public AdjustTransformWithSpawnPointSystem(GameContext game)
        {
            _movers = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.WorldPosition,
                GameMatcher.Transform,
                GameMatcher.AdjustTransformWithSpawnPoint,
                GameMatcher.SpawnPoint));
        }
    
        public void Execute()
        {
            foreach (GameEntity mover in _movers.GetEntities(_buffer))
            {
                mover.Transform.position = mover.WorldPosition - Vector3.up * mover.SpawnPoint.localPosition.y;
                mover.isAdjustTransformWithSpawnPoint = false;
            }
        }
    }
}