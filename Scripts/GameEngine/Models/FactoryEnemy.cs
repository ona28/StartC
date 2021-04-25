using UnityEngine;

namespace GameEngine3D
{
    public sealed class FactoryEnemy: IFactoryEnemy
    {
        private readonly EnemyData _data;

        public FactoryEnemy(EnemyData data)
        {
            _data = data;
        }

        public IEnemy CreateEnemy(TypeEnemy type, Transform parent, bool worldPositionStays)
        {
            var enemyView = _data.GetEnemy(type);
            return Object.Instantiate(enemyView, parent, worldPositionStays);
        }
    }
}
