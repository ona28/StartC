using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Header("Menu")]
    [SerializeField] private GameObject _menuPanel = null;
    [SerializeField] private Button _start = null;
    [SerializeField] private Button _options = null;
    [SerializeField] private Button _quit = null;
    [Header("Options")]
    [SerializeField] private GameObject _optionsPanel = null;
    [SerializeField] private Toggle _mute = null;
    [SerializeField] private Slider _slider = null;
    [SerializeField] private Button _save = null;
    [SerializeField] private Button _back = null;

    private AudioListener _alist = null;
    private AudioSource _audio = null;

    private void Awake()        
    {
        _menuPanel.SetActive(true);
        _optionsPanel.SetActive(false);

        _start.onClick.AddListener(StartGame);
        _options.onClick.AddListener(ShowOptions);
        _quit.onClick.AddListener(Quit);

        _save.onClick.AddListener(SaveOptions);
        _back.onClick.AddListener(ShowMenu);
        _mute.onValueChanged.AddListener(Mute);
        _slider.onValueChanged.AddListener(ChangeVolume);

        _alist = GameObject.Find("Main Camera").GetComponent<AudioListener>();
        _alist.enabled = true;

        _audio = GameObject.Find("Audio Source").GetComponent<AudioSource>();
    }

    private void StartGame()
    {
        _alist.enabled = false;
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }

    private void ShowOptions()
    {        
        _optionsPanel.SetActive(true);
        _start.enabled = false;
        _options.enabled = false;
        _quit.enabled = false;
    }

    private void ShowMenu()
    {
        _start.enabled = true;
        _options.enabled = true;
        _quit.enabled = true;
        _optionsPanel.SetActive(false);
    }

    private void Mute(bool value)
    {
        _audio.enabled = value;
    }

    private void ChangeVolume(float value)
    {
        _audio.volume = value;
    }

    private void SaveOptions()
    { 
    }

    private void Quit()
    {
        Application.Quit();
    }
}

    
