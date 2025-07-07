using Code.Gameplay.Movement.Systems;

namespace Code.Gameplay.Movement
{
    public sealed class MovementFeature : Feature
    {
        public MovementFeature(GameContext gameContext)
        {
            Add(new DirectionalMoveSystem(gameContext));
            Add(new UpdateTransformPositionSystem(gameContext));
            Add(new PathMovementSystem(gameContext));
            Add(new DestroyAfterFinishPathSystem(gameContext));
        }
    }
}