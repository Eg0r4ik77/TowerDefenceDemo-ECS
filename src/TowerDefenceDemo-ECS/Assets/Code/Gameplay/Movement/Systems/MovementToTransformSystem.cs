using Entitas;
using UnityEngine;

namespace Code.Gameplay.Movement.Systems
{
    public class MovementToTransformSystem : IExecuteSystem
    {
        private readonly GameContext _gameContext;
        
        private readonly IGroup<GameEntity> _movers;

        public MovementToTransformSystem(GameContext gameContext)
        {
            _gameContext = gameContext;
            
            _movers = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.Moving,
                GameMatcher.TargetId,
                GameMatcher.MovementToTransform));
        }

        public void Execute()
        {
            foreach (GameEntity mover in _movers)
            {
                GameEntity target = _gameContext.GetEntityWithId(mover.TargetId);

                if (target.hasTransform)
                {
                    mover.ReplaceDirection((target.Transform.position - mover.WorldPosition).normalized);
                }
            }
        }
    }
}