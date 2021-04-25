using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GameEngine3D
{
    internal sealed class ControllerGame : IAwake, IEnable, IDisable
    {
        private GameObject _exitLevel = null;
        private GameObject _pausePanel = null;
        private Button _inmenu = null;
        private Button _back = null;
        private Button _save = null;
        private Button _load = null;

        private readonly ISaveDataRepository _saveDataRepository = new SaveDataRepository();

        private ControllerInputPC _ctrInput;

        public ControllerGame(ControllerInputPC inputController)
        {
            _ctrInput = inputController;
        }

        public void Awake()
        {
            _exitLevel = GameObject.FindGameObjectWithTag("LevelExit");
            _exitLevel.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;

            _pausePanel = GameObject.Find("PanelPause");
            _inmenu = GameObject.Find("btnInMenu").GetComponent<Button>();
            _back = GameObject.Find("btnBack").GetComponent<Button>();
            _save = GameObject.Find("btnSave").GetComponent<Button>();
            _load = GameObject.Find("btnLoad").GetComponent<Button>();

            _pausePanel.SetActive(false);
            _inmenu.enabled = true;
            _back.enabled = true;
            _save.enabled = true;
            _load.enabled = true;

            _inmenu.onClick.AddListener(ShowMenu);
            _back.onClick.AddListener(ShowGame);
            _save.onClick.AddListener(SaveGame);
            _load.onClick.AddListener(LoadGame);
        }

        private void PauseGame()
        {
            Time.timeScale = 0f;
            _pausePanel.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
        }

        public void Enable()
        {
            _ctrInput.PauseGame += PauseGame;
        }

        public void Disable()
        {
            _ctrInput.PauseGame -= PauseGame;
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

        private void SaveGame()
        {
            _saveDataRepository.Save();
        }

        private void LoadGame()
        {
            _saveDataRepository.Load();
        }
    }
}