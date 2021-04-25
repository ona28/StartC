using UnityEngine;

namespace GameEngine3D
{
    public interface IFactoryEnemy
    {
        IEnemy CreateEnemy(TypeEnemy type, Transform parent, bool worldPositionStays);
    }
}