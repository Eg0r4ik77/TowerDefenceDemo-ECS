using Entitas;
using UnityEngine;

namespace Code.Gameplay.Projectiles.Systems
{
    public class CannonProjectileMovementSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public CannonProjectileMovementSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.CannonProjectile,
                GameMatcher.AttackSpawnPoint,
                GameMatcher.WorldPosition,
                GameMatcher.DistanceBeforeDeparture,
                GameMatcher.Transform));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                if (Vector3.Distance(entity.AttackSpawnPoint.position, entity.WorldPosition) < entity.DistanceBeforeDeparture)
                {
                    entity.ReplaceDirection(entity.Transform.forward);
                }
                else
                { 
                    entity.isParabolicMovement = true;
                }
            }
        }
    }
}