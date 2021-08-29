using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Ui
{
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Button _buttonStart;
        [SerializeField] private Button _buttonSettings;
        [SerializeField] private Button _buttonRewarded;
        [SerializeField] private Button _buttonPay;

        public void Init(UnityAction startGame, UnityAction settingsGame, UnityAction playAds, UnityAction pay)
        {
            _buttonStart.onClick.AddListener(startGame);
            _buttonSettings.onClick.AddListener(settingsGame);
            _buttonRewarded.onClick.AddListener(playAds);
            _buttonPay.onClick.AddListener(pay);
        }        

        public void OnDestroy()
        {
            _buttonStart.onClick.RemoveAllListeners();
            _buttonSettings.onClick.RemoveAllListeners();
            _buttonRewarded.onClick.RemoveAllListeners();
            _buttonPay.onClick.RemoveAllListeners();
        }
    }
}
