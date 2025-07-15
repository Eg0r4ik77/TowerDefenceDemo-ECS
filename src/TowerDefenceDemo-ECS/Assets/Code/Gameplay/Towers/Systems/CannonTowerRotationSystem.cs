using Code.Gameplay.Towers;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Attack.Systems
{
    public class CannonTowerRotationSystem : IExecuteSystem
    {
        private readonly GameContext _gameContext;
        
        private readonly IGroup<GameEntity> _cannonTowers;

        public CannonTowerRotationSystem(GameContext gameContext)
        {
            _gameContext = gameContext;
            _cannonTowers = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.TargetId,
                GameMatcher.CannonTower,
                GameMatcher.AttackSpawnPoint,
                GameMatcher.DeparturePoint));
        }

        public void Execute()
        {
            foreach (GameEntity cannonTower in _cannonTowers)
            {
                GameEntity target = _gameContext.GetEntityWithId(cannonTower.TargetId);
                
                var distanceBeforeDeparture = Vector3.Distance(cannonTower.AttackSpawnPoint.position,
                    cannonTower.DeparturePoint.position);
                
                var prediction = CalculatePredictedPosition(cannonTower, target, distanceBeforeDeparture);
                
                if (prediction != null)
                {
                    cannonTower.ReplacePrediction(prediction.Value);
                    cannonTower.ReplaceTargetRotationPosition(prediction.Value.Position);     
                }
                else if (cannonTower.hasPrediction && cannonTower.hasTargetRotationPosition)
                {
                    cannonTower.RemovePrediction();
                    cannonTower.RemoveTargetRotationPosition();
                }
            }
        }
        
        // в отдельную систему
        private Prediction? CalculatePredictedPosition(GameEntity tower, GameEntity target, float distanceBeforeDeparture)
        {
            const float predictionSegment = 2f;
            const float predictionStep = 0.1f;
    
            //var projectileSpeed = projectilePrefab.Speed;
            var projectileSpeed = 20f;
            
            var targetSpeed = target.Speed;
    
            var projectileDepartureTime = distanceBeforeDeparture / projectileSpeed;
    
            for (float step = 0; step <= predictionSegment; step += predictionStep)
            {
                var nextTargetPosition = target.WorldPosition + step * target.Transform.forward;
        
                var nextDeparturePosition = nextTargetPosition;
                nextDeparturePosition.y = tower.DeparturePoint.position.y;
        
                var nextDepartureDirection = (nextDeparturePosition - tower.AttackSpawnPoint.position).normalized;
                nextDeparturePosition = tower.AttackSpawnPoint.position + nextDepartureDirection * distanceBeforeDeparture;
        
                var time = step / targetSpeed - projectileDepartureTime;
                var xozTranslation = new Vector3(nextTargetPosition.x - nextDeparturePosition.x, 0, nextTargetPosition.z - nextDeparturePosition.z);
        
                var sin =  (xozTranslation.magnitude) / (projectileSpeed * time);
                var cos = (nextDeparturePosition.y - nextTargetPosition.y + (-9.81f) * time * time / 2) 
                          / (projectileSpeed * time);
        
                if (sin >= 0 && sin <= 1f && cos >= 0 && cos <= 1f)
                {
                    var angle = cos == 0
                        ? Mathf.PI / 2
                        : Mathf.Atan(sin / cos);
            
                    var prediction = new Prediction
                    {
                        Position = nextTargetPosition,
                        Angle = angle
                    };
            
                    return prediction;
                }
            }

            return null;
        }
    }
}