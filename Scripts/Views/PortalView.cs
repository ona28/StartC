using System;
using UnityEngine;

namespace Platformer2D
{
    public class PortalView : MonoBehaviour
    {
        public Transform _transform;

        public event Action<Transform, int> OnTriggerEnterChange;

        private void OnTriggerEnter2D(Collider2D collider)
        {
            OnTriggerEnterChange?.Invoke(collider.gameObject.transform, _transform.name == "Enter"? 1 : -1);
        }
    }
}