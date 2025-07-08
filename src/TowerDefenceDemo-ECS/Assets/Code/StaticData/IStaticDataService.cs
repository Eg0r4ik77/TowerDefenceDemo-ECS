using Code.Gameplay.Enemies;
using Code.Gameplay.Enemies.Data;

namespace Code.StaticData
{
    public interface IStaticDataService
    {
        public void LoadAll();
        public EnemyData GetEnemyData(EnemyType type);
        public EnemySpawnerData GetEnemySpawnerData();
    }
}