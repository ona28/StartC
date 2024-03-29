using JoostenProductions;
using Tool;
using UnityEngine;

namespace Game.InputLogic
{
    internal class GyroscopeInputView : BaseInputView
    {
        public override void Init(
            SubscriptionProperty<float> leftMove,
            SubscriptionProperty<float> rightMove,
            float speed)
        {
            base.Init(leftMove, rightMove, speed);
            Input.gyro.enabled = true;
        }

        private void Start() =>
            UpdateManager.SubscribeToUpdate(Move);

        private void OnDestroy() =>
            UpdateManager.UnsubscribeFromUpdate(Move);

        private void Move()
        {
            if (!SystemInfo.supportsGyroscope)
                return;

            Quaternion quaternion = Input.gyro.attitude;
            quaternion.Normalize();

            float offset = quaternion.x + quaternion.y;
            OnRightMove(offset * Time.deltaTime * _speed);
        }
    }
}
