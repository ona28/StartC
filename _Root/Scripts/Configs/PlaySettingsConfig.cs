using System;
using UnityEngine;

namespace Profile
{
    internal enum CarType
    {
        Car = 0,
        Boat = 1
    }

    [CreateAssetMenu(fileName = "PlaySettingsCfg", menuName = "Configs/PlaySettings", order = 1)]
    internal class PlaySettingsConfig : ScriptableObject
    {
        [Range(0,100)] public float speedCar;
        public GameState gameState;
        public CarType carType;
    }
}
