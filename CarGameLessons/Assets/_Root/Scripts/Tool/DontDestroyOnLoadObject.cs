using UnityEngine;

namespace _Root.Scripts.Tool
{
    internal class DontDestroyOnLoadObject : MonoBehaviour
    {
        private void Awake()
        {
            if (enabled)
                DontDestroyOnLoad(gameObject);
        }
    }
}

