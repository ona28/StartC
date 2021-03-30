using UnityEngine;

public class DoorsTwin : MonoBehaviour
{
    private bool isOpen = false;
    private bool startOpen = false;
    private Transform doorLeft;
    private Transform doorRight;
    private float Step = 0.1f;
    private float valueOpen = 0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && ! isOpen)
        {
            startOpen = true;
            doorLeft = transform.Find("Door left");
            doorRight = transform.Find("Door right");

            var clip = GetComponent<AudioSource>();
            clip.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (startOpen && ! isOpen)
        {
            doorLeft.Translate(-Step * Vector3.forward);
            doorRight.Translate(Step * Vector3.forward);
            valueOpen += Step;

            if (valueOpen >= 1.3)
            {
                isOpen = true;
                startOpen = false;
            }
        }
    }
}
