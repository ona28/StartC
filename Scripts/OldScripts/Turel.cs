using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turel : MonoBehaviour, ITakeDamage
{
    [SerializeField] private int hp = 70;
    [SerializeField] private GameObject bullet = null;
    [SerializeField] private Transform bulletStartPosition;
    private bool fire = false;
    private int fireCount = 0;
    private GameObject target;

    private void Awake()
    {
        target = GameObject.FindWithTag("Player");      
    }

    private void OnTriggerEnter(Collider other)
    {
        RotateAndFire(ref other);
        InvokeRepeating("Fire", 1, 4);
    }

    private void OnTriggerStay(Collider other)
    {
        RotateAndFire(ref other);
    }

    private void RotateAndFire(ref Collider other)
    {        
        if (other.gameObject == target)
        {
            if (target.GetComponent<IAlive>().IsAlive())
            {
                // разворот в сторону игрока
                //Vector3 pos = target.transform.position - transform.position;
                //Quaternion rotation = Quaternion.LookRotation(pos, Vector3.up);
                //transform.rotation = rotation;

                transform.LookAt(target.transform);
                fire = true;
            }
            else
            {
                fire = false;
            }
        }        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == target)
        {
            CancelInvoke("Fire"); 
            fire = false;
        }
    }    

    private void Fire()
    {
        if (!fire) return;

        fireCount++;
        if (fireCount >= 3)
        {
            fireCount = 0;
            return;
        }

        fire = false;
        var bul = Instantiate(bullet, bulletStartPosition.position, transform.rotation).GetComponent<Bullet>();
        bul.Init(name); ;
     }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0) Death();
    }

    private void Death()
    {
        Destroy(gameObject, 1);        
    }
}
