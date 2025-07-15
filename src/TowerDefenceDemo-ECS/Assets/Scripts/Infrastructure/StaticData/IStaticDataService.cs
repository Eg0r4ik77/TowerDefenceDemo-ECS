using Gameplay.Enemies;
using Gameplay.Enemies.Data;
using Gameplay.Projectiles;
using Gameplay.Projectiles.Data;
using Gameplay.Towers;
using Gameplay.Towers.Data;

namespace Infrastructure.StaticData
{
    public interface IStaticDataService
    {
        public void LoadAll();
        public EnemyData GetEnemyData(EnemyType type);
        public EnemySpawnerData GetEnemySpawnerData();
        public TowerData GetTowerData(TowerType type);
        public ProjectileData GetProjectileData(ProjectileType type);
    }
}