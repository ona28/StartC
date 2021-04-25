using System;

namespace GameEngine3D
{
    public interface IEnemy
    {
        event Action<string> OnCollisionEnterChangeEnemy;
    }
}
