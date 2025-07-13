using Entitas;

namespace Code.Gameplay.Movement.Systems
{
    public class UpdateTransformRotationSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entites;

        public UpdateTransformRotationSystem(GameContext game)
        {
            _entites = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Transform,
                    GameMatcher.Rotation));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entites)
            {
                entity.Transform.rotation = entity.Rotation;
            }
        }
    }
}