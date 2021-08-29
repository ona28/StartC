using Ui;
using Game;
using Profile;
using UnityEngine;
using Services.Ads.UnityAds;
using UnityEngine.Analytics;
using Services.Analytics;

internal class MainController : BaseController
{
    private MainMenuController _mainMenuController;
    private GameController _gameController;
    private SettingsController _settingsController;
    private readonly Transform _placeForUi;
    private readonly ProfilePlayer _profilePlayer;
    private readonly CarType _carType;
    public MainController(Transform placeForUi, ProfilePlayer profilePlayer, CarType carType)
    {
        _carType = carType;
        _profilePlayer = profilePlayer;
        _placeForUi = placeForUi;
        OnChangeGameState(_profilePlayer.CurrentState.Value);
        profilePlayer.CurrentState.SubscribeOnChange(OnChangeGameState);
    }

    protected override void OnDispose()
    {
        _mainMenuController?.Dispose();
        _gameController?.Dispose();
        _settingsController?.Dispose();
        _profilePlayer.CurrentState.UnSubscribeOnChange(OnChangeGameState);
    }

    private void OnChangeGameState(GameState state)
    {
        switch (state)
        {
            case GameState.Start:
                _mainMenuController = new MainMenuController(_placeForUi, _profilePlayer);
                _gameController?.Dispose();
                _settingsController?.Dispose();
                break;
            case GameState.Settings:
                _settingsController = new SettingsController(_placeForUi, _profilePlayer);
                _mainMenuController?.Dispose();
                _gameController?.Dispose();
                break;
            case GameState.Ads:
                RewardedPlayer rpl = new RewardedPlayer("Rewarded_Android");
                rpl.Play();
                break;
            case GameState.Pay:
                // дописать потом

                Analytics.Transaction("OnePay", 0, "руб.", null, null);
                AnalyticsManager _am = AnalyticsManager.getInstance();
                _am.NewPay();
                Debug.Log($"Здесь совершается покупка {state}");
                break;
            case GameState.Game:
                _gameController = new GameController(_profilePlayer, _carType);
                _mainMenuController?.Dispose();
                _settingsController?.Dispose();
                break;
            default:
                _mainMenuController?.Dispose();
                _gameController?.Dispose();
                _settingsController?.Dispose();
                break;
        }
    }
}
