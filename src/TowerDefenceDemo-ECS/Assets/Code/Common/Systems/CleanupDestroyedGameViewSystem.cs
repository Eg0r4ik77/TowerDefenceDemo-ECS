using Entitas;
using UnityEngine;

namespace Code.Common.Systems
{
    public class CleanupDestroyedGameViewSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public CleanupDestroyedGameViewSystem(GameContext game) => 
            _entities = game.GetGroup(
                GameMatcher.AllOf(
                    GameMatcher.View,
                    GameMatcher.Destroyed));

        public void Cleanup()
        {
            foreach (GameEntity entity in _entities)
            {
                //entity.View.ReleaseEntity();
                Object.Destroy(entity.View);
            }
        }
    }
}