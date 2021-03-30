using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePause : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel = null;
    [SerializeField] private Button _inmenu = null;
    [SerializeField] private Button _back = null;

    private void Awake()
    {
        _pausePanel.SetActive(false);
        _inmenu.enabled = true;
        _back.enabled = true;

        _inmenu.onClick.AddListener(ShowMenu);
        _back.onClick.AddListener(ShowGame);
    }

    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            _pausePanel.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;            
        }
    }

    private void ShowGame()
    {
        _pausePanel.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void ShowMenu()
    {
        _pausePanel.SetActive(false);
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}
