using Gameplay.Movement.Systems;
using Gameplay.Projectiles.Systems;
using Infrastructure.Systems;

namespace Gameplay.Movement
{
    public sealed class MovementFeature : Feature
    {
        public MovementFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<AdjustTransformWithSpawnPointSystem>());
            Add(systemFactory.Create<MovementToTransformSystem>());
            Add(systemFactory.Create<CannonProjectileMovementSystem>());
            Add(systemFactory.Create<ParabolicMovementSystem>());
            Add(systemFactory.Create<MovementToTargetPositionSystem>());
            Add(systemFactory.Create<DirectionalMoveSystem>());
            Add(systemFactory.Create<RotateToPositionSystem>());
            Add(systemFactory.Create<UpdateTransformRotationSystem>());
            Add(systemFactory.Create<DestroyAfterFinishMovementToTargetSystem>());
        }
    }
}