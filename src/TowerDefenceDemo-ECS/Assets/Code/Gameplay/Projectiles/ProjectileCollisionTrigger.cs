using System;
using Code.Infrastructure.View;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Projectiles
{
    public class ProjectileCollisionTrigger : MonoBehaviour
    {
        private const string GroundLayer = "Ground";
        private const string EnemyLayer = "Enemy";
        
        private GameContext _gameContext;
        private EntityView _entityView;

        [Inject]
        private void Construct(GameContext gameContext)
        {
            _gameContext = gameContext;
        }
        
        private void Awake()
        {
            _entityView = GetComponent<EntityView>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer(GroundLayer))
            {
                _entityView.Entity.isDestroyed = true;
                return;
            }

            if (other.gameObject.layer == LayerMask.NameToLayer(EnemyLayer) && other.TryGetComponent(out EntityView otherEntityView))
            { 
                //_gameContext.CreateEntity().AddTargetId(otherEntityView.Entity.Id).AddDamage()
                    
                _entityView.Entity.isDestroyed = true;
            }
        }

    }
}