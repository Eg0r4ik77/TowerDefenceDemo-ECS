using UnityEngine;
using UnityEngine.Serialization;

namespace Code.Infrastructure.View
{
    public abstract class EntityBehaviourComponent : MonoBehaviour
    {
        [SerializeField] private EntityView _entityView;
        
        public abstract void RegisterComponents();
        public abstract void UnregisterComponents();

        public GameEntity Entity => _entityView != null ? _entityView.Entity : null;
        
        private void Awake()
        {
            _entityView ??= GetComponent<EntityView>();
        }
    }
}