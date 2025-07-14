using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.View.Factory
{
    public class EntityViewPool : IEntityViewPool
    {
        private const int PoolStartCapacity = 16;
        
        private readonly DiContainer _diContainer;
        
        private readonly Dictionary<EntityViewPoolType, Stack<EntityView>> _pools = new();
        
        public EntityViewPool(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }
        
        public EntityView GetView(GameEntity entity)
        {
            if (!_pools.TryGetValue(entity.EntityViewPoolType, out Stack<EntityView> pool))
            {
                pool = new Stack<EntityView>(PoolStartCapacity);
                _pools[entity.EntityViewPoolType] = pool;
            }
        
            EntityView view;
            
            if (pool.Count > 0)
            {
                view = pool.Pop();
                view.gameObject.SetActive(true);
            }
            else
            {
                view = CreateEntityView(entity);
            }
        
            view.SetEntity(entity);
            return view;
        }
        
        public void ReleaseView(GameEntity entity)
        {
            if (!_pools.TryGetValue(entity.EntityViewPoolType, out Stack<EntityView> pool))
            {
                pool = new Stack<EntityView>(PoolStartCapacity);
                _pools[entity.EntityViewPoolType] = pool;
            }
        
            entity.View.gameObject.SetActive(false);
            pool.Push((EntityView)entity.View);
        }

        private EntityView CreateEntityView(GameEntity entity)
        {
            return entity.hasWorldPosition 
                ? _diContainer.InstantiatePrefabForComponent<EntityView>(
                    prefab: entity.ViewPrefab,
                    position: entity.WorldPosition,
                    rotation: Quaternion.identity,
                    parentTransform: null)
                : _diContainer.InstantiatePrefabForComponent<EntityView>(entity.ViewPrefab);
        }
    }
}