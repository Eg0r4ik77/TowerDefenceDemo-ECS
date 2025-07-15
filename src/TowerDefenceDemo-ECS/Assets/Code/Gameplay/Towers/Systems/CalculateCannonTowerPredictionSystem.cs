using Code.Common;
using Code.Gameplay.Towers;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Attack.Systems
{
    public class CalculateCannonTowerPredictionSystem : IExecuteSystem
    {
        private readonly GameContext _gameContext;
        
        private readonly IGroup<GameEntity> _cannonTowers;

        public CalculateCannonTowerPredictionSystem(GameContext gameContext)
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
                Prediction? prediction = CalculatePredictedPosition(cannonTower, target);
                
                if (prediction != null)
                    cannonTower.ReplacePrediction(prediction.Value);
            }
        }
        
        private Prediction? CalculatePredictedPosition(GameEntity tower, GameEntity target)
        {
            const float predictionSegment = 2f;
            const float predictionStep = 0.1f;
    
            float projectileSpeed = tower.StartProjectileSpeed;
            float targetSpeed = target.Speed;
            
            float distanceBeforeDeparture = Vector3.Distance(
                tower.AttackSpawnPoint.position,
                tower.DeparturePoint.position);
    
            float projectileDepartureTime = distanceBeforeDeparture / projectileSpeed;
    
            for (float step = 0; step <= predictionSegment; step += predictionStep)
            {
                Vector3 nextTargetPosition = target.WorldPosition + step * target.Transform.forward;
        
                Vector3 nextDeparturePosition = nextTargetPosition;
                nextDeparturePosition.y = tower.DeparturePoint.position.y;
        
                Vector3 nextDepartureDirection = (nextDeparturePosition - tower.AttackSpawnPoint.position).normalized;
                nextDeparturePosition = tower.AttackSpawnPoint.position + nextDepartureDirection * distanceBeforeDeparture;
        
                float time = step / targetSpeed - projectileDepartureTime;
                Vector3 xozTranslation = new Vector3(nextTargetPosition.x - nextDeparturePosition.x, 0, nextTargetPosition.z - nextDeparturePosition.z);
        
                float sin =  (xozTranslation.magnitude) / (projectileSpeed * time);
                float cos = (nextDeparturePosition.y - nextTargetPosition.y +
                             GameplayConstants.GravityAcceleration * time * time / 2)
                            / (projectileSpeed * time);
        
                if (sin >= 0 && sin <= 1f && cos >= 0 && cos <= 1f)
                {
                    float angle = cos == 0
                        ? Mathf.PI / 2
                        : Mathf.Atan(sin / cos);

                    Prediction prediction = new()
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