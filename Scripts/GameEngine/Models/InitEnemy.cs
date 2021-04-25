using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameEngine3D
{
    public sealed class InitEnemy
    {
        private readonly IFactoryEnemy _factoryEnemy;
        private TypeEnemy _typeEnemy = TypeEnemy.Small;
        private EnemyData _enemyData;
        private GameObject _target = null;

        public InitEnemy(in Controllers controllers, GameObject target, IFactoryEnemy factoryEnemy, EnemyData enemyData)
        {
            _target = target;
            _factoryEnemy = factoryEnemy;
            _enemyData = enemyData;

            SpawnEnemy(in controllers);
        }

        private void SpawnEnemy(in Controllers controllers)
        {
            GameObject[] gameObjects;
            gameObjects = GameObject.FindGameObjectsWithTag("EnemyPosition");

            foreach (GameObject @object in gameObjects)
            {
                var enemy = _factoryEnemy.CreateEnemy(_typeEnemy, @object.transform, false) as ViewEnemy;
                controllers.Add(new ControllerEnemy(new ModelEnemy(), enemy, _target));
            }
        }
    }
}
