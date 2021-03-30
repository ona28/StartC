using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 1;
    private Rigidbody _rb = null;
    private bool _used = false;

    private void Awake()
    {
        Destroy(gameObject, 3);
        _rb = GetComponent<Rigidbody>();        
    }

    public void Init(string _name)
    {
        Vector3 _direction = Vector3.forward;

        // игрок маленький, поэтому бросает €блочки чуть вверх
        if (_name == "Player") _direction = new Vector3(0, 0.15f, 1);

        _rb.AddRelativeForce(_direction * speed, ForceMode.Impulse);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (!_used)
        {
            var comp = collision.gameObject.GetComponent<ITakeDamage>();
            if (comp != null) comp.TakeDamage(15);
        }

        _used = true;

        // можно подобрать использованное €блочко
        if (collision.gameObject.CompareTag("Player") && _used)
        {
            var comp = collision.gameObject.GetComponent<ITakeBulls>();
            comp.TakeBulls(1);
            Destroy(gameObject);
        }
    }
}
