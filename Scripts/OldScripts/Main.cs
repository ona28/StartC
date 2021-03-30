using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    [SerializeField] private GameObject Enemy = null;
    GameObject[] Enemes = new GameObject[0];
    GameObject exitLevel = null;

    private void Start()
    {
        GameObject[] gameObjects;
        gameObjects = GameObject.FindGameObjectsWithTag("EnemyPosition");

        foreach (GameObject @object in gameObjects)
        {
            _ = Instantiate(Enemy, @object.transform, false);          
            Cursor.lockState = CursorLockMode.Locked;
        }

        Enemes = GameObject.FindGameObjectsWithTag("Enemy");
        exitLevel = GameObject.FindGameObjectWithTag("LevelExit");
        exitLevel.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (Enemes.Length == 0) exitLevel.SetActive(true);
    }

}
