using System.Collections.Generic;
using System.Collections;
using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour, ITakeDamage, IAlive
{
    [SerializeField] private NavMeshAgent agent = null;
    [SerializeField] private int hp = 100;
    [SerializeField] private Animator _anim = null;
    [SerializeField] private GameObject lineHP = null;

    private Image _imageHP = null;
    private GameObject player = null;
    private bool stalk = false;
    private List<Transform> listWayPoints = new List<Transform>();
    private int currentWaypointIndex;    
    private Rigidbody _rb = null;
    private int _maxhp = 100;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
 
        int countWayPoints = transform.parent.childCount;
        Transform[] childrens = transform.parent.GetComponentsInChildren<Transform>();

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

        agent.SetDestination(listWayPoints[0].position);

        _rb = GetComponent<Rigidbody>();        
        _imageHP = lineHP.GetComponent<Image>();
        _imageHP.enabled = false;
        _maxhp = hp;
    }

    private void Update()
    {
        if (!IsAlive())
        {
            agent.isStopped = true;
            return;
        }

        if (stalk)
        {
            agent.SetDestination(player.transform.position);
        }
        else
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                currentWaypointIndex = (currentWaypointIndex + 1) % listWayPoints.Count;
                agent.SetDestination(listWayPoints[currentWaypointIndex].position);
            }
        }

        if (_rb.velocity == Vector3.zero) 
            _anim.SetBool("IsMove", false);
        else
            _anim.SetBool("IsMove", true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) stalk = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) 
        StartCoroutine(ReturnToStartPosition());
    }

    IEnumerator ReturnToStartPosition()
    {
        yield return new WaitForSeconds(2f);
        {
            stalk = false;
            agent.SetDestination(listWayPoints[0].position);
        }
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;

        if (!_imageHP.enabled) _imageHP.enabled = true;
        float s = Convert.ToSingle(hp) / Convert.ToSingle(_maxhp);
        _imageHP.fillAmount = s;

        if (hp <= 0) Death();
    }

    private void Death()
    {
        _anim.SetTrigger("IsDie");
        Destroy(gameObject, 1); 
    }

    public bool IsAlive()
    {
        if (hp <= 0)
            return false;
        else
            return true;
    }
}
