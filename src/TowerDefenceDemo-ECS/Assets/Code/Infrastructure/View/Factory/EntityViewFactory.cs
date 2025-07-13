using UnityEngine;
using Zenject;

namespace Code.Infrastructure.View.Factory
{
    public class EntityViewFactory : IEntityViewFactory
    {
        private readonly DiContainer _diContainer;

        public EntityViewFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }
        
        public EntityView CreateViewForEntity(GameEntity entity)
        {
            EntityView view = _diContainer.InstantiatePrefabForComponent<EntityView>(entity.ViewPrefab);
      
            view.SetEntity(entity);

            return view;
        }
        
        public EntityView CreateViewForEntity(GameEntity entity, Vector3 position)
        {
            EntityView view = _diContainer.InstantiatePrefabForComponent<EntityView>(
                prefab: entity.ViewPrefab,
                position: position,
                rotation: Quaternion.identity,
                parentTransform: null
                );
      
            view.SetEntity(entity);

            return view;
        }
    }
}