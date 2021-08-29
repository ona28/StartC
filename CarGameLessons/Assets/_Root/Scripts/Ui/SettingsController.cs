using UnityEngine;
using Profile;
using Tool;

namespace Ui
{
    internal class SettingsController: BaseController
    {
        private readonly ResourcePath _viewPath = new ResourcePath("Prefabs/settingMenu");
        private readonly ProfilePlayer _profilePlayer;
        private readonly SettingView _view;


        public SettingsController(Transform placeForUi, ProfilePlayer profilePlayer) 
        {
            _profilePlayer = profilePlayer;
            _view = LoadView(placeForUi);
            _view.Init(BackGame);
        }

        private SettingView LoadView(Transform placeForUi)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_viewPath);
            GameObject objectView = Object.Instantiate(prefab, placeForUi, false);
            AddGameObject(objectView);

            return objectView.GetComponent<SettingView>();
        }
       
        private void BackGame() =>
            _profilePlayer.CurrentState.Value = GameState.Start;
    }
}
