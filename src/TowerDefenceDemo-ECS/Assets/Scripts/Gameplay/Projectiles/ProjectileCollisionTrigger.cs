using Gameplay.Effects;
using Gameplay.Effects.Factory;
using Gameplay.TargetDetection;
using Infrastructure.View;
using UnityEngine;
using Zenject;

namespace Gameplay.Projectiles
{
    [RequireComponent(typeof(EntityView))]
    public class ProjectileCollisionTrigger : MonoBehaviour
    {
        private const string GroundLayer = "Ground";
        
        private IEffectFactory _effectFactory;
        private EntityView _entityView;

        [Inject]
        private void Construct(IEffectFactory effectFactory)
        {
            _effectFactory = effectFactory;
        }
        
        private void Awake()
        {
            _entityView = GetComponent<EntityView>();
        }

        private void OnTriggerEnter(Collider other)
        {
            GameEntity entity = _entityView.Entity;

            if (entity == null)
                return;
            
            if (other.gameObject.layer == LayerMask.NameToLayer(GroundLayer))
            {
                entity.isDestroyed = true;
                return;
            }

            if (other.TryGetComponent(out EntityView otherEntityView))
            {
                GameEntity otherEntity = otherEntityView.Entity;

                if (otherEntity.hasLayer && otherEntity.Layer == EntityLayer.Enemy)
                {
                    _effectFactory.Create(EffectType.Damage, entity.Damage, otherEntity.Id);
                    
                    entity.isDestroyed = true;
                }
            }
        }

    }
}