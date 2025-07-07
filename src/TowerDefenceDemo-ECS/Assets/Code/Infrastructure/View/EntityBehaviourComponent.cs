using UnityEngine;

namespace Code.Infrastructure.View
{
    public abstract class EntityBehaviourComponent : MonoBehaviour
    {
        [SerializeField] private EntityBehaviour _entityBehaviour;
        
        public abstract void RegisterComponents();
        public abstract void UnregisterComponents();

        public GameEntity Entity => _entityBehaviour != null ? _entityBehaviour.Entity : null;
        
        private void Awake()
        {
            _entityBehaviour ??= GetComponent<EntityBehaviour>();
        }
    }
}