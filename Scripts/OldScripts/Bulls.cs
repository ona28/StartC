using UnityEngine;

public class Bulls : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var comp = other.gameObject.GetComponent<ITakeBulls>();
            if (comp != null) comp.TakeBulls(5);
            Destroy(gameObject);
        }
    }
}
