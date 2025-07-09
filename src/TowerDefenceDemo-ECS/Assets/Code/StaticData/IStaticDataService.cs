using Code.Gameplay.Enemies;
using Code.Gameplay.Enemies.Data;
using Code.Gameplay.Towers;

namespace Code.StaticData
{
    public interface IStaticDataService
    {
        public void LoadAll();
        public EnemyData GetEnemyData(EnemyType type);
        public EnemySpawnerData GetEnemySpawnerData();
        public TowerData GetTowerData(TowerType type);
    }
}