using UnityEngine;

namespace Code.Infrastructure.View
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

            foreach (EntityBehaviourComponent registrar in GetComponentsInChildren<EntityBehaviourComponent>()) 
                registrar.RegisterComponents();
        }

        public void ReleaseEntity()
        {
            foreach (EntityBehaviourComponent registrar in GetComponentsInChildren<EntityBehaviourComponent>()) 
                registrar.UnregisterComponents();
      
            _entity.Release(this);
            _entity = null;
        }
    }
}