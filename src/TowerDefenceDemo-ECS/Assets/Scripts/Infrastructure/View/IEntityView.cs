using UnityEngine;

namespace Infrastructure.View
{
    public interface IEntityView
    {
        public GameEntity Entity { get; }
        public void SetEntity(GameEntity entity);
        public void ReleaseEntity();
    
        GameObject gameObject { get; }
    }
}