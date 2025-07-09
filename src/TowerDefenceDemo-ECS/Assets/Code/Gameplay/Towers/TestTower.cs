using System;
using Code.Common;
using Code.Common.Extensions;
using Code.Infrastructure;
using Code.Infrastructure.Identifiers;
using Code.Infrastructure.View;
using Code.StaticData;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Towers
{
    public class TestTower : MonoBehaviour
    {
        private GameContext _gameContext;
        private IStaticDataService _staticDataService;
        private IIdentifierGenerator _identifierGenerator;

        [Inject]
        private void Construct(GameContext gameContext,
            IStaticDataService staticDataService,
            IIdentifierGenerator identifierGenerator)
        {
            _gameContext = gameContext;
            _staticDataService = staticDataService;
            _identifierGenerator = identifierGenerator;
        }

        private void Start()
        {
            CreateSimple();
        }

        private GameEntity CreateSimple()
        {
            TowerData data = _staticDataService.GetTowerData(TowerType.Simple);

            GameEntity entity = _gameContext.CreateEntity()
                .AddId(_identifierGenerator.GetId())
                .AddWorldPosition(transform.position)
                .AddTargetDetectionInterval(2)
                .AddTargetDetectionTimer(2)
                .AddTargetDetectionDistance(10)
                .AddTargetDetectionLayerMask(EntityLayer.Enemy.AsMask())
                .With(e => e.isNeedForDetection = true)
                .With(e => e.isReadyForDetection = true)
                .With(e => e.isFollowingTarget = true);
            
            GetComponent<EntityView>().SetEntity(entity);
             
            return entity;
        }
    }
}