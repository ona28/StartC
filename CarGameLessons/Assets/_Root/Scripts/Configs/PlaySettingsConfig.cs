using System;
using UnityEngine;

namespace Configs
{

    [CreateAssetMenu(fileName = "PlaySettingsCfg", menuName = "Configs/PlaySettings", order = 1)]
    internal class PlaySettingsConfig : ScriptableObject
    {
        [field: SerializeField, Range(0, 100)] public float SpeedCar { get; private set; }
        [field: SerializeField] public Profile.GameState GameState { get; private set; }
        [field: SerializeField] public Game.CarType CarType { get; private set; }
    }
}
