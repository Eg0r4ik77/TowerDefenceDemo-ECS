using UnityEngine;

namespace Code.Infrastructure.View.Factory
{
    public interface IEntityViewFactory
    {
        public EntityView CreateViewForEntity(GameEntity entity);
        public EntityView CreateViewForEntity(GameEntity entity, Vector3 position);
    }
}