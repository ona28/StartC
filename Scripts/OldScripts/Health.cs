using UnityEngine;

public class Health : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var comp = other.gameObject.GetComponent<ITakeDamage>();
            if (comp != null) comp.TakeDamage(-25);
            Destroy(gameObject);
        }
    }
}
