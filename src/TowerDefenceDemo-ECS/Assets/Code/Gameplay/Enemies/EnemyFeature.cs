using Code.Common;
using Code.Gameplay.Enemies.Systems;
using UnityEngine;

namespace Code.Gameplay.Enemies
{
    public class EnemyFeature : Feature
    {
        public EnemyFeature(GameContext gameContext, TestMonster prefab, Transform[] routePoints)
        {
            Add(new InitializeEnemySpawnTimerSystem());
            Add(new SpawnEnemySystem(gameContext, prefab, routePoints));
        }
    }
}