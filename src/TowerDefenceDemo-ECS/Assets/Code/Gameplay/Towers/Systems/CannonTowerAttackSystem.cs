using System.Collections.Generic;
using Code.Gameplay.Cooldowns;
using Code.Gameplay.Projectiles;
using Code.Gameplay.Projectiles.Factory;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Attack.Systems
{
    public class CannonTowerAttackSystem : IExecuteSystem
    {
        private readonly GameContext _gameContext;
        private readonly IProjectileFactory _projectileFactory;

        private readonly IGroup<GameEntity> _cannonTowers;
        private readonly List<GameEntity> _buffer = new(64);

        public CannonTowerAttackSystem(GameContext gameContext, IProjectileFactory projectileFactory)
        {
            _gameContext = gameContext;
            _projectileFactory = projectileFactory;
            
            _cannonTowers = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.TargetId,
                GameMatcher.CannonTower,
                GameMatcher.CooldownUp,
                GameMatcher.Prediction,
                GameMatcher.AttackSpawnPoint,
                GameMatcher.DeparturePoint));
        }

        public void Execute()
        {
            foreach (GameEntity cannonTower in _cannonTowers.GetEntities(_buffer))
            {
                Vector3 adjustedPredictedPosition = cannonTower.Prediction.Position;
                adjustedPredictedPosition.y = cannonTower.DeparturePoint.position.y;

                var distanceBeforeDeparture = Vector3.Distance(cannonTower.AttackSpawnPoint.position,
                    cannonTower.DeparturePoint.position);
                
                float angleBetweenCannonAndTarget = Vector3.Angle(
                    adjustedPredictedPosition - cannonTower.DeparturePoint.position,
                    cannonTower.DeparturePoint.forward);
                
#if UNITY_EDITOR
                Debug.DrawLine(cannonTower.DeparturePoint.position, adjustedPredictedPosition, Color.red);
                Debug.DrawRay(cannonTower.DeparturePoint.position, cannonTower.DeparturePoint.forward * 10);
#endif
                if (angleBetweenCannonAndTarget < 1f)
                {
                    // остановить поворот!
                    // промахивается т.к. Time.deltaTime, а надо в FixedUpdate?
                    // если prediction уже висит, то не надо его обновлять?
                    _projectileFactory.Create(ProjectileType.Cannon, cannonTower.AttackSpawnPoint.position)
                        .AddAttackSpawnPoint(cannonTower.AttackSpawnPoint)
                        .AddDistanceBeforeDeparture(distanceBeforeDeparture)
                        .AddAngleShot(cannonTower.Prediction.Angle)
                        .AddRotation(cannonTower.AttackSpawnPoint.rotation);
                
                    cannonTower.PutOnCooldown();
                }
            }
        }
    }
}