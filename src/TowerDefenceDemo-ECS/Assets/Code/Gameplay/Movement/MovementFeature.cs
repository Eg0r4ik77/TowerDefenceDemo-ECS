using Code.Gameplay.Movement.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Movement
{
    public sealed class MovementFeature : Feature
    {
        public MovementFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<MovementToTransformSystem>());
            Add(systemFactory.Create<ParabolicMovementSystem>());
            Add(systemFactory.Create<MovementToTargetPositionSystem>());
            Add(systemFactory.Create<DirectionalMoveSystem>());
            Add(systemFactory.Create<UpdateRigidbodyPositionSystem>());
            Add(systemFactory.Create<UpdatePositionWithBottomPoint>());
            Add(systemFactory.Create<DestroyAfterFinishMovementToTargetSystem>());
        }
    }
}