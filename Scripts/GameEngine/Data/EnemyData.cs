using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameEngine3D
{
    [CreateAssetMenu(fileName = "EnemySettings", menuName = "Data/EnemySettings")]
    public sealed class EnemyData : ScriptableObject
    {
        [Serializable]
        private struct EnemyInfo
        {
            public TypeEnemy Type;
            public ViewEnemy EnemyPrefab;
        }

        [SerializeField] private List<EnemyInfo> _enemyInfos;

        public ViewEnemy GetEnemy(TypeEnemy type)
        {
            var enemyInfo = _enemyInfos.First(info => info.Type == type);
            return enemyInfo.EnemyPrefab;
        }
    }
}
