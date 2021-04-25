using System;

namespace GameEngine3D
{
    internal sealed class ModelEnemy
    {
        private int _hp = 100;

        public event Action DeathEnemy;
        public event Action<int> ChangedHealthEnemy;

        public ModelEnemy()
        {

        }

        public void SetNewHealth(int damage)
        {
            _hp -= damage;
            if (_hp >= 0)
                ChangedHealthEnemy?.Invoke(_hp);

            if (_hp <= 0)
                DeathEnemy?.Invoke();
        }
    }
}
