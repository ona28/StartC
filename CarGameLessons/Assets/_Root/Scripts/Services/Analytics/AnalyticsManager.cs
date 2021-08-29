using UnityEngine;
using Services.Analytics.UnityAnalytics;

namespace Services.Analytics
{
    internal sealed class AnalyticsManager
    {
        private static AnalyticsManager instance;
        private IAnalyticsService[] _services;

        public static AnalyticsManager getInstance()
        {
            if (instance == null)
                instance = new AnalyticsManager();
            return instance;
        }

        private AnalyticsManager()
        {
            InitializeServices();
        }

        private void InitializeServices()
        {
            _services = new IAnalyticsService[]
            {
                new UnityAnalyticsService()
            };
        }

        public void SendMainMenuOpened() =>
            SendEvent("MainMenuOpened");

        public void StartNewLevel() =>
            SendEvent("StartNewLevel");

        public void NewPay() =>
            SendEvent("NewPay");

        private void SendEvent(string eventName)
        {
            for (int i = 0; i < _services.Length; i++)
                _services[i].SendEvent(eventName);
            Debug.Log($"Событие в аналитику ''{eventName}''");
        }
    }
}
