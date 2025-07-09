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
    }
}