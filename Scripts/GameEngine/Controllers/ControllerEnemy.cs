using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace GameEngine3D
{
    internal sealed class ControllerEnemy : IStart, IUpdate, IEnable, IDisable
    {
        private readonly NavMeshAgent _agent = null;
        private readonly Transform _tr = null;
        //private readonly Rigidbody _rb = null;
        private readonly GameObject _target = null;

        private List<Transform> listWayPoints = new List<Transform>();
        private int _currentWaypointIndex;
        private bool _isAlive = true;
        private bool _isSeek = false;

        private ViewEnemy _enemyView = null;
        private ModelEnemy _enemyModel = null;

        public ControllerEnemy(ModelEnemy modelEnemy, ViewEnemy viewEnemy, GameObject target)
        {
            _tr = viewEnemy.GetComponent<Transform>();
            //_rb = viewEnemy.GetComponent<Rigidbody>();
            _agent = viewEnemy.GetComponent<NavMeshAgent>();

            _enemyView = viewEnemy;
            _enemyModel = modelEnemy;
            _target = target;
        }

        private void CollisionEnterChange(string tag)
        {
            if (tag == "Player")
                _enemyModel.SetNewHealth(5); ;
        }

        private void ChangeHealth(int health)
        {
            _enemyView.ChangeHealth(health);
        }

        private void Death()
        {
            _isAlive = false;
            _enemyView.Death();
            Disable();
        }

        public void Enable()
        {
            _enemyModel.DeathEnemy += Death;
            _enemyModel.ChangedHealthEnemy += ChangeHealth;
            _enemyView.OnCollisionEnterChangeEnemy += CollisionEnterChange;
        }

        public void Disable()
        {
            _enemyModel.DeathEnemy -= Death;
            _enemyModel.ChangedHealthEnemy -= ChangeHealth;
            _enemyView.OnCollisionEnterChangeEnemy -= CollisionEnterChange;
        }

        public void Start()
        {
            int countWayPoints = _tr.parent.childCount;
            Transform[] childrens = _tr.parent.GetComponentsInChildren<Transform>();

            for (int i = 0; i < countWayPoints; i++)
            {
                GameObject child = childrens[i].gameObject;

                #region Комментарии к коду
                // т.к. враги спавнятся в точке каждый в своей точке старта
                // в них же расположены у НЕКОТОРЫХ врагов точки патрулирования
                // (получается дерево: 
                //                      PoinSrartEnemes(контейнер)
                //                            - Enemy1(nочка появления) 
                //                                   - Enemy, 
                //                                   - WayPoint1, 
                //                                   - WayPoint2...)
                // то исключаем по тегу "Enemy" - получаем список точек патрулирование для каждого врага
                #endregion
                if (!child.CompareTag("Enemy"))
                {
                    listWayPoints.Add(child.transform);
                }
            }

            _agent.SetDestination(listWayPoints[0].position);
        }

        public void Update(float deltaTime)
        {
            if (!_isAlive)
            {
                _agent.isStopped = true;
                return;
            }

            if (_isSeek)
            {
                _agent.SetDestination(_target.transform.position);
            }
            else
            {
                if (_agent.remainingDistance <= _agent.stoppingDistance)
                {
                    _currentWaypointIndex = (_currentWaypointIndex + 1) % listWayPoints.Count;
                    _agent.SetDestination(listWayPoints[_currentWaypointIndex].position);
                }
            }
        }
    }
}