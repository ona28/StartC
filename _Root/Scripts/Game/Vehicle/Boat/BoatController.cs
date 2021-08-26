using Tool;
using UnityEngine;

namespace Game.Car
{
    internal class BoatController : CarController, IVehicle
    {
        private readonly ResourcePath _viewPath = new ResourcePath("Prefabs/Boat");
    }
}
