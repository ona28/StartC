using Profile;
using UnityEngine;

internal class EntryPoint : MonoBehaviour
{
    [SerializeField] private Transform _placeForUi;
    [SerializeField] private PlaySettingsConfig _playConfig;

    private MainController _mainController;

    private void Awake()
    {
        _playConfig = Resources.Load<PlaySettingsConfig>("PlaySettingsCfg");

        var profilePlayer = new ProfilePlayer(_playConfig.speedCar, _playConfig.gameState);
        _mainController = new MainController(_placeForUi, profilePlayer, _playConfig.carType);
    }

    protected void OnDestroy()
    {
        _mainController.Dispose();
    }
}
