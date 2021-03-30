using System;
using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private float _explosionRadius = 4; // радиус поражения
    private float _power = 500000;      // сила взрыва	

    private Rigidbody[] _rbs; // все физ. объекты которые есть на сцене
    private Rigidbody _rb = null;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _rbs = FindObjectsOfType(typeof(Rigidbody)) as Rigidbody[];
    }

    private void OnDrawGizmos() // temp
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _explosionRadius);        
    }

    public void Init()
    {
        _rb.AddRelativeForce(Vector3.forward * 150, ForceMode.Force);
    }


    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(Explosion());
    }

    IEnumerator Explosion()
    {
        yield return new WaitForSeconds(2.5f);

        var clip = GetComponent<AudioSource>();
        clip.Play();


        for (int i = 0; i < _rbs.Length; i++)
        {
            if (_rbs[i] == null) continue; // вдруг уже умер

            // исключаем объекты, которые достаточно далеко от взвыва
            float distance = Vector3.Distance(transform.position, _rbs[i].transform.position);

            if (distance <= _explosionRadius)
            {
                _rbs[i].AddExplosionForce(_power, transform.position, _explosionRadius);

                var comp = _rbs[i].gameObject.GetComponent<ITakeDamage>();
                if (comp != null)
                {
                    if (distance == 0) comp.TakeDamage(100);
                    else comp.TakeDamage(Convert.ToInt32(_explosionRadius * 100 / distance));
                }
            }
        }
        Destroy(gameObject, 3);
    }
}
