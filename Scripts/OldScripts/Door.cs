using UnityEngine;

public class Door : MonoBehaviour
{
    private bool isOpen = false;
    private bool startOpen = false;
    private Vector3 openAngle = new Vector3(0, 90, 0);

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && ! isOpen)
        {
            startOpen = true;

        }
    }

    private void Update()
    {
        if (startOpen && ! isOpen)
        {
            transform.rotation = Quaternion.AngleAxis(0, Vector3.up);

            if (transform.rotation.eulerAngles == openAngle)
            {
                isOpen = true;
                startOpen = false;
            }
        }
    }
}
