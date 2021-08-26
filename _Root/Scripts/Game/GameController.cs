using Game.Car;
using Game.InputLogic;
using Game.TapeBackground;
using Profile;
using Tool;

namespace Game
{
    internal class GameController : BaseController
    {
        public GameController(ProfilePlayer profilePlayer, CarType carType)
        {
            var leftMoveDiff = new SubscriptionProperty<float>();
            var rightMoveDiff = new SubscriptionProperty<float>();

            var tapeBackgroundController = new TapeBackgroundController(leftMoveDiff, rightMoveDiff);
            AddController(tapeBackgroundController);

            var inputGameController = new InputGameController(leftMoveDiff, rightMoveDiff, profilePlayer.CurrentCar);
            AddController(inputGameController);

            LoadCarController(carType);
        }

        private void LoadCarController(CarType carType)
        {
            IVehicle carController;

            switch (carType)
            {
                case CarType.Boat:
                    carController = new BoatController();
                    break;

                default:
                    carController = new CarController();
                    break;
            }

            AddController((BaseController)carController);
        }
    }
}
