using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

internal class SettingView : MonoBehaviour
{
    [SerializeField] private Button _buttonBack;

    public void Init(UnityAction backGame)
    {
        _buttonBack.onClick.AddListener(backGame);
    }   

    public void OnDestroy()
    {
        _buttonBack.onClick.RemoveAllListeners();
    }
}
