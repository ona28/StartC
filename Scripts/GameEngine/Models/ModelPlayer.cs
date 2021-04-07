using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameEngine3D
{
    internal sealed class ModelPlayer
    {
        private int _hp = 100;
        private int _bulls = 20;         // ���-�� ��������
        private int _bombs = 3;          // ���-�� ����


        public event Action Death;
        public event Action<int> ChangedHealth;

        public ModelPlayer()
        { 

        }

        public void SetNewHealth(int damage)
        {
            _hp -= damage;
            if (_hp >= 0)
                ChangedHealth?.Invoke(_hp);
            
            if (_hp <= 0)
                Death?.Invoke();
        }
    }
}
