using Gameplay.Effects.Factory;
using Gameplay.Enemies.Factory;
using Gameplay.Projectiles.Factory;
using Gameplay.Time;
using Gameplay.Towers.Factory;
using Infrastructure.Identifiers;
using Infrastructure.StaticData;
using Infrastructure.Systems;
using Infrastructure.View.Pool;
using UnityEngine;
using Zenject;

namespace Infrastructure
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
            Container.Bind<ITimeService>().To<UnityTimeService>().AsSingle();
            
            Container.Bind<ISystemFactory>().To<SystemFactory>().AsSingle();
            Container.Bind<IEntityViewPool>().To<EntityViewPool>().AsSingle();
            Container.Bind<IEnemyFactory>().To<EnemyFactory>().AsSingle();
            Container.Bind<ITowerFactory>().To<TowerFactory>().AsSingle();
            Container.Bind<IProjectileFactory>().To<ProjectileFactory>().AsSingle();
            Container.Bind<IEffectFactory>().To<EffectFactory>().AsSingle();
        }
    }
}