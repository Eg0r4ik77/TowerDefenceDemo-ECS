using Code.Gameplay.Enemies;
using Code.Gameplay.Towers.Factory;
using Code.Infrastructure.Identifiers;
using Code.Infrastructure.Systems;
using Code.Infrastructure.View.Factory;
using Code.StaticData;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private LevelDataProvider _levelDataProvider;
        
        public override void InstallBindings()
        {
            Container.Bind<GameContext>().FromInstance(Contexts.sharedInstance.game).AsSingle();
            Container.Bind<LevelDataProvider>().FromInstance(_levelDataProvider).AsSingle();
            Container.BindInterfacesAndSelfTo<StaticDataService>().AsSingle();
            Container.Bind<IIdentifierGenerator>().To<IdentifierGenerator>().AsSingle();
            
            Container.Bind<ISystemFactory>().To<SystemFactory>().AsSingle();
            Container.Bind<IEntityViewFactory>().To<EntityViewFactory>().AsSingle();
            Container.Bind<IEnemyFactory>().To<EnemyFactory>().AsSingle();
            Container.Bind<ITowerFactory>().To<TowerFactory>().AsSingle();
        }
    }
}