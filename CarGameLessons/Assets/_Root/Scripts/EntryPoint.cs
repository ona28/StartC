using Profile;
using Configs;
using UnityEngine;
using Services.Analytics;
using Services.Ads.UnityAds;

internal class EntryPoint : MonoBehaviour
{
    [SerializeField] private Transform _placeForUi;
    [SerializeField] private PlaySettingsConfig _playConfig;
    private AnalyticsManager _analytics;
    [SerializeField] private UnityAdsService _adsService;

    private MainController _mainController;

    private void Awake()
    {
        var profilePlayer = new ProfilePlayer(_playConfig.SpeedCar, _playConfig.GameState);
        _mainController = new MainController(_placeForUi, profilePlayer, _playConfig.CarType);

        _analytics = AnalyticsManager.getInstance();
        _analytics.SendMainMenuOpened();

        _adsService.Initialized.AddListener(_adsService.InterstitialPlayer.Play); 
    }

    protected void OnDestroy()
    {
        _mainController.Dispose();
        _adsService.Initialized.RemoveListener(_adsService.InterstitialPlayer.Play);
    }
}
