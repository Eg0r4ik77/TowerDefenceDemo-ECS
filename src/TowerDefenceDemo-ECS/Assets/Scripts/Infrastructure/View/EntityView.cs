using Infrastructure.View.EntityViewComponents;
using UnityEngine;

namespace Infrastructure.View
{
    public class EntityView : MonoBehaviour, IEntityView
    {
        private GameEntity _entity;

        public GameEntity Entity => _entity;
        
        public void SetEntity(GameEntity entity)
        {
            _entity = entity;
            _entity.AddView(this);
            _entity.Retain(this);

            foreach (EntityViewComponent entityViewComponent in GetComponentsInChildren<EntityViewComponent>()) 
                entityViewComponent.Register();
        }

        public void ReleaseEntity()
        {
            foreach (EntityViewComponent entityViewComponent in GetComponentsInChildren<EntityViewComponent>()) 
                entityViewComponent.Unregister();
      
            _entity.Release(this);
            _entity = null;
        }
    }
}