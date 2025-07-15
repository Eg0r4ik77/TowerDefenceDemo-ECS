using UnityEngine;

namespace Infrastructure.View.EntityViewComponents
{
    public abstract class EntityViewComponent : MonoBehaviour
    {
        [SerializeField] private EntityView _entityView;
        
        public abstract void Register();
        public abstract void Unregister();

        public GameEntity Entity => _entityView != null ? _entityView.Entity : null;
        
        private void Awake()
        {
            _entityView ??= GetComponent<EntityView>();
        }
    }
}